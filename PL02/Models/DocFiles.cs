using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace PL02.Models
{
    public class DocFiles
    {
        public List<FileViewModel> GetFiles(IHostEnvironment e)
        {
            List<FileViewModel> list = new List<FileViewModel>();
            DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(e.ContentRootPath, "wwwroot/Documents"));
            foreach(var item in dirInfo.GetFiles())
            {
                list.Add(new FileViewModel
                {
                    Name = item.Name,
                    Size = item.Length
                });
            }
            return list;
        }
    }
}
