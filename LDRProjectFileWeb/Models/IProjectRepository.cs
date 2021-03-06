﻿using System;
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
        /// 获取所有的项目信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Project> GetAllProjects();
        /// <summary>
        /// 添加一个新的项目信息
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        Project Add(Project project);
        /// <summary>
        /// 更新一个项目的信息
        /// </summary>
        /// <param name="updateProject"></param>
        /// <returns></returns>
        Project Update(Project updateProject);
        /// <summary>
        /// 删除一个项目的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Project Delete(int id);
    }
}
