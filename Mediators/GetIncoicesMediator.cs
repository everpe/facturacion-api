using Facturacion.Api.DTO;
using Facturacion.Api.Interfaces;
using FluentValidation;
using MediatR;

namespace Facturacion.Api.Mediators
{
    public class GetIncoicesMediator
    {
        public class GetAllInvoices : IRequest<List<InvoiceDto>>
        {
        }


        public class GetAllInvoicesValidation : AbstractValidator<GetAllInvoices>
        {
            public GetAllInvoicesValidation() { }
        }


        public class Handler : IRequestHandler<GetAllInvoices, List<InvoiceDto>>
        {
            private readonly IFactura _service;

            public Handler(IFactura FacturaService)
            {
                _service = FacturaService;
            }

            public async Task<List<InvoiceDto>> Handle(GetAllInvoices request, CancellationToken cancellationToken)
            {
                return await _service.GetInvoicesAsync();
            }

        }
    }
}
