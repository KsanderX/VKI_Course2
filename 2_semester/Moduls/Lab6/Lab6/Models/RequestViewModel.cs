using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public class RequestViewModel
    {
        public List<Master> Masters { get; set; }
        public List<RequestStatus> RequestStatuses { get; set; }
        public List<EquipmentType> EquipmentTypes { get; set; }
        public Request Request { get; set; }

        public RequestViewModel()
        {
            LoadMasters();
            LoadRequestsStatus();
            LoadEquipmentTypes();
            Request = new Request();
        }

        private void LoadMasters()
        {
            using (var context = new MyDbContext())
            {
                Masters = context.Masters.ToList();
            }
        }

        private void LoadRequestsStatus()
        {
            using (var context = new MyDbContext())
            {
                RequestStatuses = context.RequestStatuses.ToList();
            }
        }

        private void LoadEquipmentTypes()
        {
            using (var context = new MyDbContext())
            {
                EquipmentTypes = context.EquipmentTypes.ToList();
            }
        }
    }
}
