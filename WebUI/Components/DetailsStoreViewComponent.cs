using Domain.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Infrastructure.Mappers;
using WebUI.Models;

namespace WebUI.Components
{
    public class DetailsStoreViewComponent : ViewComponent
    {
        IRequestsRepository repository;
        IMapper modelMapper;
        public DetailsStoreViewComponent(IRequestsRepository repository, IMapper modelMapper)
        {
            this.repository = repository;
            this.modelMapper = modelMapper;
        }
        public IViewComponentResult Invoke(int? id)
        {
            if (id == null)
            {
                return View(new List<RequestsStoreViewModel>());
            }
            var DetailsStoreViewComponent = (List<RequestsStoreViewModel>)modelMapper.Map(repository.RequestsStore.Where(r => r.Requests.RequestId == id).OrderBy(r => r.Date).ToList(), typeof(List<RequestsStore>), typeof(List<RequestsStoreViewModel>));
            return View(DetailsStoreViewComponent);
        }
    }
}
