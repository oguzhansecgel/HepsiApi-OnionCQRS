﻿using HepsiApi.Application.Bases;
using HepsiApi.Application.Features.Products.Rules;
using HepsiApi.Application.Interface.AutoMapper;
using HepsiApi.Application.Interface.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler :BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules productRules;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules,IMapper mapper,IHttpContextAccessor httpContextAccessor):base(mapper,unitOfWork,httpContextAccessor)
        {
            this.productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            Product product = new(request.Title,request.Description,request.BrandID,request.Price,request.Discount);



            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await unitOfWork.SaveAsync()>0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductID=product.ID,
                        CategoryID=categoryId
                    });
                }
                await unitOfWork.SaveAsync();
            }
            return Unit.Value;

        }
    }
}
