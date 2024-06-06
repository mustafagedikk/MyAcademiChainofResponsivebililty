using Microsoft.EntityFrameworkCore;
using MyAcademiChainofResponsivebililty.DataAccess.Entities;

namespace MyAcademiChainofResponsivebililty.DataAccess.Context
{
    public class CoFContext:DbContext
    {
        public CoFContext(DbContextOptions options):base(options)
        {
               
        }

        public DbSet<CustomerProsess> customerProsesses { get; set; }
    }
}
