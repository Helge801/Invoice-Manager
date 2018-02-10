using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Custom_Air_Files.Models.SubModels
{
    public class CustomerTile
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Att { get; set; }
        public string AttImage { get; set; }
        public string City { get; set; }
        public string Image { get; set; }

        public CustomerTile(Customer customer, SQLiteConnection db)
        {
            Att = false;
            AttImage = "none";
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            SetImageAndCity(db);


        }

        private void SetImageAndCity(SQLiteConnection db)
        {
            var q = db.Table<Address>().Where(v => v.CustomerId == this.Id);
            if (q.Count() < 1)
            {
                City = "";
                Image = "ms-appx:///Assets/Images/NoCustomerImage.png";
                AttImage = "ms-appx:///Assets/Images/AttImage.png";
                Att = true;
            }
            else
            {
                var r = q.Where(v => v.IsBilling == true);
                if (r.Count() < 1)
                {
                    Address address = q.First();
                    City = address.City;
                    Image = Windows.Storage.ApplicationData.Current.LocalFolder.Path + "/" + address.Image;
                }
                else
                {
                    Address address = r.First();
                    City = address.City;
                    Image = address.Image;
                }
            }
        }

    }
}
