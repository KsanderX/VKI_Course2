using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime CompletionDate {  get; set; } = DateTime.Now;
        public string CarModel { get; set; }
        public string ProblemDescription { get; set; }
        public string ClientFullName { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string MasterComment { get; set; }
        public int MasterId { get; set; }
        public int RequestStatusId { get; set; } = 1;
        public int CarTypeId { get; set; }
        public Master Master { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public CarType CarType { get; set; }
    }
}
