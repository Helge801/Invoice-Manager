using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Air_Files.Models.SubModels;
using Custom_Air_Files.Models;
using System.Net;
using System.IO;
using Windows.Storage;
using SQLite;

namespace Custom_Air_Files.FunctionClasses
{
    class APIAccess
    {
        /// <summary>
        /// Asynce Proccesses passed address a to dowload image, save image, assign address to "Image" string in database for later access
        /// </summary>
        /// <param name="a">Address abject to be proccessed for map image</param>
        /// <param name="db">Database to update with address image containing new image uri</param>
        public static async void RetriveAddressImageAsync(Address a, SQLiteAsyncConnection db)
        {

            //TODO (low) handle no connection failer event.
            string AddressString = Uri.EscapeUriString(a.Line1 + " " + a.Line2 + " " + a.City + " " + a.State);
            string APIAddressString = "http://maps.googleapis.com/maps/api/staticmap?center=" + AddressString + "&zoom=13&scale=false&size=600x300&maptype=roadmap&format=png&visual_refresh=true&markers=size:mid%7Ccolor:0x0080ff%7Clabel:%7C" + AddressString;
            string ImageName = "Address" + a.Id.ToString() + ".png";
            string ImagesSubDir = "Resources\\AddressImages";
            string ImageLocation = "Resources/AddressImages/" + ImageName;

                var rootFolder = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFolderAsync(ImagesSubDir, CreationCollisionOption.OpenIfExists);
                var ImageFile = await rootFolder.CreateFileAsync(ImageName, CreationCollisionOption.ReplaceExisting);

            var httpWebRequest = HttpWebRequest.CreateHttp(APIAddressString);
            using ( HttpWebResponse response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            {
                Stream resStream = response.GetResponseStream();
                using (var stream = await ImageFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await Task.Delay(TimeSpan.FromSeconds(.25));
                    await resStream.CopyToAsync(stream.AsStreamForWrite());
                }
            }
            a.Image = ImageLocation;
            await db.UpdateAsync(a);
        }
    }
}
