using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using Custom_Air_Files.FunctionClasses;

namespace Custom_Air_Files.Models
{
    public class Address
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        [NotNull]
        public string Image { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        [NotNull]
        public string City { get; set; }
        [NotNull]
        public string State { get; set; }
        public int Zip { get; set; }
        [NotNull]
        public bool IsBilling { get; set; }
        public string Notes { get; set; }
    }

    public class Billing
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        [NotNull]
        public int InvoiceId { get; set; }
        [NotNull]
        public DateTime IssueDate { get; set; }
        [NotNull]
        public DateTime DueDate { get; set; }
        [NotNull]
        public double DueAmount { get; set; }
        public string Notes { get; set; }
    }

    public class Customer
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [MaxLength(15), NotNull]
        public string FirstName { get; set; }
        [MaxLength(15)]
        public string LastName { get; set; }
        public string Image { get; set; }

        //TODO (low) generate areal image from all addresses combined using new api access method but be able to flagg changes if address are changed or added
    }

    public class Discount
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public DiscountType Type { get; set; }
        [NotNull]
        public double Amount { get; set; }
        public string Notes { get; set; }

        public enum DiscountType { Percentage = 0, Amount = 1}
    }

    public class InvoiceDiscount
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int InvoiceId { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public Discount.DiscountType Type { get; set; }
        [NotNull]
        public double Amount { get; set; }
        public string Notes { get; set; }

    }

    public class Expense
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceId { get; set; }
        [NotNull]
        public string PaymentMethod { get; set; }
        [NotNull]
        public double Amount { get; set; }
        [NotNull]
        public DateTime Date { get; set; }
        [NotNull]
        public string Catagory { get; set; }
        public int VendorID { get; set; }

    }

    public class Invoice
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        public int ProposalId { get; set; }
        [NotNull]
        public int InvoiceNumber { get; set; }
        public string JobName { get; set; }
        [NotNull]
        public DateTime DateOfOrder { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        [NotNull]
        public int JobAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public string Description { get; set; }
        [NotNull]
        public double Total { get; set; }
        public int MaintenanceId { get; set; }
    }

    public class Login
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [Unique, NotNull]
        public string UserName { get; set; }
        [NotNull]
        public string Password { get; set; }

    }

    public class Maintenance
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        [NotNull]
        public string Image { get; set; }
        public string JobName { get; set; }
        [NotNull]
        public DateTime StartDate { get; set; }
        [NotNull]
        public DateTime InitialService { get; set; }
        public DateTime Expiration { get; set; }
        [NotNull]
        public string type { get; set; }
        [NotNull]
        public string BillingType { get; set; }

        //Maintenance()
        //{
        //    Image = "Assets\\Images\\NoAddressImage.png";
        //}
    }

    public class Payment
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        [NotNull]
        public int InvoiceId { get; set; }
        [NotNull]
        public DateTime Date { get; set; }
        [NotNull]
        public double Amount { get; set; }
        [NotNull]
        public string Type { get; set; }
        public string Notes { get; set; }
    }

    public class PhoneNumber
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public int AreaCode { get; set; }
        [NotNull]
        public int Number { get; set; }
        public int Extention { get; set; }
        public string Notes { get; set; }
    }

    public class PriceBookItem
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public bool Regular { get; set; }
        [NotNull]
        public String Name { get; set; }
        public String Description { get; set; }
        [NotNull]
        public string Image { get; set; }
        [NotNull]
        public double Amount { get; set; }
    }

    public class InvoiceItem
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int InvoiceId { get; set; }
        [NotNull]
        public String Name { get; set; }
        public String Description { get; set; }
        [NotNull]
        public double Amount { get; set; }
    }

    public class Proposal
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        public string JobName { get; set; }
        [NotNull]
        public DateTime Date { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        [NotNull]
        public int AddressId { get; set; }
        [NotNull]
        public string Description { get; set; }
        [NotNull]
        public double Total { get; set; }
        [NotNull]
        public PropStat Status { get; set; }

        public enum PropStat { Pending, Accepted, Rejected };
    }

    public class SavedPayment
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; }
        [NotNull]
        public string Information { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
    }

    public class Setting
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull, Unique]
        public string Name { get; set; }
        [NotNull]
        public int State { get; set; }
    }

    public class Unit
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        [NotNull]
        public int AddressId { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string Type { get; set; }
        public string ModelNumber { get; set; }
        public string serialNumber { get; set; }
        [NotNull]
        public bool IsActive { get; set; }

    }

    public class UnitComponent
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int UnitId { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UnitImage
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Description { get; set; }
        [NotNull]
        public string Image { get; set; }
        [NotNull]
        public int UnitId { get; set; }

        //UnitImage()
        //{
        //    if (String.IsNullOrEmpty(Image))
        //        Image = "Assets\\Images\\NoUnitImage.png";
        //}
    }

    public class Vendor
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
    }

    public class Procedure
    {
        [PrimaryKey, Unique, AutoIncrement, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string DisplayName { get; set; }
        [NotNull]
        public string Instruction { get; set; }
    }
}
