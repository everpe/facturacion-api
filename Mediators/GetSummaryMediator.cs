using Facturacion.Api.DTO;
using Facturacion.Api.Interfaces;
using FluentValidation;
using MediatR;

namespace Facturacion.Api.Mediators
{
    public class GetSummaryMediator
    {
        public class GetSummaryInvoices : IRequest<IEnumerable<SummaryByCityDto>>
        {
        }


        public class GetSummaryValidation : AbstractValidator<GetSummaryInvoices>
        {
            public GetSummaryValidation() { }
        }


        public class Handler : IRequestHandler<GetSummaryInvoices, IEnumerable<SummaryByCityDto>>
        {
            private readonly IFactura _service;

            public Handler(IFactura FacturaService)
            {
                _service = FacturaService;
            }

            public async Task<IEnumerable<SummaryByCityDto>> Handle(GetSummaryInvoices request, CancellationToken cancellationToken)
            {
                return await _service.GetSummaryByCityAsync();
            }

        }
    }
}
