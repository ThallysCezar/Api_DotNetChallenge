using ProjectAPI.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjectAPI.Domain.Entities
{
    public class StockItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }
        public decimal CostPriceProduct { get; set; }
        public Store Store { get; set; }
        public Product Product { get; set; }

        public StockItem() { }

        public StockItem(int id, int productId, int quantity, int storeId, decimal costPriceProduct)
        {
            DomainValidationException.When(id < 0, "Id greater than zero!");
            Id = id;
            Validation(productId, quantity, storeId, costPriceProduct);
        }

        public StockItem(int productId, int quantity, int storeId, decimal costPriceProduct)
        {
            Validation(productId, quantity, storeId, costPriceProduct);
        }

        private void Validation(int productId, int quantity, int storeId, decimal costPriceProduct)
        {
            DomainValidationException.When(productId < 0, "Quantity greater than zero!");
            DomainValidationException.When(quantity < 0, "Quantity greater than zero!");
            DomainValidationException.When(storeId < 0, "StoreId greater than zero!");
            DomainValidationException.When(costPriceProduct < 0, "CostPriceProduct greater than zero!");

            ProductId = productId;
            Quantity = quantity;
            StoreId = storeId;
            CostPriceProduct = costPriceProduct;
        }
    }
}
