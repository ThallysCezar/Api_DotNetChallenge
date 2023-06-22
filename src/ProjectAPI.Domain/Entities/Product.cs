using ProjectAPI.Domain.Validations;
using System.Text.Json.Serialization;

namespace ProjectAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }

        public Product() { }

        [JsonConstructor]
        public Product(string name, decimal costPrice)
        {
            Validation(name, costPrice);
        }

        public Product(int id, string name, decimal costPrice)
        {
            DomainValidationException.When(id < 0, "Id greater than zero!");
            Id = id;
            Validation(name, costPrice);
        }

        private void Validation(string name, decimal costPrice)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name is required!");
            DomainValidationException.When(costPrice < 0, "CostPrice greater than zero!");

            Name = name;
            CostPrice = costPrice;
        }
    }
}
