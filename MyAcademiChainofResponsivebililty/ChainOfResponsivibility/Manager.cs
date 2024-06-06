using MyAcademiChainofResponsivebililty.DataAccess.Context;
using MyAcademiChainofResponsivebililty.DataAccess.Entities;
using MyAcademiChainofResponsivebililty.Models;

namespace MyAcademiChainofResponsivebililty.ChainOfResponsivibility
{
    public class Manager:Employee
    {
        private readonly CoFContext _context;

        public Manager(CoFContext context)
        {
            _context = context;
        }

        public override void Process(CusterProcessViewModel request)
        {
            if (request.Price <= 250000)
            {
                var customerProcess = new CustomerProsess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Çağla Kıral - Şube Müdürü",
                    Description = "Para çekme başarıyla gerçekleşti,para teslim edildi"
                };
                _context.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {

                var customerProcess = new CustomerProsess
                {

                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Çağla Kıral - Şube Müdürü",
                    Description = "Para çekme başarısız oldu , bölge müdürüne yönlendirildi"
                };
                _context.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.Process(request);
            }
        }
    }
}
