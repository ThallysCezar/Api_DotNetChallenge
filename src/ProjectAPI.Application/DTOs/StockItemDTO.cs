using ProjectAPI.Domain.Entities;

namespace ProjectAPI.Application.DTOs
{
    public class StockItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }
        public decimal CostPriceProduct { get; set; }
        public Store Store { get; set; }
        public Product Product { get; set; }
    }
}
