using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grophql.GraphQL
{
    public class ArticleGH : ObjectGraphType
    {
        public ArticleGH(ArticleRepository articleRepository)
        {
            Field<ArticleGHType>("article",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return articleRepository.GetById(id);
                });


            Field<ListGraphType<ArticleGHType>>("artices",
                resolve: context =>
                {
                    return articleRepository.GetAll();
                });
        }
    }
}
