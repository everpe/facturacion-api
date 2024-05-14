using Facturacion.Api.Interfaces;
using MediatR;

namespace Facturacion.Api.Mediators
{
    public class DeleteInvoiceMediator
    {
        public class DeleteInvoiceCommand : IRequest<bool>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<DeleteInvoiceCommand, bool>
        {
            private readonly IFactura _facturaService;

            public Handler(IFactura facturaService)
            {
                _facturaService = facturaService;
            }

            public async Task<bool> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
            {
                return await _facturaService.DeleteInvoiceAsync(request.Id);
            }
        }
    }
}
