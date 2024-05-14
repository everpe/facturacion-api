using AutoMapper;
using Facturacion.Api.DTO;
using Facturacion.Api.Mediators;
using Facturacion.Api.Models;
using static Facturacion.Api.Mediators.CreateInvoiceMediator;
using static Facturacion.Api.Mediators.UpdateInvoiceMediator;

namespace Facturacion.Api.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceCreateDto, Invoice>();
            CreateMap<InvoiceUpdateDto, Invoice>();

        }
    }
}
