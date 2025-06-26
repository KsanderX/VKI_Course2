using System.Collections.ObjectModel;
using exam.Models;
using exam.Services;

namespace exam.ViewModel
{
    public class RequestAdminViewModel 
    {
        private IRequestService _requestService;
        public ObservableCollection<Request> Requests { get; set; }       
        public Request SelectedRequest { get; set; }    
        
        public RequestAdminViewModel(IRequestService service)
        {
            _requestService = service;
            Requests = _requestService.GetAllRequests();
        }

        public void UpdateCollection()
        {
            Requests = _requestService.GetAllRequests();
        }
    }
}