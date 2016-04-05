using System;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAPITester
{
    class Program
    {
        private static string GetValue(IShellProperty value)
        {
            if (value == null || value.ValueAsObject == null)
            {
                return String.Empty;
            }
            return value.ValueAsObject.ToString();
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
                return;

            var filename = args[0];
            if (!System.IO.File.Exists(filename))
                return;

            ShellFile picture;
            picture = ShellFile.FromFilePath("F:\\testi\\nwmain.bmp"); 
            //picture = ShellObject.FromParsingName(filename);

            if (picture == null) return;

            var writer = picture.Properties.GetPropertyWriter();
            writer.WriteProperty(SystemProperties.System.Photo.CameraManufacturer, "test");
            writer.WriteProperty(SystemProperties.System.Keywords, "Koira; test 2");
            writer.Close();

            var camera = GetValue(picture.Properties.GetProperty(SystemProperties.System.Photo.CameraManufacturer));
            var cameraModel = GetValue(picture.Properties.GetProperty(SystemProperties.System.Photo.CameraModel));
            var formattedString = String.Format("File {0} has Manufacturer {1} and Model {2}",
                filename, camera, cameraModel);
            Console.WriteLine(formattedString);
            Console.ReadLine();
        }
    }
}
