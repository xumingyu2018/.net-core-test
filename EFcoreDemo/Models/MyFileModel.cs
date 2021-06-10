using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFcoreDemo.Models
{
    public class MyFileModel
    {
        public MyFile MyFile { get; set; }
        public List<MyFile> MyFiles { get; set; }
    }
}