using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Custom_Air_Files.Models.SubModels
{
    public class AssTableClasses
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int ProposalId { get; set; }
        [NotNull]
        public int DiscountId { get; set; }
    }

    public class AssProcedureMaintenance
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int MaintenanceId { get; set; }
        [NotNull]
        public int ProcedureId { get; set; }
    } 

    public class AssDiscountCustomer
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        [NotNull]
        public int DiscountId { get; set; }
    }

    public class AssBillingInvoice
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int InvoiceId { get; set; }
        [NotNull]
        public int BillingId { get; set; }
    }

    public class AssDiscountInvoice
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int IvoiceId { get; set; }
        [NotNull]
        public int DiscountId { get; set; }
    }

    public class AssProcedurePriceBookItem
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int PriceBookItemId { get; set; }
        [NotNull]
        public int ProcedureId { get; set; }
    }

    public class AssPriceBookItemPriceBookItem
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int ParentPriceBookItem { get; set; }
        [NotNull]
        public int ChildPriceBookItem { get; set; }
    }

    public class AssDiscountMaintenance
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int MaintenanceId { get; set; }
        [NotNull]
        public int DiscountId { get; set; }
    }

    public class AssUnitMaintenance
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int MaintenanceId { get; set; }
        [NotNull]
        public int UnitId { get; set; }
    }

    public class AssUnitInvoice
    {
        [PrimaryKey,AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int InvoiceId { get; set; }
        [NotNull]
        public int UnitId { get; set; }
    }

    public class AssAddressMaintenance
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int MaintenanceId { get; set; }
        [NotNull]
        public int AddressId { get; set; }
    }
}
