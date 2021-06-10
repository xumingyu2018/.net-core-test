using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EFcoreDemo.Models
{
    public class MyFile
    {
        public int Id { get; set; }
        public string type{ get; set; }
        public string fileName{ get; set; }
        [DataType(DataType.MultilineText)]
        public string description{ get; set; }
        public byte[] Content { get; set; }

       
    }
}