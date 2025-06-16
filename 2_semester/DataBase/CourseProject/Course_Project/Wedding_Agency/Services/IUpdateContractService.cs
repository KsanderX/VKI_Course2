using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    public interface IUpdateContractService
    {
        Contract? GetContractById(int id);
        List<Client> GetAllClients();
        List<Location> GetAllLocation();
        List<Menu> GetAllMenus();
        BookingLocation? GetBookingByContractId(int contractId);
        MenuCatering? GetMenuCateringByContractId(int contractId);
        void UpdateBookingLocation(BookingLocation bookingLocation);
        void UpdateMenuCatering(MenuCatering menuCatering);
        void UpdateContract(Contract contract);
    }
}
