
using FileDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDemo.Models
{
    public class DocumentListModel
    {
        public int PageNum { get; set; }//当前页码

        public int PageSize { get; set; }//页码长度

        public int TypeId { get; set; }//分类Id

        public string TypeName { get; set; } = "文档类型"; //分类名称

        public List<DocumentType> TypeList { get; set; }//分类列表

        public List<DocumentDetail> DetailList { get; set; }//详细信息列表
    }
}
