using Microsoft.EntityFrameworkCore;
using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    internal class UpdateContractService : IUpdateContractService
    {
        private WeddingAgencyContext _context;
        public UpdateContractService(WeddingAgencyContext context)
        {
            _context = context;
        }
        public List<Client> GetAllClients()
        {
           return _context.Clients.ToList();
        }

        public List<Location> GetAllLocation()
        {
          return _context.Locations.ToList();
        }

        public List<Menu> GetAllMenus()
        {
            return _context.Menus.ToList();
        }

        public BookingLocation? GetBookingByContractId(int contractId)
        {
            return _context.BookingLocations
                .Include(bl => bl.FkLocationNavigation)
                .FirstOrDefault(bl => bl.FkContract == contractId);
        }

        public Contract? GetContractById(int id)
        {
            return _context.Contracts
                 .Include(c => c.FkClientNavigation)
                 .FirstOrDefault(c => c.IdContract == id);
        }

        public MenuCatering? GetMenuCateringByContractId(int contractId)
        {
            var catering = _context.Caterings
        .FirstOrDefault(c => c.FkContract == contractId);

            if (catering == null) return null;

            return _context.MenuCaterings
                .Include(mc => mc.FkMenuNavigation)
                .FirstOrDefault(mc => mc.FkCatering == catering.IdCatering);
        }

        public void UpdateBookingLocation(BookingLocation bookingLocation)
        {
            _context.BookingLocations.Update(bookingLocation);
            _context.SaveChanges();
        }

        public void UpdateContract(Contract contract)
        {
            _context.Contracts.Update(contract);
            _context.SaveChanges();
        }

        public void UpdateMenuCatering(MenuCatering menuCatering)
        {
            _context.MenuCaterings.Update(menuCatering);
            _context.SaveChanges();
        }
    }
}
