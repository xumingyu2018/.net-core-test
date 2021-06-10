using FileDemo.Constant;
using FileDemo.Data;
using FileDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private static int limit = (int)MyConstant.PageLimit;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int Page = 0)
        {
            List<DocumentDetail> documentDetails = _context.DocumentDetail.ToList();
            int pageSize = GetPageSize(documentDetails.Count()); //获取分页面包屑的总长度

            DocumentListModel DocumentListModel = new DocumentListModel()
            {
                PageNum = Page,
                PageSize = pageSize,
                TypeList = _context.DocumentType.ToList(),
                DetailList = documentDetails.Skip(Page * limit).Take(limit).ToList()
            };

            return View(DocumentListModel);
        }

        /// <summary>
        /// 上传界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Upload(int? type, UploadModel uploadModel)
        {
            List<DocumentType> documentTypes = _context.DocumentType.ToList();

            //首次进入上传界面，默认type为null， 解决未选择文件类型上传的问题
            if (type == null)
            {
                uploadModel.TypeName = "请先选择上传文档的类型";
                uploadModel.TypeList = documentTypes;
                return View(uploadModel);
            }

            DocumentType documentType = documentTypes.FirstOrDefault(item => item.Id == (type ?? 1));
            uploadModel.TypeList = documentTypes;
            uploadModel.TypeId = documentType.Id;
            uploadModel.TypeName = documentType.Type;

            return View(uploadModel);
        }

        /// <summary>
        /// 简单上传
        /// </summary>
        /// <param name="uploadModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadAsync([Bind(include: "FormFile,TypeId,TypeName,DocDesc")] UploadModel uploadModel)
        {

            if (!ModelState.IsValid || uploadModel.TypeId == 0)
            {
                uploadModel.TypeList = await _context.DocumentType.ToListAsync();
                uploadModel.FormFile = null;
                return View(uploadModel);
            }
            //转换为文件流
            Stream fileStrame = uploadModel.FormFile.OpenReadStream();

            //转换为二进制数组
            byte[] bytBLOBData = new byte[uploadModel.FormFile.Length];
            fileStrame.Read(bytBLOBData, 0, bytBLOBData.Length);


            DocumentDetail DocumentDetail = new DocumentDetail()
            {
                Type = uploadModel.TypeId,
                FileType = uploadModel.FormFile.ContentType,
                DocName = uploadModel.FormFile.FileName,
                DocContent = bytBLOBData,
                DocDesc = uploadModel.DocDesc
            };

            await _context.DocumentDetail.AddAsync(DocumentDetail);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        /// <summary>
        /// 加载指定的文档
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetByTypeAsync(int typeId, int? page)
        {
            DocumentListModel documentListModel = await GetDocumentListModelAsync(typeId, page ?? 0);

            return View("index", documentListModel);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DownloadAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            DocumentDetail documentDetail = await _context.DocumentDetail.FindAsync(id);
            byte[] docContent = documentDetail.DocContent;

            return File(docContent, documentDetail.FileType, documentDetail.DocName);
        }


        /// <summary>
        /// 获取分页后的文档列表
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        private async Task<DocumentListModel> GetDocumentListModelAsync(int typeId, int page)
        {
            List<DocumentDetail> documentDetails = await _context.DocumentDetail.ToListAsync();
            string typeName = "Default";

            if (typeId != 0)
            {
                typeName = (await _context.DocumentType.FindAsync(typeId)).Type;
                documentDetails = documentDetails.Where(item => item.Type == typeId).ToList();
            }

            int pageSize = documentDetails.Count() / limit;
            pageSize = documentDetails.Count() % limit == 0 ? pageSize : ++pageSize;

            DocumentListModel DocumentListModel = new DocumentListModel()
            {
                PageNum = page,
                PageSize = pageSize,
                TypeId = typeId,
                TypeName = typeName,
                TypeList = await _context.DocumentType.ToListAsync(),
                DetailList = documentDetails.Skip(page * limit).Take(limit).ToList()
            };
            return DocumentListModel;
        }

        private int GetPageSize(int pageCount)
        {
            return pageCount % (int)MyConstant.PageLimit == 0 ? pageCount / (int)MyConstant.PageLimit : pageCount / (int)MyConstant.PageLimit + 1;
        }
    }
}
