using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TagTest
{
    class WinAPITest
    {
        private static string GetValue(IShellProperty value)
        {
            if (value == null || value.ValueAsObject == null)
            {
                return String.Empty;
            }
            return value.ValueAsObject.ToString();
        }

        public static void SetTags(string filename)
        {
            try
            {
                ShellObject picture = ShellObject.FromParsingName(filename);
                var writer = picture.Properties.GetPropertyWriter();
                writer.WriteProperty(SystemProperties.System.Keywords, "test 1; test 2");
                writer.Close();          

            }
            catch (Exception ex)
            {

                throw ex;
            }
                
        }
        public static void FormatJPEG(string filename)
        {
            System.Drawing.Image image1 = System.Drawing.Image.FromFile("@F:\\nwmain.bmp");
            image1.Save(@"C:\testi.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
