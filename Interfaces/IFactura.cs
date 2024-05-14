using Facturacion.Api.DTO;
using Facturacion.Api.Mediators;

namespace Facturacion.Api.Interfaces
{
    public interface IFactura
    {
        Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceMediator.InvoiceCreateDto request);
        Task<bool> DeleteInvoiceAsync(int id);
        Task<List<InvoiceDto>> GetInvoicesAsync();
        Task<IEnumerable<SummaryByCityDto>> GetSummaryByCityAsync();
        Task<bool> UpdateInvoiceAsync(UpdateInvoiceMediator.InvoiceUpdateDto request);
    }
}
