using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace imgruber
{
    public static class ImgurUploader
    {

        const string ClientID = "cfeee1f745afe44";
        const string ClientSecret = "ca8636d59e11be038fd6f9baaa34a5f00e40ddc0";


        public static string Upload(Bitmap bmp)
        {
            byte[] byteArray = new byte[0];

            using (MemoryStream stream = new MemoryStream())
            {
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
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

                var rstring = Encoding.Default.GetString(response);
                var link = XDocument.Parse(rstring).Descendants("link").Single().Value;
                Debug.WriteLine(link);

                return link;
            }

        }

    }
}
