using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    public interface ICreateEmployeeService
    {
        List<Position> GetAllPositions();
        void AddEmployee(AgencyEmployee employee);
    }
}
