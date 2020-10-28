using LDRProjectFileWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.ViewModels
{
    public class DocumentDetailsViewModel
    {
        public List<Document> Documents { get; set; }
        public string PageTitle { get; set; }
    }
}
