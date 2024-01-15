using EdynamicsLog.DTOs.Product;
using EdynamicsLog.Presenters;
using EdynamicsLog.Presenters.Product;
using EdynamicsLog.UseCasesPorts.InputPort.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdynamicsLog.ControllersProducts.Product
{
    [Route("api/{slugTenat}/[controller]/{idProduct}")]
    [ApiController]
    [Authorize]
    public class DeleteProductController : ControllerBase
    {
        readonly IDeleteProductInputPort InputPort;
        readonly IDeleteProductOutputPort OutputPort;

        public DeleteProductController(IDeleteProductInputPort inputPort, IDeleteProductOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string slugTenat, int idProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await InputPort.Handle(slugTenat, idProduct);

                    var product = (DeleteProductPresenter)OutputPort;
                    var message = ((DeleteProductPresenter)OutputPort).Message;

                    if (message.Contains("Producto eliminado correctamente."))
                    {
                        return Ok(new { message = product.Message ?? "Producto eliminado correctamente." });
                    }
                    else
                    {
                        return NotFound(new { error = product.Message ?? "El producto no se encontró." });
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
