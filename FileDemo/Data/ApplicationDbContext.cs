using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace FileDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //文档具体信息
        public DbSet<DocumentDetail> DocumentDetail { get; set; }

        //文档的类型信息
        public DbSet<DocumentType> DocumentType { get; set; }
    }
}
