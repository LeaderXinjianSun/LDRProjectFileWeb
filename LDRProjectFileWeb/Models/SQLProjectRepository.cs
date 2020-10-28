using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.Models
{
    public class SQLProjectRepository : IProjectRepository
    {
        private readonly AppDbContext context;

        public SQLProjectRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Project Add(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return project;
        }

        public Project Delete(int id)
        {
            Project project = context.Projects.Find(id);
            if (project != null)
            {
                context.Projects.Remove(project);
                context.SaveChanges();
            }
            return project;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return context.Projects;
        }

        public Project GetProject(int id)
        {
            return context.Projects.Find(id);
        }

        public Project Update(Project updateProject)
        {
            var project = context.Projects.Attach(updateProject);

            project.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return updateProject;
        }
    }
}
