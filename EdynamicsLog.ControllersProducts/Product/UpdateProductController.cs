using EdynamicsLog.DTOs.Product;
using EdynamicsLog.Presenters;
using EdynamicsLog.Presenters.Product;
using EdynamicsLog.UseCasesPorts.InputPort.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EdynamicsLog.ControllersProducts.Product
{
    [Route("api/{slugTenat}/[controller]")]
    [ApiController]
    [Authorize]

    public class UpdateProductController : ControllerBase
    {
        readonly IUpdateProductInputPort InputPort;
        readonly IUpdateProductOutputPort OutputPort;

        public UpdateProductController(IUpdateProductInputPort inputPort, IUpdateProductOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(string slugTenat, UpdateProductDTO updateProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await InputPort.Handle(slugTenat, updateProduct);

                    var product = ((IPresenter<ProductDTO>)OutputPort).Content;
                    var errorMessage = ((UpdateProductPresenter)OutputPort).Error;

                    if (product != null)
                    {
                        return Ok(product);
                    }
                    else
                    {
                        return NotFound(new { error = errorMessage ?? "El producto no se encontró." });
                    }
                }

                return BadRequest(ModelState);
            }
            catch 
            {
                return StatusCode(500, new { error = "Error interno del servidor al actualizar el producto." });
            }
        }
    }
}
