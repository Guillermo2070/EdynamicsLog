using EdynamicsLog.DTOs.Product;
using EdynamicsLog.Presenters;
using EdynamicsLog.UseCasesPorts.InputPort.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdynamicsLog.Controllers.Product
{
    [Route("api/{slugTenat}/[controller]")]
    [ApiController]
    [Authorize]

    public class CreateProductController
    {
        readonly ICreateProductInputPort InputPort;
        readonly ICreateProductOutputPort OutputPort;

        public CreateProductController(ICreateProductInputPort inputPort, ICreateProductOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpPost]
        public async Task<ProductDTO> CreateProduct(string slugTenat, CreateProductDTO product)
        {
            await InputPort.Handle(slugTenat, product);

            return ((IPresenter<ProductDTO>)OutputPort).Content;
        }
    }
}
