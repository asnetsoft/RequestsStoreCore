using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;
using WebUI.Infrastructure.Mappers;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRequestsRepository repository;
        IMapper modelMapper;
        public HomeController(IRequestsRepository repository, IMapper modelMapper)
        {
            this.repository = repository;
            this.modelMapper = modelMapper;
        }
        public IActionResult Index(int? page, int? statuses, string sortOrder, string dateStart, string dateEnd, bool returnedFilter = false)
        {

            ViewBag.DateStart = dateStart != null ? DateTime.Parse(dateStart).ToShortDateString() : DateTime.Now.AddMonths(-1).ToShortDateString();
            ViewBag.DateEnd = dateEnd != null ? DateTime.Parse(dateEnd).ToShortDateString() : DateTime.Now.AddDays(1).ToShortDateString();
            ViewBag.ReturnedFilter = returnedFilter;
            ViewBag.CurrentFilterStatuses = statuses;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.sortCreateDate = sortOrder == "CreateDate" ? "CreateDate_desc" : "CreateDate";
            ViewBag.sortDateEnd = sortOrder == "DateEnd" ? "DateEnd_desc" : "DateEnd";


            var model = (List<RequestsStoreViewModel>)modelMapper.Map(repository.RequestsStore.GroupBy(a => a.Requests)
                                                                                .Select(b => b
                                                                                .Where(a => a.Date >= DateTime.Parse(ViewBag.DateStart))
                                                                                .Where(a => a.Date <= DateTime.Parse(ViewBag.DateEnd))
                                                                                .OrderByDescending(a => a.Date)
                                                                                .FirstOrDefault())
                                                                                .Where(a => a != null)
                                                                                .ToList(), typeof(List<RequestsStore>), typeof(List<RequestsStoreViewModel>));

            if (model.GetEnumerator().MoveNext())
            {
                if (returnedFilter == true)
                {
                    var returnedRequests = repository.RequestsStore.Where(r => r.StatusId == 3).Distinct().Select(r => r.Requests.RequestId).ToList();
                    model = model.Where(r => returnedRequests.Contains(r.Requests.RequestId)).ToList();
                }


                if (statuses != null)
                {
                    model = model.Where(s => s.StatusId == statuses).ToList();
                }

                switch (sortOrder)
                {
                    case "CreateDate":
                        model = model.OrderBy(a => a.Requests.CreateDate).ToList();
                        break;
                    case "CreateDate_desc":
                        model = model.OrderByDescending(a => a.Requests.CreateDate).ToList();
                        break;
                    case "DateEnd":
                        model = model.OrderBy(a => a.Date).OrderBy(a => a.StatusId).ToList();
                        break;
                    case "DateEnd_desc":
                        model = model.OrderByDescending(a => a.Date).OrderByDescending(a => a.StatusId).ToList();
                        break;
                    default:
                        model = model.OrderByDescending(a => a.Requests.CreateDate).ToList();
                        break;
                }
            }
            ViewBag.StatusesList = new SelectList(repository.Statuses.ToList(), "StatusID", "Name", 0);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = (RequestsViewModel)modelMapper.Map(await repository.GetRequest((int)id), typeof(Requests), typeof(RequestsViewModel));
            if (model == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            //var model = new RequestsStoreViewModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequestsStoreViewModel model)
        {
            if (model == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            model.Requests.CreateDate = DateTime.Now;
            model.Date = DateTime.Now;
            model.StatusId = repository.Statuses.Single(a => a.StatusID == 1).StatusID;
            model.Comments = "Заявка создана";

            ModelState.Remove("Comments");
           // ModelState.AddModelError("Comments", new ModelState());
            if (ModelState.IsValid)
            {
                await repository.AddRequest((RequestsStore)modelMapper.Map(model, typeof(RequestsStoreViewModel), typeof(RequestsStore)));
                return RedirectToAction("Index");
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = (RequestsViewModel)modelMapper.Map(repository.Requests.FirstOrDefault(r => r.RequestId == id), typeof(Requests), typeof(RequestsViewModel));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RequestsViewModel model)
        {
            if (model == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            if (ModelState.IsValid)
            {
                await repository.EditRequest((Requests)modelMapper.Map(model, typeof(RequestsViewModel), typeof(Requests)));
            }
            return RedirectToAction("Edit", model);
        }

        [HttpGet]
        public IActionResult AddRequestStore(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var request = (RequestsStoreViewModel)modelMapper.Map(repository.RequestsStore.FirstOrDefault(r => r.RequestsStoreId == id), typeof(RequestsStore), typeof(RequestsStoreViewModel));

            var model = new RequestsStoreViewModel
            {
                Requests = request.Requests,
                RequestId = request.RequestId,
                StatusId = request.StatusId
            };

            switch (request.StatusId)
            {
                case 1:
                    ViewBag.StatusesList = new SelectList(repository.Statuses.Where(s => s.StatusID == 2).ToList(), "StatusID", "Name");
                    break;
                case 2:
                    ViewBag.StatusesList = new SelectList(repository.Statuses.Where(s => s.StatusID == 3 || s.StatusID == 4).ToList(), "StatusID", "Name");
                    break;
                case 3:
                    ViewBag.StatusesList = new SelectList(repository.Statuses.Where(s => s.StatusID == 2).ToList(), "StatusID", "Name");
                    break;
                default:
                    ViewBag.StatusesList = new SelectList(repository.Statuses.Where(s => s.StatusID == 4).ToList(), "StatusID", "Name");
                    break;
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRequestStore(RequestsStoreViewModel model)
        {
            if (model == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            if (ModelState.IsValid)
            {
                await repository.AddRequest((RequestsStore)modelMapper.Map(model, typeof(RequestsStoreViewModel), typeof(RequestsStore)));
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = (RequestsViewModel)modelMapper.Map(await repository.GetRequest((int)id), typeof(Requests), typeof(RequestsViewModel));
            if (model == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return PartialView(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            await repository.DeleteRequest((int)id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DetailsStore(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = (List<RequestsStoreViewModel>)modelMapper.Map(repository.RequestsStore.Where(r => r.Requests.RequestId == id).OrderBy(r => r.Date).ToList(), typeof(List<RequestsStore>), typeof(List<RequestsStoreViewModel>));
            return PartialView(model);
        }
    }
}