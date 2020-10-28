using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDRProjectFileWeb.Models
{
    public class SQLDocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext context;

        public SQLDocumentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Document Add(Document document)
        {
            context.Documents.Add(document);
            context.SaveChanges();
            return document;
        }

        public Document Delete(int id)
        {
            Document document = context.Documents.Find(id);
            if (document != null)
            {
                context.Documents.Remove(document);
                context.SaveChanges();
            }
            return document;
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            return context.Documents;
        }

        public Document GetDocument(int id)
        {
            return context.Documents.Find(id);
        }

        public Document Update(Document updateDocument)
        {
            var document = context.Documents.Attach(updateDocument);

            document.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return updateDocument;
        }
    }
}
