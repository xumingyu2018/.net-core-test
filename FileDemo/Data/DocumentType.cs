using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileDemo.Data
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }


        //文档类型
        public string Type { get; set; }
    }
}
