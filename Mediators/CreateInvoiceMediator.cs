using Facturacion.Api.DTO;
using Facturacion.Api.Interfaces;
using FluentValidation;
using MediatR;

namespace Facturacion.Api.Mediators
{
    public class CreateInvoiceMediator
    {

        public class InvoiceCreateDto : IRequest<InvoiceDto>
        {
            public string City { get; set; }
            public string NameProduct { get; set; }
            public int Number { get; set; }
            public double Value { get; set; }
        }

        public class InsertInvoiceValidation : AbstractValidator<InvoiceCreateDto>
        {
            public InsertInvoiceValidation()
            {
                RuleFor(x => x.City).NotNull();
                RuleFor(x => x.NameProduct).NotNull();
                RuleFor(x => x.Number).NotNull().NotEmpty();
                RuleFor(x => x.Value).NotEmpty().NotNull();
            }
        }


        public class Handler : IRequestHandler<InvoiceCreateDto, InvoiceDto>
        {
            private readonly IFactura _facturaService;
            public Handler(IFactura pacienteService)
            {
                _facturaService = pacienteService;
            }

            public async Task<InvoiceDto> Handle(InvoiceCreateDto request, CancellationToken cancellationToken)
            {
                return await _facturaService.CreateInvoiceAsync(request);
            }
        }
    }
}
