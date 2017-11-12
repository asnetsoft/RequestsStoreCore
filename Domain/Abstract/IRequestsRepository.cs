using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IRequestsRepository
    {
        IEnumerable<RequestsStore> RequestsStore { get; }
        IEnumerable<Requests> Requests { get; }
        IEnumerable<Statuses> Statuses { get; }

        Task AddRequest(RequestsStore requestsStore);
        Task<Requests> GetRequest(int id);
        Task EditRequest(Requests requests);
        Task DeleteRequest(int id);

    }
}
