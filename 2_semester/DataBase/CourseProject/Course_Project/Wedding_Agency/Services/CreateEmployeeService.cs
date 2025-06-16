using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    internal class CreateEmployeeService : ICreateEmployeeService
    {
        private WeddingAgencyContext _context;
        public CreateEmployeeService(WeddingAgencyContext context)
        {
            _context = context;
        }
        public List<Position> GetAllPositions()
        {
            return _context.Positions.ToList();
        }

        public void AddEmployee(AgencyEmployee employee)
        {
            _context.AgencyEmployees.Add(employee);
            _context.SaveChanges();
        }
    }
}
