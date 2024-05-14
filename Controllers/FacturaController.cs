using Facturacion.Api.DTO;
using Facturacion.Api.Mediators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {

        private readonly IMediator _mediator;

        public FacturaController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Permite obtener todas las facturas registradas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<List<InvoiceDto>> GetInvoices()
        {
            return _mediator.Send(new GetIncoicesMediator.GetAllInvoices());
        }

        /// <summary>
        /// Permite registrar una nueva factura
        /// </summary>
        /// <param name="request">Información del registro.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<InvoiceDto> CreateNewInvoice(
            [FromBody] CreateInvoiceMediator.InvoiceCreateDto request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Permite la actualización de una factura previamente cveada.
        /// </summary>
        /// <param name="request">Info a actualizar</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> UpdateInvoice([FromBody] UpdateInvoiceMediator.InvoiceUpdateDto request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Elimina un registro de una factura existente.
        /// </summary>
        /// <param name="id">Identificador de la factura a eliminar.</param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "deleteInvoice")]
        public async Task<bool> DeleteInvoice(int id)
        {
            var command = new DeleteInvoiceMediator.DeleteInvoiceCommand { Id = id };
            return await _mediator.Send(command);
        }
    }
}
