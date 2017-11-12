using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Concrete
{
    public class EFRequestsRepository : IRequestsRepository
    {

        private readonly EFDbContext  context;

        public EFRequestsRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<RequestsStore> RequestsStore { get { return context.RequestsStore.Include("Requests").Include("Statuses"); } }
        public IEnumerable<Requests> Requests { get { return context.Requests; } }
        public IEnumerable<Statuses> Statuses { get { return context.Statuses; } }

        public async Task AddRequest(RequestsStore requestsStore)
        {
            if (requestsStore.RequestId != 0)
            {
                requestsStore.Date = DateTime.Now;
                requestsStore.Requests = context.Requests.FirstOrDefault(r => r.RequestId == requestsStore.RequestId);
                if (requestsStore.StatusId == 4)
                {
                    requestsStore.Requests.ClosedDate = DateTime.Now;
                }
            }
            context.RequestsStore.Add(requestsStore);
            await context.SaveChangesAsync();
        }

        public async Task<Requests> GetRequest(int id)
        {
            return await context.Requests.FindAsync(id);
        }

        public async Task DeleteRequest(int id)
        {
            Requests model = await context.Requests.FindAsync(id);
            context.Requests.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task EditRequest(Requests requests)
        {

            context.Entry(requests).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
