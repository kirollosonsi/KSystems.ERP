using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace K_Systems.Presentation.Web.Helper
{
    public static class FileManipulation
    {
        internal static string SavePhoto(HttpPostedFileBase file, string path)
        {
            if (file == null || string.IsNullOrEmpty(path))
                return null;

            try
            {
                string fileName = $"{DateTime.Now.ToString("yyyymmddhhMMssfff")}{Path.GetExtension(file.FileName)}";
                file.SaveAs(Path.Combine(path, fileName));
                return fileName;
            }
            catch (Exception)
            {
                return null;
            }

        }

        internal static bool DeletePhoto(string serverPath, string imagName)
        {
            if (string.IsNullOrEmpty(imagName))
                return true;
            try
            {
                File.Delete(Path.Combine(serverPath, imagName));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static string GetFileName(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;
            return Path.GetFileName(filePath);
        }

        internal static string GetFileFullPath(string path , string fileName)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(fileName))
                return null;
            return Path.Combine(path, fileName);
        }
    }


}