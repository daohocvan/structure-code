using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.Contract.Abstractions.Message;

namespace Structure.Contract.Services.Product
{
    public static class Query
    {
        public record GetProductQuery() : IQuery<List<Response.ProductResponse>>;

        public record GetProductById(Guid id) : IQuery<Response.ProductResponse>;
    }
}
