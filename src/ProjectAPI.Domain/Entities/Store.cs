using ProjectAPI.Domain.Validations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Store() { }

        //construtor quando quer adicionar
        public Store(string name, string address)
        {
            Validation(name, address);
        }

        //construtor para quando quiser editar
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
