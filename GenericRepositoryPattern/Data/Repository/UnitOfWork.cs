using GenericRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IEmployeeRepository _employeeRepo;
        private IPaymentRecord _paymentRecordRepo;
        private IRepository<TaxYear> _taxYearRepo;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEmployeeRepository EmployeeRepo 
        {
            get => _employeeRepo = _employeeRepo ?? new EmployeeRepository(_context);
        }
        public IPaymentRecord PaymentRecordRepo 
        {
            get => _paymentRecordRepo = _paymentRecordRepo ?? new PaymentRecordRepository(_context);
        }
        public IRepository<TaxYear> TaxYearRepo 
        {
            get => _taxYearRepo = _taxYearRepo ?? new Repository<TaxYear>(_context);
        }

        public void Dispose() => _context.Dispose();

        public int Save() => _context.SaveChanges();
    }
}
