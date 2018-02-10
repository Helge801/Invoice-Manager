using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Custom_Air_Files.Models;
using System.Drawing;
using System.IO;
using System.Globalization;
using Custom_Air_Files.Models.SubModels;

namespace Custom_Air_Files.FunctionClasses
{
    public static class PdfHelper
    {
        public static void SetGridBorderWidthByRow(PdfGridRow row,float left, float top, float right, float bottom)
        {
            int CellCount = row.Cells.Count;
            for (int i = 0; i < CellCount; i++)
            {
                row.Cells[i].Style.Borders.Left.Width = left;
                row.Cells[i].Style.Borders.Top.Width = top;
                row.Cells[i].Style.Borders.Right.Width = right;
                row.Cells[i].Style.Borders.Bottom.Width = bottom;
            }

        }
        public static void SetGridBorderWidthByRow(PdfGridRow row, float all)
        {
            int CellCount = row.Cells.Count;
            for (int i = 0; i < CellCount; i++)
            {
                row.Cells[i].Style.Borders.Left.Width = all;
                row.Cells[i].Style.Borders.Top.Width = all;
                row.Cells[i].Style.Borders.Right.Width = all;
                row.Cells[i].Style.Borders.Bottom.Width = all;
            }

        }
        public static void SetGridBorderBrushByRow(PdfGridRow row, PdfBrush left, PdfBrush top, PdfBrush right, PdfBrush bottom)
        {
            int CellCount = row.Cells.Count;
            for (int i = 0; i < CellCount; i++)
            {
                row.Cells[i].Style.Borders.Left.Brush = left;
                row.Cells[i].Style.Borders.Top.Brush = top;
                row.Cells[i].Style.Borders.Right.Brush = right;
                row.Cells[i].Style.Borders.Bottom.Brush = bottom;
            }
        }
        public static void SetGridBorderBrushByRow(PdfGridRow row, PdfBrush all)
        {
            int CellCount = row.Cells.Count;
            for (int i = 0; i < CellCount; i++)
            {
                row.Cells[i].Style.Borders.Left.Brush = all;
                row.Cells[i].Style.Borders.Top.Brush = all;
                row.Cells[i].Style.Borders.Right.Brush = all;
                row.Cells[i].Style.Borders.Bottom.Brush = all;
            }
        }
        public static void SetGridPaddingByRow(PdfGridRow row, float left, float top, float right, float bottom)
        {
            int CellCount = row.Cells.Count;
            for (int i = 0; i < CellCount; i++)
            {
                row.Cells[i].Style.CellPadding = new PdfPaddings(left, right, top, bottom);
            }
        }
        public static void SetGridPaddingByRow(PdfGridRow row, float Horizontal, float Virtical)
        {
            int CellCount = row.Cells.Count;
            for (int i = 0; i < CellCount; i++)
            {
                row.Cells[i].Style.CellPadding = new PdfPaddings(Horizontal,Horizontal,Virtical,Virtical);
            }
        }
        public static void SetGridPaddingByRow(PdfGridRow row, float all)
        {
            int CellCount = row.Cells.Count;
            for (int i = 0; i < CellCount; i++)
            {
                row.Cells[i].Style.CellPadding = new PdfPaddings(all,all,all,all);
            }
        }
        public static void SetGridTextAlignmentByRow(PdfGridRow row, PdfTextAlignment alignment)
        {
            int CellCount = row.Cells.Count;
            for (int i = 0; i < CellCount; i++)
            {
                row.Cells[i].StringFormat.Alignment = alignment;
            }
        }
        public static void SetGridBorderWidthByGrid(PdfGrid grid, float left, float top, float right, float bottom)
        {
            int RowCount = grid.Rows.Count;
            for (int r = 0; r < RowCount; r++)
            {
                int CellCount = grid.Rows[r].Cells.Count;
                for (int i = 0; i < CellCount; i++)
                {
                    grid.Rows[r].Cells[i].Style.Borders.Left.Width = left;
                    grid.Rows[r].Cells[i].Style.Borders.Top.Width = top;
                    grid.Rows[r].Cells[i].Style.Borders.Right.Width = right;
                    grid.Rows[r].Cells[i].Style.Borders.Bottom.Width = bottom;
                }
            }
        }
        public static void SetGridBorderWidthByGrid(PdfGrid grid, float all)
        {
            int RowCount = grid.Rows.Count;
            for (int r = 0; r < RowCount; r++)
            {
                int CellCount = grid.Rows[r].Cells.Count;
                for (int i = 0; i < CellCount; i++)
                {
                    grid.Rows[r].Cells[i].Style.Borders.Left.Width = all;
                    grid.Rows[r].Cells[i].Style.Borders.Top.Width = all;
                    grid.Rows[r].Cells[i].Style.Borders.Right.Width = all;
                    grid.Rows[r].Cells[i].Style.Borders.Bottom.Width = all;
                }
            }
        }
        public static void SetGridBorderBrushByGrid(PdfGrid grid, PdfBrush left, PdfBrush top, PdfBrush right, PdfBrush bottom)
        {
            int RowCount = grid.Rows.Count;
            for (int r = 0; r < RowCount; r++)
            {
                int CellCount = grid.Rows[r].Cells.Count;
                for (int i = 0; i < CellCount; i++)
                {
                    grid.Rows[r].Cells[i].Style.Borders.Left.Brush = left;
                    grid.Rows[r].Cells[i].Style.Borders.Top.Brush = top;
                    grid.Rows[r].Cells[i].Style.Borders.Right.Brush = right;
                    grid.Rows[r].Cells[i].Style.Borders.Bottom.Brush = bottom;
                }
            }
        }
        public static void SetGridBorderBrushByGrid(PdfGrid grid, PdfBrush all)
        {
            int RowCount = grid.Rows.Count;
            for (int r = 0; r < RowCount; r++)
            {
                int CellCount = grid.Rows[r].Cells.Count;
                for (int i = 0; i < CellCount; i++)
                {
                    grid.Rows[r].Cells[i].Style.Borders.Left.Brush = all;
                    grid.Rows[r].Cells[i].Style.Borders.Top.Brush = all;
                    grid.Rows[r].Cells[i].Style.Borders.Right.Brush = all;
                    grid.Rows[r].Cells[i].Style.Borders.Bottom.Brush = all;
                }
            }
        }
        public static void SetGridPaddingByGrid(PdfGrid grid, float left, float top, float right, float bottom)
        {
            int RowCount = grid.Rows.Count;
            for (int r = 0; r < RowCount; r++)
            {
                int CellCount = grid.Rows[r].Cells.Count;
                for (int i = 0; i < CellCount; i++)
                {
                    grid.Rows[r].Cells[i].Style.CellPadding = new PdfPaddings(left, right, top, bottom);
                }
            }
        }
        public static void SetGridPaddingByGrid(PdfGrid grid, float Horizontal, float Virtical)
        {
            int RowCount = grid.Rows.Count;
            for (int r = 0; r < RowCount; r++)
            {
                int CellCount = grid.Rows[r].Cells.Count;
                for (int i = 0; i < CellCount; i++)
                {
                    grid.Rows[r].Cells[i].Style.CellPadding = new PdfPaddings(Horizontal, Horizontal, Virtical, Virtical);
                }
            }
        }
        public static void SetGridPaddingByGrid(PdfGrid grid, float all)
        {
            int RowCount = grid.Rows.Count;
            for (int r = 0; r < RowCount; r++)
            {
                int CellCount = grid.Rows[r].Cells.Count;
                for (int i = 0; i < CellCount; i++)
                {
                    grid.Rows[r].Cells[i].Style.CellPadding = new PdfPaddings(all, all, all, all);
                }
            }
        }
        public static void SetGridTextAlignmentByGrid(PdfGrid grid, PdfTextAlignment alignment)
        {
            int RowCount = grid.Rows.Count;
            for (int r = 0; r < RowCount; r++)
            {
                int CellCount = grid.Rows[r].Cells.Count;
                for (int i = 0; i < CellCount; i++)
                {
                    grid.Rows[r].Cells[i].StringFormat.Alignment = alignment;
                }
            }
        }

