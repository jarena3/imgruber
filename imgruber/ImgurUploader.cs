using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace imgruber
{
    public static class ImgurUploader
    {
        private const string ClientID = "cfeee1f745afe44";
        //private const string ClientSecret = "ca8636d59e11be038fd6f9baaa34a5f00e40ddc0";


        public static string Upload(Bitmap bmp)
        {
            byte[] byteArray;

            using (var stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }

            using (var w = new WebClient())
            {
                var values = new NameValueCollection
                {
                    {"image", Convert.ToBase64String(byteArray)}
                };

                w.Headers.Add("Authorization", "Client-ID " + ClientID);
                byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);

                string rstring = Encoding.Default.GetString(response);
                string link = XDocument.Parse(rstring).Descendants("link").Single().Value;
                Debug.WriteLine(link);

                return link;
            }
        }
    }
}