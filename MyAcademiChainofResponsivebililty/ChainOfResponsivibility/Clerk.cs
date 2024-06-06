using MyAcademiChainofResponsivebililty.DataAccess.Context;
using MyAcademiChainofResponsivebililty.DataAccess.Entities;
using MyAcademiChainofResponsivebililty.Models;

namespace MyAcademiChainofResponsivebililty.ChainOfResponsivibility
{
    public class Clerk:Employee
    {
        private readonly CoFContext _context;

        public Clerk(CoFContext context)
        {
            _context = context;
        }

        public override void Process(CusterProcessViewModel request)
        {
            if (request.Price<=50000)
            {
                var customerProcess = new CustomerProsess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Cemalettin Altıntaş - Gişe Memuru",
                    Description="Para çekme başarıyla gerçekleşti,para teslim edildi"
                };
                _context.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover!=null)
            {

                var customerProcess = new CustomerProsess
                {
                  
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Cemalettin Altıntaş - Gişe Memuru",
                     Description = "Para çekme başarısız oldu , banka müdür yardımcısına yönlendirildi"
                };
                _context.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.Process(request);
            }
        }
    }
}
