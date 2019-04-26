using grophql.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grophql
{
    public class ArticleRepository : IRepository<Article>
    {
        private List<Article> articles = new List<Article>
        {
            new Article{
                Id =1,
                Title ="a1",
                Content = "content1"
            },
              new Article{
                Id =2,
                Title ="a2",
                Content = "content2"
            }
        };

        public IEnumerable<Article> GetAll()
        {
            return articles;
        }

        public Article GetById(int id)
        {
            return articles.Find(x => x.Id == id);
        }
    }
}
