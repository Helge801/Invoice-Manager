using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Custom_Air_Files.Models;
using Custom_Air_Files.Models.SubModels;
using System.Threading;

namespace Custom_Air_Files.FunctionClasses
{
    class DatabaseAccess
    {
        public static void InitializeDatabase(SQLiteConnection db)
        {
            db.CreateTable<Customer>();
            db.CreateTable<Address>();
            db.CreateTable<Billing>();
            db.CreateTable<Discount>();
            db.CreateTable<InvoiceDiscount>();
            db.CreateTable<Expense>();
            db.CreateTable<Invoice>();
            db.CreateTable<Login>();
            db.CreateTable<Maintenance>();
            db.CreateTable<Payment>();
            db.CreateTable<PhoneNumber>();
            db.CreateTable<PriceBookItem>();
            db.CreateTable<InvoiceItem>();
            db.CreateTable<Proposal>();
            db.CreateTable<SavedPayment>();
            db.CreateTable<Setting>();
            db.CreateTable<Unit>();
            db.CreateTable<UnitComponent>();
            db.CreateTable<UnitImage>();
            db.CreateTable<Vendor>();
            db.CreateTable<AssBillingInvoice>();
            db.CreateTable<AssDiscountCustomer>();
            db.CreateTable<AssDiscountInvoice>();
            db.CreateTable<AssDiscountMaintenance>();
            db.CreateTable<AssPriceBookItemPriceBookItem>();
            db.CreateTable<AssProcedureMaintenance>();
            db.CreateTable<AssProcedurePriceBookItem>();
            db.CreateTable<AssTableClasses>();
            db.CreateTable<AssUnitMaintenance>();
            db.CreateTable<AssUnitInvoice>();
            db.CreateTable<AssAddressMaintenance>();
            db.CreateTable<Procedure>();
        }

        /// <summary>
        /// Asyncronously finds all addresses in database without an address im string. sends them to APIAccess.RetrieveAddressImage for proccessing
        /// </summary>
        /// <param name="dbAsync"></param>
        public static async void UpdateAddressImagesAsync(SQLiteAsyncConnection dbAsync)
        {
            List<Address> addresses = await dbAsync.Table<Address>().ToListAsync();

            foreach (Address a in addresses)
            {
                if (string.IsNullOrEmpty(a.Image))
                    APIAccess.RetriveAddressImageAsync(a,dbAsync);
            }
        }

    }
}
