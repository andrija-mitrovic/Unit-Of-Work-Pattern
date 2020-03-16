using GenericRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Data.Repository
{
    public class PaymentRecordRepository:Repository<PaymentRecord>,IPaymentRecord
    {
        public PaymentRecordRepository(ApplicationDbContext context) : base(context) { }
    }
}
