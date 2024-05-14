using Facturacion.Api.Interfaces;
using FluentValidation;
using MediatR;

namespace Facturacion.Api.Mediators
{
    public class UpdateInvoiceMediator
    {
        public class InvoiceUpdateDto : IRequest<bool>
        {
            public int InvoiceId { get; set; }
            public string City { get; set; }
            public string NameProduct { get; set; }
            public int Number { get; set; }
            public double Value { get; set; }
        }
        public class UpdateHospitalizacionValidation : AbstractValidator<InvoiceUpdateDto>
        {
            public UpdateHospitalizacionValidation()
            {
                RuleFor(x => x.InvoiceId).NotEmpty()
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Debe ser un registro existente.");
                RuleFor(x => x.City).NotEmpty()
                    .NotNull()
                    .MaximumLength(300)
                    .WithMessage("Maximo 330 caracteres..");
                RuleFor(x => x.NameProduct).NotEmpty()
                   .NotNull()
                   .MaximumLength(300)
                   .WithMessage("Maximo 330 caracteres..");
                RuleFor(x => x.Number).NotNull().NotEmpty();
                RuleFor(x => x.Value).NotNull().NotEmpty();
            }
        }

        public class Handler : IRequestHandler<InvoiceUpdateDto, bool>
        {
            private readonly IFactura _facturaService;
            public Handler(IFactura facturaService)
            {
                _facturaService = facturaService;
            }
            public async Task<bool> Handle(InvoiceUpdateDto request, CancellationToken cancellationToken)
            {
                return await _facturaService.UpdateInvoiceAsync(request);
            }
        }
    }
}
