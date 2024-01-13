using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Products.Queries.GettAllProducts
{
    public class GettAllProductQueryRequest : IRequest<IList<GettAllProductQueryResponse>>
    {
    }
}
