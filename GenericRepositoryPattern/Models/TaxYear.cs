using System.Collections.Generic;

namespace GenericRepositoryPattern.Models
{
    public class TaxYear
    {
        public int Id { get; set; }
        public string YearOfTax { get; set; }
        public IEnumerable<PaymentRecord> PaymentRecords { get; set; }
    }
}