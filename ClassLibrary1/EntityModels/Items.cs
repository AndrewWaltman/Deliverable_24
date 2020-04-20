using System;
using System.Collections.Generic;

namespace Deliverable_24.EntityModels
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
