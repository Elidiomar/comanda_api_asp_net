using Comanda.Domain.Models.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda.Domain.Models.Sale
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Complete,
        Cancelled
    };

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public string Title  { get; set; }
        public string Description { get; set; }
        public List<Product> ProductList { get; set; }
        public string Control { get; set; }
    }
}
