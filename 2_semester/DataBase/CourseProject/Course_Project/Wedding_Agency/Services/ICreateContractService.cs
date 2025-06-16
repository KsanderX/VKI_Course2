using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    public interface ICreateContractService
    {
        List<Client> GetAllClients();
        List<Location> GetAllLocations();
        List<Menu> GetAllMenus();
        List<DesignLocation> GetAllDesigns();
        void AddContract(Contract contract);
        void AddClient(Client client);
        void AddBookingLocation(BookingLocation booking);
        void AddMenuCatering(MenuCatering menuCatering);
    }
}
