using MyAcademiChainofResponsivebililty.Models;

namespace MyAcademiChainofResponsivebililty.ChainOfResponsivibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;

        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;
        }

        public abstract void Process(CusterProcessViewModel request);
    }
}
