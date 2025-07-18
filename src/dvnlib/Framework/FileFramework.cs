using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using dvnlib.Common;
using dvnlib.Framework;

namespace dvnlib.Framework
{
    internal class FileFramework
    {
        public string DvnConfig { get; set; }


        internal static FileFramework New(FolderFramework folderFramework)
        {
            return new FileFramework
            {
                DvnConfig = $@"{folderFramework.DvnRoot}\dvnApp.config"
            };
        }


        /// <summary>Validate the file framework.</summary>
        /// <param name="fileFramework"> The <see cref="FileFramework.FileFramework"/> to validate.</param>
        internal static void Validate(FileFramework fileFramework )
        {
            if (!File.Exists(fileFramework.DvnConfig))
            {
                DvnApp.CreateDefault(fileFramework.DvnConfig);
            }


            //foreach (var property in fileFramework.GetType().GetProperties())
            //{
            //    if (property.PropertyType == typeof(string))
            //    {
            //        var path = property.GetValue(fileFramework) as string;
            //        if (!string.IsNullOrEmpty(path) && !System.IO.Directory.Exists(path))
            //        {
            //            System.IO.Directory.CreateDirectory(path);
            //        }
            //    }
            //}
        }
    }
}