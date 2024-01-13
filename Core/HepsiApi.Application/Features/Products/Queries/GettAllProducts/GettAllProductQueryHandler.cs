using HepsiApi.Application.DTOs;
using HepsiApi.Application.Interface.AutoMapper;
using HepsiApi.Application.Interface.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Products.Queries.GettAllProducts
{
    public class GettAllProductQueryHandler : IRequestHandler<GettAllProductQueryRequest, IList<GettAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GettAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GettAllProductQueryResponse>> Handle(GettAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x=>x.Include(b=>b.Brand));
            var brand = mapper.Map<BrandDto,Brand>(new Brand());
            var map = mapper.Map<GettAllProductQueryResponse, Product>(products);
            foreach (var product in map) 
            {
                product.Price -= (product.Price * product.Discount / 100);
            }
            return map;
        }
    }
}
