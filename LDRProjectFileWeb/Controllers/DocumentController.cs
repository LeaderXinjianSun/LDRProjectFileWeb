using LDRProjectFileWeb.Models;
using LDRProjectFileWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public IActionResult Details(string id)
        {
            DocumentDetailsViewModel documentDetailsViewModel = new DocumentDetailsViewModel();
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
    }
}
