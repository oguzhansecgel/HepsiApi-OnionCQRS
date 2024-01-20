using HepsiApi.Application.Bases;
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

namespace HepsiApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler :BaseHandler, IRequestHandler<UpdateProductCommandRequest, Unit>
    {


        public UpdateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {

        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.ID == request.Id && !x.IsDeleted);

            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);

            var productCategories = await unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x => x.ProductID == product.ID);

            await unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
            {
                await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new() { CategoryID=categoryId,ProductID=product.ID});
            }

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