        public static void CreatePdfFromInvoice(Invoice invoice)
        {
            Invoice ActiveInvoice = invoice;
            var AssUI = MainPage.db.Table<AssUnitInvoice>().Where(a => a.InvoiceId == ActiveInvoice.Id);
 //TODO: (Med) Fix the situation where there is no longer such thing as an AssPriceBookItem
            var AssDI = MainPage.db.Table<AssDiscountInvoice>().Where(d => d.IvoiceId == ActiveInvoice.Id);
            var AllAddress = MainPage.db.Table<Address>();
            var AllPBI = MainPage.db.Table<PriceBookItem>();
            var AllUnits = MainPage.db.Table<Unit>();
            var AllDiscounts = MainPage.db.Table<Discount>();
            var BillingAddressList = AllAddress.Where(a => a.Id == ActiveInvoice.BillingAddressId);
            Address JobAddress = AllAddress.Where(a => a.Id == ActiveInvoice.JobAddressId).First();
            Address BillingAddress;
            List<PriceBookItem> PBItems = new List<PriceBookItem>();
            List<Unit> Units = new List<Unit>();
            List<Discount> Discounts = new List<Discount>();

            if (BillingAddressList.Count() < 1)
                BillingAddress = JobAddress;
            else
                BillingAddress = BillingAddressList.First();
            Customer ActiveCustomer = MainPage.db.Table<Customer>().Where(c => c.Id == invoice.CustomerId).First();

            //foreach (AssPriceBookItemInvoice i in AssPI)
            //    PBItems.Add(AllPBI.Where(p => p.Id == i.PriceBookItemId).First());

            foreach (AssUnitInvoice u in AssUI)
                Units.Add(AllUnits.Where(a => a.Id == u.UnitId).First());

            foreach (AssDiscountInvoice d in AssDI)
                Discounts.Add(AllDiscounts.Where(a => a.Id == d.DiscountId).First());


            double total = 0;
            double RunningTotal = 0;
            float MoneyColumnWidth = 67;
            float QuantityColumnWidh = 11;
            float NameColumnWidth = 178;
            PdfStandardFont ItemFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Regular);
            float HeightRemaining = 444; //Full length is 725 //TODO possibly make this automated so that we can use it to make sure the total is at the bottom of the page too
            float WidthRemaining; //This is actually 514 for full reach
            //original A4 size gives you about 514 width and 725 height to work with inside of the margins
            //Im adjusting the the Left and Right Margins down to 15pt. Margins were originally 40 so that should gave me about 50 extra points of width
            //so I'm assuming 564 as width now??? 


