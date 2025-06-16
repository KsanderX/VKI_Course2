using Wedding_Agency.Models;

namespace Wedding_Agency.Services
{
    internal class DeleteEmployeeService : IDeleteEmployeeService
    {
        private WeddingAgencyContext _context;
        public DeleteEmployeeService(WeddingAgencyContext context)
        {
            _context = context;
        }
        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.AgencyEmployees
                .FirstOrDefault(e => e.IdAgencyEmployee == employeeId);

            if (employee != null)
            {
                var links = _context.WeddingAgencyEmployees
                    .Where(w => w.FkAgencyEmployee == employeeId)
                    .ToList();

                _context.WeddingAgencyEmployees.RemoveRange(links);

                _context.AgencyEmployees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
