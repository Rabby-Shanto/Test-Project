using System.ComponentModel.DataAnnotations.Schema;
using GNIT.Domain.EntityBase;

namespace GNIT.Domain.Product
{
    [Table("Products_Service_Tbl")]
    public class Product : Entity
    {
        public string Name { get; set; }
        public int Unit { get; set; }
        public int Quantity { get; set; }

    }
}