            string FolderPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Resources");
            PdfGridRow RowAccess;
            PdfDocument document = new PdfDocument();
            document.PageSettings.Size = PdfPageSize.A4;
            WidthRemaining = document.PageSettings.Width - document.PageSettings.Margins.Left - document.PageSettings.Margins.Right - 2;
            PdfPage page1 = document.Pages.Add();
            PdfFont TitleFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 45);
            PdfFont InvoiceNumberFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);
            PdfFont GridTitleFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
            PdfImage logoimage = new PdfBitmap(File.Open(Path.Combine(FolderPath, "CA_Logo.jpeg"), FileMode.Open));
            page1.Graphics.DrawImage(logoimage, new RectangleF(new PointF(3, 0), new SizeF(166, 125)));
            page1.Graphics.DrawString("INVOICE", TitleFont, PdfBrushes.Black, new PointF(250, 0));
            page1.Graphics.DrawString("Custom Air, P.O. Box 572492 Salt Lake City UT, 84157", new PdfStandardFont(PdfFontFamily.TimesRoman, 8, PdfFontStyle.Italic), PdfBrushes.Black, new PointF(0, 113));
            page1.Graphics.DrawString("(801)548-5444, BeckyTLund@Gmail.com", new PdfStandardFont(PdfFontFamily.TimesRoman, 8, PdfFontStyle.Italic), PdfBrushes.Black, new PointF(16, 124));

            PdfGrid AddressGrid = new PdfGrid();
            AddressGrid.Columns.Add(2);
            AddressGrid.Columns[0].Width = 140;
            AddressGrid.Columns[1].Width = 140;
            RowAccess = AddressGrid.Rows.Add(); //New Row
            RowAccess.Cells[0].Value = "Job Address:";
            RowAccess.Cells[1].Value = "Billing:";
            RowAccess.Style.Font = GridTitleFont;
            RowAccess = AddressGrid.Rows.Add(); //New Row
            RowAccess.Cells[0].Value = $"{JobAddress.Line1} {JobAddress.Line2}";
            RowAccess.Cells[1].Value = $"{BillingAddress.Line1} {BillingAddress.Line2}";
            RowAccess.Cells[0].StringFormat.Alignment = PdfTextAlignment.Center;
            RowAccess.Cells[1].StringFormat.Alignment = PdfTextAlignment.Center;
            RowAccess = AddressGrid.Rows.Add(); //New Row
            RowAccess.Cells[0].Value = $"{JobAddress.City} {JobAddress.State}, {JobAddress.Zip}";
            RowAccess.Cells[1].Value = $"{BillingAddress.City} {BillingAddress.State}, {BillingAddress.Zip}";
            RowAccess.Cells[0].StringFormat.Alignment = PdfTextAlignment.Center;
            RowAccess.Cells[1].StringFormat.Alignment = PdfTextAlignment.Center;
            PdfHelper.SetGridPaddingByGrid(AddressGrid, 0);
            PdfHelper.SetGridBorderBrushByGrid(AddressGrid, PdfBrushes.Transparent);

            PdfGrid DateGrid = new PdfGrid();
            DateGrid.Columns.Add().Width = 100;
            DateGrid.Columns.Add().Width = 100;
            DateGrid.Columns.Add().Width = 100;
            RowAccess = DateGrid.Rows.Add(); //New Row
            PdfHelper.SetGridPaddingByRow(RowAccess, 0, 5, 0, 0);
            PdfHelper.SetGridTextAlignmentByRow(RowAccess, PdfTextAlignment.Center);
            RowAccess.Cells[0].Value = "Date Of Order:";
            RowAccess.Cells[1].Value = "Start Date:";
            RowAccess.Cells[2].Value = "Completed:";
            RowAccess.Style.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);
            RowAccess = DateGrid.Rows.Add(); // New Row
            if (ActiveInvoice.DateOfOrder > DateTime.Today.AddYears(-100))
                RowAccess.Cells[0].Value = ActiveInvoice.DateOfOrder.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            if (ActiveInvoice.StartDate > DateTime.Today.AddYears(-100))
                RowAccess.Cells[1].Value = ActiveInvoice.StartDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            if (ActiveInvoice.CompletionDate > DateTime.Today.AddYears(-100))
                RowAccess.Cells[2].Value = ActiveInvoice.CompletionDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            PdfHelper.SetGridTextAlignmentByRow(RowAccess, PdfTextAlignment.Center);
            PdfHelper.SetGridBorderBrushByGrid(DateGrid, PdfBrushes.Transparent);


            PdfGrid InfoGrid = new PdfGrid();
            InfoGrid.Columns.Add(1);
            InfoGrid.Columns[0].Width = 300;
            RowAccess = InfoGrid.Rows.Add();
            RowAccess.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            RowAccess.Cells[0].Value = $"Customer: {ActiveCustomer.FirstName} {ActiveCustomer.LastName}  Invoice#  {ActiveInvoice.InvoiceNumber.ToString()}";
            RowAccess.Cells[0].Style.Font = InvoiceNumberFont;
            RowAccess = InfoGrid.Rows.Add();
            RowAccess.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            RowAccess.Cells[0].Value = AddressGrid;
            RowAccess = InfoGrid.Rows.Add();
            RowAccess.Cells[0].Value = DateGrid;
            PdfHelper.SetGridPaddingByGrid(InfoGrid, 0);
            PdfHelper.SetGridBorderBrushByGrid(InfoGrid, PdfBrushes.Transparent);
            InfoGrid.Rows[1].Cells[0].Style.Borders.Bottom.Brush = PdfBrushes.Black;

            InfoGrid.Draw(page1.Graphics, new PointF(200, 55));


            PdfGrid UnitsGrid = new PdfGrid();
            UnitsGrid.Style.Font = ItemFont;
            UnitsGrid.Style.CellPadding.All = 2;
            UnitsGrid.Columns.Add(4);
            UnitsGrid.Columns[0].Width = WidthRemaining / 4;
            UnitsGrid.Columns[1].Width = WidthRemaining / 4;
            UnitsGrid.Columns[2].Width = WidthRemaining / 4;
            UnitsGrid.Columns[3].Width = WidthRemaining - ((WidthRemaining / 4) * 3);
            foreach (Unit u in Units)
            {
                RowAccess = UnitsGrid.Rows.Add();
                RowAccess.Cells[0].Value = u.Name;
                RowAccess.Cells[1].Value = u.Type;
                RowAccess.Cells[2].Value = $"M#: {u.ModelNumber}";
                RowAccess.Cells[3].Value = $"S#: {u.serialNumber}";
            }
            PdfHelper.SetGridBorderBrushByGrid(UnitsGrid, PdfBrushes.Transparent);

            PdfGrid DescriptionGrid = new PdfGrid();
            DescriptionGrid.Style.Font = ItemFont;
            DescriptionGrid.Columns.Add(1);
            DescriptionGrid.Columns[0].Width = WidthRemaining;
            RowAccess = DescriptionGrid.Rows.Add();
            RowAccess.Height = 100;
            RowAccess.Cells[0].Value = ActiveInvoice.Description;
            RowAccess.Cells[0].Style.Borders.All = new PdfPen(PdfBrushes.Transparent, 0);

            PdfGrid PartsGrid = new PdfGrid();
            PartsGrid.Style.Font = ItemFont;
            PartsGrid.Columns.Add(4);
            PartsGrid.Columns[0].Width = QuantityColumnWidh;
            PartsGrid.Columns[1].Width = NameColumnWidth - QuantityColumnWidh;
            PartsGrid.Columns[2].Width = WidthRemaining - NameColumnWidth - MoneyColumnWidth;
            PartsGrid.Columns[3].Width = MoneyColumnWidth;
            foreach (PriceBookItem i in PBItems)
            {
                //int q = AssPI.Where(a => a.PriceBookItemId == i.Id).First().Quantity;
                //RowAccess = PartsGrid.Rows.Add();
                //RowAccess.Cells[0].Value = " " + q.ToString();
                //RowAccess.Cells[1].Value = " " + i.Name;
                //RowAccess.Cells[2].Value = " " + i.Description;
                //RowAccess.Cells[3].Value = " " + $"${(i.Amount * q).ToString("N2")} ";
                //RowAccess.Cells[3].Style.StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
                //total += i.Amount * q;
                //RunningTotal = total;
            }
            PdfHelper.SetGridBorderBrushByGrid(PartsGrid, PdfBrushes.Transparent);

            PdfGrid DiscountsGrid = new PdfGrid();
            DiscountsGrid.Style.Font = ItemFont;
            DiscountsGrid.Columns.Add(3);
            DiscountsGrid.Columns[0].Width = NameColumnWidth;
            DiscountsGrid.Columns[1].Width = WidthRemaining - NameColumnWidth - MoneyColumnWidth;
            DiscountsGrid.Columns[2].Width = MoneyColumnWidth;
            foreach (Discount d in Discounts)
            {
                RowAccess = DiscountsGrid.Rows.Add();
                RowAccess.Cells[0].Value = " " + d.Name;
                RowAccess.Cells[1].Value = " " + d.Notes;

                if (d.Type == Discount.DiscountType.Percentage)
                {
                    double amount = total * (d.Amount * 0.01);
                    RowAccess.Cells[2].Value = $"-${amount.ToString("N2")} ";
                    RunningTotal += -amount;
                }
                else
                {
                    RowAccess.Cells[2].Value = $"${d.Amount.ToString("N2")} ";
                    RunningTotal += -d.Amount;
                }
                RowAccess.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
            }
            PdfHelper.SetGridBorderBrushByGrid(DiscountsGrid, PdfBrushes.Transparent);
            //PdfHelper.SetGridBorderWidthByGrid(DiscountsGrid, 0, 1, 0, 1);

            PdfGrid TotalGrid = new PdfGrid();
            TotalGrid.Style.Font = ItemFont;
            TotalGrid.Columns.Add().Width = WidthRemaining - (MoneyColumnWidth * 2);
            TotalGrid.Columns.Add().Width = MoneyColumnWidth;
            TotalGrid.Columns.Add().Width = MoneyColumnWidth;
            RowAccess = TotalGrid.Rows.Add();
            RowAccess.Cells[1].Value = " Total";
            RowAccess.Cells[2].Value = $" ${RunningTotal.ToString("N2")} ";
            RowAccess.Cells[2].Style.StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
            PdfHelper.SetGridBorderBrushByRow(RowAccess, PdfBrushes.Transparent);





            PdfGrid ContentGrid = new PdfGrid();
            ContentGrid.Columns.Add(1);
            ContentGrid.Columns[0].Width = WidthRemaining + 1;
            RowAccess = ContentGrid.Rows.Add();
            RowAccess.Cells[0].Value = " Units";
            RowAccess.Style.Font = GridTitleFont;
            RowAccess.Cells[0].Style.Borders.All = new PdfPen(PdfBrushes.Black, 0);

            RowAccess = ContentGrid.Rows.Add();
            RowAccess.Cells[0].Value = UnitsGrid;
            RowAccess.Cells[0].Style.Borders.All = new PdfPen(PdfBrushes.Transparent, 0);
            RowAccess.Cells[0].Style.CellPadding = new PdfPaddings(0, 0, 0, 10);

            RowAccess = ContentGrid.Rows.Add();
            RowAccess.Cells[0].Value = " Description of Work";
            RowAccess.Style.Font = GridTitleFont;
            RowAccess.Cells[0].Style.Borders.All = new PdfPen(PdfBrushes.Black, 0);

            RowAccess = ContentGrid.Rows.Add();
            RowAccess.Cells[0].Value = DescriptionGrid;
            RowAccess.Cells[0].Style.Borders.All = new PdfPen(PdfBrushes.Transparent, 0);

            RowAccess = ContentGrid.Rows.Add();
            RowAccess.Cells[0].Value = " Parts and Labor";
            RowAccess.Style.Font = GridTitleFont;
            RowAccess.Cells[0].Style.Borders.All = new PdfPen(PdfBrushes.Black, 0);

            RowAccess = ContentGrid.Rows.Add();
            RowAccess.Cells[0].Value = PartsGrid;
            RowAccess.Cells[0].Style.Borders.All = new PdfPen(PdfBrushes.Transparent, 0);
            RowAccess.Cells[0].Style.CellPadding = new PdfPaddings(0, 0, 0, 10);

            RowAccess = ContentGrid.Rows.Add();
            RowAccess.Cells[0].Value = " Discounts";
            RowAccess.Style.Font = GridTitleFont;
            RowAccess.Cells[0].Style.Borders.All = new PdfPen(PdfBrushes.Black, 0);

            RowAccess = ContentGrid.Rows.Add();
            RowAccess.Cells[0].Value = DiscountsGrid;
            RowAccess.Cells[0].Style.Borders.All = new PdfPen(PdfBrushes.Transparent, 0);




            ContentGrid.Draw(page1.Graphics, new PointF(0, 161));
            TotalGrid.Draw(page1.Graphics, new PointF(0, 725));

            //TODO fix these streams, I dont think the dispose when the are done which blocks access to the created resource AKA the new PDF
            document.Save(File.Create(Path.Combine(FolderPath, "Invoice.PDF")));
            document.Close();
        }

    }
}
