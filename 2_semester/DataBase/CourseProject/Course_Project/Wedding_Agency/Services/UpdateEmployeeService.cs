using Microsoft.EntityFrameworkCore;
using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    internal class UpdateEmployeeService : IUpdateEmployeeService
    {
        private WeddingAgencyContext _context;
        public UpdateEmployeeService(WeddingAgencyContext context)
        {
            _context = context;
        }
        public List<Position> GetAllPositions()
        {
            return _context.Positions.ToList();
        }

        public AgencyEmployee? GetEmployeeById(int id)
        {
            return _context.AgencyEmployees
                 .Include(e => e.FkPositionNavigation)
                 .FirstOrDefault(e => e.IdAgencyEmployee == id);
        }

        public void UpdateEmployee(AgencyEmployee employee)
        {
            _context.AgencyEmployees.Update(employee);
            _context.SaveChanges();
        }
    }
}
