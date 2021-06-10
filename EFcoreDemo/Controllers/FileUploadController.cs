using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFcoreDemo.Models;
using System.Linq;

namespace EFcoreDemo.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly UserDbContext _context;
        private IWebHostEnvironment _env;
        private string _dir;

    
        public FileUploadController(IWebHostEnvironment env,UserDbContext context)
        {
            _env=env;
            _context = context;
            _dir=_env.ContentRootPath;
        }

         public IActionResult Upload()
        {
            return View();
        }


        //单文件上传
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> upload(MyFile myFile,IFormFile file)
        {

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                
                if (memoryStream.Length < 2097152)
                {
                    myFile.fileName=file.FileName;
                    myFile.Content = memoryStream.ToArray();
                
                    if (ModelState.IsValid)
                    {
                        _context.Add(myFile);
                        await _context.SaveChangesAsync();
                        return View();
                    }
                }
            }
            return null;   
        }

        public IActionResult DownloadFile(int? id)
        {
            var myfile = _context.MyFiles.FirstOrDefault(m => m.Id == id);
            Stream stream = new MemoryStream(myfile.Content);
            return File(stream, "xxx/aaa", myfile.fileName);
        }

         public IActionResult Download()
        {
            MyFileModel model =new MyFileModel(){
                MyFiles = _context.MyFiles.ToList()
            };
            return View(model);
        }

    }
}