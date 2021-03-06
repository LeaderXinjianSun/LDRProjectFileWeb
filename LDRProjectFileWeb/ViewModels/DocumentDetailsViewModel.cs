﻿using Microsoft.AspNetCore.Http;
using LDRProjectFileWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.ViewModels
{
    public class DocumentDetailsViewModel
    {
        public List<Document> Documents { get; set; }
        public string ProjectID { get; set; }
        public string PageTitle { get; set; }
    }
}
