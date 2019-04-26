using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using grophql.GraphQL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace grophql.MiddleWare
{
    public class ArticleGHMiddleWare
    {
        private readonly RequestDelegate _next;

        private readonly ArticleRepository _repository;

        public ArticleGHMiddleWare(RequestDelegate next,
            ArticleRepository repository)
        {
            _next = next;
            _repository = repository;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/graphql"))
            {
                using (var stream = new StreamReader(httpContext.Request.Body))
                {
                    var query = await stream.ReadToEndAsync();

                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        var schema = new Schema { Query = new ArticleGH(_repository) };
                        var result = await new DocumentExecuter()
                            .ExecuteAsync(options =>
                            {
                                options.Schema = schema;
                                options.Query = query;
                            });

                        await WriteResultAsync(httpContext, result);
                    }
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

        private async Task WriteResultAsync(HttpContext httpContext, ExecutionResult result)
        {
            var json = new DocumentWriter(true).Write(result);
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }
    }
}
