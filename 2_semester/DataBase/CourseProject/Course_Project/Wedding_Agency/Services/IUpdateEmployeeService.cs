using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    public interface IUpdateEmployeeService
    {
        AgencyEmployee? GetEmployeeById(int id);
        List<Position> GetAllPositions();
        void UpdateEmployee(AgencyEmployee employee);
    }
}
