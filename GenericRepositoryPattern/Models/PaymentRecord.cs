using System;

namespace GenericRepositoryPattern.Models
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime PayDate { get; set; }
        public string PayMonth { get; set; }
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal ContractualHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal ContractualEarnings { get; set; }
        public decimal OvertimeEarnings { get; set; }
        public decimal Tax { get; set; }
        public decimal NIC { get; set; }
        public decimal? UnionFee { get; set; }
        public decimal? SLC { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetPayment { get; set; }
    }
}