using GraphQL.Types;
using grophql.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grophql.GraphQL
{
    public class ArticleGHType:ObjectGraphType<Article>
    {
        public ArticleGHType()
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Content);

        }
    }
}
