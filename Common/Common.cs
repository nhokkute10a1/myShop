using System;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.IO;

namespace LibCommon
{
    public static  class Common
    {
        /*==Convert-Base64-To-Image==*/

        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            Bitmap tempBmp;
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                using (Image image = Image.FromStream(ms, true))
                {
                    //Create another object image for dispose old image handler
                    tempBmp = new Bitmap(image.Width, image.Height);
                    Graphics g = Graphics.FromImage(tempBmp);
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
                }
            }
            return tempBmp;
        }

        /*==Risize-Image==*/

        public static Image ResizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();
            return b;
        }

        public static Image ResizeImageCover(Image img, int width, int height)
        {
            var ratioX = (double)width / img.Width;
            var ratioY = (double)height / img.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(img.Width * ratio);
            var newHeight = (int)(img.Height * ratio);

            Bitmap b = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, newWidth, newHeight);
            g.Dispose();
            return b;
        }

        /*==MD5==*/

        public static string ToMD5(this string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }

        public static object ResizeImage(Image image, object widthWeb, object heightWeb)
        {
            throw new NotImplementedException();
        }
    }
}