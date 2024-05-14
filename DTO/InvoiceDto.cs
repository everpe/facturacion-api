namespace Facturacion.Api.DTO
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public string City { get; set; }
        public string NameProduct { get; set; }
        public int Number { get; set; }
        public double Value { get; set; }
    }
}
