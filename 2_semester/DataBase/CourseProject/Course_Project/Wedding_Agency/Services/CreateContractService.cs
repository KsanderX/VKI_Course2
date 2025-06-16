using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    internal class CreateContractService : ICreateContractService
    {
        private WeddingAgencyContext _context;
        public CreateContractService(WeddingAgencyContext context)
        {
           _context = context;
        }

        public void AddBookingLocation(BookingLocation booking)
        {

            _context.BookingLocations.Add(booking);
            _context.SaveChanges();
        }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void AddContract(Contract contract)
        {
            _context.Contracts.Add(contract);
            _context.SaveChanges();
        }

        public void AddMenuCatering(MenuCatering menuCatering)
        {
            _context.MenuCaterings.Add(menuCatering);
            _context.SaveChanges();
        }

        public List<Client> GetAllClients()
        {
           return _context.Clients.ToList();
        }

        public List<DesignLocation> GetAllDesigns()
        {
            return _context.DesignLocations.ToList();
        }

        public List<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public List<Menu> GetAllMenus()
        {
            return _context.Menus.ToList();
        }
    }
}
