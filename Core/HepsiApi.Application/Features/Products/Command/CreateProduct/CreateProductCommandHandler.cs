using HepsiApi.Application.Features.Products.Rules;
using HepsiApi.Application.Interface.UnitOfWorks;
using HepsiApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
        {
            _unitOfWork = unitOfWork;
            this.productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            Product product = new(request.Title,request.Description,request.BrandID,request.Price,request.Discount);



            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await _unitOfWork.SaveAsync()>0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductID=product.ID,
                        CategoryID=categoryId
                    });
                }
                await _unitOfWork.SaveAsync();
            }
            return Unit.Value;

        }
    }
}
