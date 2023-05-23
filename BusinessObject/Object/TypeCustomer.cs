using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Object
{
    public class TypeCustomer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("TypeId")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
