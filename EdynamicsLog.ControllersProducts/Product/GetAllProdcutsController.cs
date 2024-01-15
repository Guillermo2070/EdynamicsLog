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
    public class GetAllProdcutsController
    {
        readonly IGetAllProductsInputPort InputPort;
        readonly IGetAllProductsOutputPort OutputPort;

        public GetAllProdcutsController(IGetAllProductsInputPort inputPort, IGetAllProductsOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAllProdcuts(string slugTenat)
        {
            await InputPort.Handle(slugTenat);

            return ((IPresenter<IEnumerable<ProductDTO>>)OutputPort).Content;
        }
    }
}
