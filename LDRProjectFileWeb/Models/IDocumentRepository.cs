using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.Models
{
    public interface IDocumentRepository
    {
        /// <summary>
        /// 通过 Id 来获取文件信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Document GetDocument(int id);
        /// <summary>
        /// 获取项目的文件信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Document> GetAllDocuments();
        /// <summary>
        /// 添加一个新的文件信息
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        Document Add(Document document);
        /// <summary>
        /// 更新一个文件的信息
        /// </summary>
        /// <param name="updateDocument"></param>
        /// <returns></returns>
        Document Update(Document updateDocument);
        /// <summary>
        /// 删除一个文件的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Document Delete(int id);
    }
}
