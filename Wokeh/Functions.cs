using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows;

namespace Wokeh
{
    class Functions
    {
        public string encodeHTML()
        {
            string text = Clipboard.GetText();
            string enc = WebUtility.HtmlEncode(text);
            Clipboard.SetText(enc);
            return enc;
        }
        public string decodeHTML()
        {
            string text = Clipboard.GetText();
            string dec = WebUtility.HtmlDecode(text);
            Clipboard.SetText(dec);
            return dec;
        }
        public string toBase64()
        {
            OpenFileDialog dOpen = new OpenFileDialog();
            dOpen.Filter = "Image Files|*.bmp;*.png;*.jpg;*.jpeg;*.gif;";
            Nullable<bool> y = dOpen.ShowDialog();
            if (y == true)
            {
                string loc = dOpen.FileName;
                string ext = Path.GetExtension(loc).Replace(".", "");

                using (Image img = Image.FromFile(loc))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, img.RawFormat);
                        byte[] imgBytes = ms.ToArray();
                        string imgString = "data:image/"+ext+";base64," + Convert.ToBase64String(imgBytes);
                        Clipboard.SetText(imgString);
                        return imgString;
                    }
                }
            }
            else
            {
                return "No image Selected";
            }
        }
    }
}
