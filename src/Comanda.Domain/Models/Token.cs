using System;
using System.Collections.Generic;
using System.Text;

namespace Comanda.Domain.Models
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime Validate { get; set; }
        public string Create { get; set; }
    }
}
