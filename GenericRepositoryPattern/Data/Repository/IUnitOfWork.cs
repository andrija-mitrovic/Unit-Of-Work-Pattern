using GenericRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Data.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IEmployeeRepository EmployeeRepo { get; }
        IPaymentRecord PaymentRecordRepo { get; }
        IRepository<TaxYear> TaxYearRepo { get; }
        int Save();
    }
}
