using LDRProjectFileWeb.Models;
using LDRProjectFileWeb.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IProjectRepository projectRepository, IWebHostEnvironment hostingEnvironment)
        {
            _projectRepository = projectRepository;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Project> projects = _projectRepository.GetAllProjects();

            return View(projects);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Project newProject = new Project
                {
                    //Id = _projectRepository.GetAllProjects().Count() + 1,
                    ProjectID = model.ProjectID,
                    Name = model.Name,
                    Designer = model.Designer,
                    Engineer = model.Engineer,
                    Programmer = model.Programmer
                };

                _projectRepository.Add(newProject);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Project project = _projectRepository.GetProject(id);
            ProjectEditViewModel projectEditView = new ProjectEditViewModel
            {
                Id = project.Id,
                ProjectID = project.ProjectID,
                Name = project.Name,
                Designer = project.Designer,
                Engineer = project.Engineer,
                Programmer = project.Programmer
            };
            return View(projectEditView);
        }
        [HttpPost]
        public IActionResult Edit(ProjectEditViewModel model)
        {
            //检查提供的数据是否有效，如果没有通过验证，需要重新编辑项目信息
            //这样用户就可以更正并重新提交编辑表单
            if (ModelState.IsValid)
            {
                Project project = _projectRepository.GetProject(model.Id);
                project.ProjectID = model.ProjectID;
                project.Name = model.Name;
                project.Designer = model.Designer;
                project.Engineer = model.Engineer;
                project.Programmer = model.Programmer;
                Project updateStudent = _projectRepository.Update(project);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            _projectRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult ProjectImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProjectImage(ProjectImageCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.FileName.Contains(".jpg"))
                {
                    //必须将图像上传到wwwroot中的images文件夹
                    //而要获取wwwroot文件夹的路径，我们需要注入 ASP.NET Core提供的HostingEnvironment服务
                    //通过HostingEnvironment服务去获取wwwroot文件夹的路径
                    string uploadsFolder = _hostingEnvironment.WebRootPath;
                    string filePath = Path.Combine(uploadsFolder, "1.jpg");
                    //因为使用了非托管资源，所以需要手动进行释放
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        //使用IFormFile接口提供的CopyTo()方法将文件复制到wwwroot/images文件夹
                        model.File.CopyTo(fileStream);
                    }
                }
            }
            return View();
        }
    }
}
