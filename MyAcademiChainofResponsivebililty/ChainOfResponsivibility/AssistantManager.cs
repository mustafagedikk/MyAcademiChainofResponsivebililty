using MyAcademiChainofResponsivebililty.DataAccess.Context;
using MyAcademiChainofResponsivebililty.DataAccess.Entities;
using MyAcademiChainofResponsivebililty.Models;

namespace MyAcademiChainofResponsivebililty.ChainOfResponsivibility
{
    public class AssistantManager:Employee
    {
        private readonly CoFContext _context;

        public AssistantManager(CoFContext context)
        {
            _context = context;
        }

        public override void Process(CusterProcessViewModel request)
        {
            if (request.Price <= 100000)
            {
                var customerProcess = new CustomerProsess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Orhan Savaş - Müdür Yardımcısı",
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
                    EmployeeName = "Orhan Savaş - Müdür Yardımcıs",
                    Description = "Para çekme başarısız oldu , banka müdürüne yönlendirildi"
                };
                _context.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.Process(request);
            }
        }
    }
}
