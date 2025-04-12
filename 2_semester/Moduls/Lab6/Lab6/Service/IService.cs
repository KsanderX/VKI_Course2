using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Service
{
    public interface IService
    {
        public void Save();
        public void AddRequest(Models.Request request);
        public List<Models.Request> GetRequests();
        public Models.Request GetRequestById(string id);
        public int GetRequestsCount();
        public int GetCompletedRequestsCount();
        public Dictionary<string, double> GetFaultStatistics();
        public bool Authorization(string login, string password);
    }
}
