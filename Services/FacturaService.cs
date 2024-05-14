using AutoMapper;
using AutoMapper.QueryableExtensions;
using Facturacion.Api.DTO;
using Facturacion.Api.Interfaces;
using Facturacion.Api.Mediators;
using Facturacion.Api.Models;
using Facturacion.Api.Persistence;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Api.Services
{
    public class FacturaService : IFactura
    {
        private readonly FacturacionDataContext _context;
        private readonly IMapper _mapper;

        public FacturaService(FacturacionDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<InvoiceDto>> GetInvoicesAsync()
        {
            return _context.Invoices.ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceMediator.InvoiceCreateDto request)
        {
            var invoice = _mapper.Map<Invoice>(request);
            _context.Invoices.Add(invoice);
            var valor = await _context.SaveChangesAsync();
            if (valor > 0)
            {
                return _mapper.Map<InvoiceDto>(invoice);
            }
            throw new Exception("No se pudo insertar la factura.");
        }

        public async Task<bool> UpdateInvoiceAsync(UpdateInvoiceMediator.InvoiceUpdateDto request)
        {
            var invoiceDb = await _context.Invoices.AsNoTracking()
                .FirstOrDefaultAsync(x => x.InvoiceId == request.InvoiceId);
            if (invoiceDb is null )
                return false;

            var invoice = _mapper.Map<Invoice>(request);
            _context.Update(invoice);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            if (!await _context.Invoices.AnyAsync(x => x.InvoiceId == id))
                return false;

            _context.Remove(new Invoice() { InvoiceId = id });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SummaryByCityDto>> GetSummaryByCityAsync()
        {
            return await _context.Invoices
                .GroupBy(f => f.City)
                .Select(g => new SummaryByCityDto
                {
                    City = g.Key,
                    TotalSold = (decimal)g.Sum(f => f.Value)
                })
                .ToListAsync();
        }
    }
}
