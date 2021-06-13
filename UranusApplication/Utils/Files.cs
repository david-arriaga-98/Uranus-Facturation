using System;
using System.Drawing;
using System.IO;

namespace ProyectoPuntoNet.Utils
{
    public static class Files
    {
        public static string filesPath = @"C:\ProyectoParcial\Assets";

        public static void DeleteImage(string folder, string fileName)
        {
            try
            {
                string filePath = string.Format(@"{0}\Images\{1}\{2}", filesPath, folder, fileName);
                if (File.Exists(filePath)) File.Delete(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SaveImage(Stream stream, string folder, string name, string ext)
        {
            try
            {
                string folderPath = string.Format(@"{0}\Images\{1}", filesPath, folder);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                using (Stream fileStream = stream)
                {
                    using (Image image = Image.FromStream(stream))
                    {
                        string imagePath = string.Format(folderPath + @"\{0}{1}", name, ext);
                        image.Save(imagePath);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Image GetImage(string folder, string fileName)
        {
            try
            {
                string filePath = string.Format(@"{0}\Images\{1}\{2}", filesPath, folder, fileName);
                if (File.Exists(filePath))
                {
                    using (Bitmap bitmap = new Bitmap(filePath))
                    {
                        Image img = new Bitmap(bitmap);
                        return img;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
