using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.Models
{
    public interface IProjectRepository
    {
        /// <summary>
        /// 通过 Id 来获取项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Project GetProject(int id);
        /// <summary>
        /// 获取所有的学生信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Project> GetAllProjects();
        /// <summary>
        /// 添加一名新的学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Project Add(Project project);
        /// <summary>
        /// 更新一名学生的信息
        /// </summary>
        /// <param name="updateStudent"></param>
        /// <returns></returns>
        Project Update(Project updateProject);
        /// <summary>
        /// 删除一名学生的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Project Delete(int id);
    }
}
