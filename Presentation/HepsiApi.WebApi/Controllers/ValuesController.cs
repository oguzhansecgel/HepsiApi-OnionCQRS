using HepsiApi.Application.Interface.UnitOfWorks;
using HepsiApi.Domain.Entities;
using HepsiApi.Persistence.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            
            return Ok(await unitOfWork.GetReadRepository<Product>().GetAllAsync());
        }
    }
}
