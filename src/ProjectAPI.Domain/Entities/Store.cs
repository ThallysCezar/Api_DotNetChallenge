using ProjectAPI.Domain.Validations;

namespace ProjectAPI.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Store() { }

        public Store(string name, string address)
        {
            Validation(name, address);
        }

        public Store(int id, string name, string address)
        {
            DomainValidationException.When(Id < 0, "id greater than 0");
            Id = id;
            Validation(name, address);
        }

        private void Validation(string name, string address)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name is required!");
            DomainValidationException.When(string.IsNullOrEmpty(address), "Address is required!");

            Name = name;
            Address = address;
        }
    }
}
