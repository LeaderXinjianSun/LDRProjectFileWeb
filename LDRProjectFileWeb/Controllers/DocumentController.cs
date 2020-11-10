using LDRProjectFileWeb.Models;
using LDRProjectFileWeb.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public DocumentController(IDocumentRepository documentRepository, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            _documentRepository = documentRepository;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            DocumentDetailsViewModel documentDetailsViewModel = new DocumentDetailsViewModel();
            documentDetailsViewModel.ProjectID = id;
            documentDetailsViewModel.PageTitle = id + "文件";
            IEnumerable<Document> documents = _documentRepository.GetAllDocuments();
            documentDetailsViewModel.Documents = new List<Document>();
            foreach (var item in documents)
            {
                if (item.ProjectID == id)
                {
                    documentDetailsViewModel.Documents.Add(item);
                }
            }
            return View(documentDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create(string id)
        {
            DocumentCreateViewModel documentCreateViewModel = new DocumentCreateViewModel()
            {
                ProjectID = id
            };
            return View(documentCreateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DocumentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.Files != null && model.Files.Count > 0)
                {
                    foreach (var file in model.Files)
                    {
                        //必须将图像上传到wwwroot中的images文件夹
                        //而要获取wwwroot文件夹的路径，我们需要注入 ASP.NET Core提供的HostingEnvironment服务
                        //通过HostingEnvironment服务去获取wwwroot文件夹的路径
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "files");
                        //为了确保文件名是唯一的，我们在文件名后附加一个新的GUID值和一个下划线

                        uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        //因为使用了非托管资源，所以需要手动进行释放
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            //使用IFormFile接口提供的CopyTo()方法将文件复制到wwwroot/images文件夹
                            file.CopyTo(fileStream);
                        }
                        var aa = await _userManager.GetUserAsync(HttpContext.User);
                        Document newDocument = new Document
                        {
                            ProjectID = model.ProjectID,
                            UploadDate = DateTime.Now,
                            FileSize = ((double)file.Length / 1048576).ToString("F1") + "MB",
                            Uploader = aa.UserName,
                            FilePath = uniqueFileName,
                            FileName = file.FileName
                        };

                        _documentRepository.Add(newDocument);
                    }
                }

                return RedirectToAction("Details", new { id = model.ProjectID });
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Document dc = _documentRepository.GetDocument(id);
            if (dc != null)
            {
                string projectid = dc.ProjectID;
                _documentRepository.Delete(id);
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "files");
                string filePath = Path.Combine(uploadsFolder, dc.FilePath);
                System.IO.File.Delete(filePath);
                return RedirectToAction("Details",new { id = projectid });
            }
            return View();
        }
        [HttpGet]
        public IActionResult DownloadFile(int id)
        {
            var dc = _documentRepository.GetDocument(id);
            if (dc == null) return NotFound();
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "files");
            string filePath = Path.Combine(uploadsFolder, dc.FilePath);
            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), dc.FileName);
        }
    }
}
