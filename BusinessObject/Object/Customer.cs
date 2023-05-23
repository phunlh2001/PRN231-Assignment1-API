using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Object
{
    public class Customer
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Birthday { get; set; }
        public bool Male { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Range(1, 100)] public int Points { get; set; }

        public virtual string TypeId { get; set; }
        public virtual TypeCustomer TypeCustomer { get; set; }
    }
}
