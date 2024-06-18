﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagment.Domain.OrderManagment
{
    internal class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int AmounOrdered { get; set; }

        public override string ToString()
        {
            return $"Product ID: {ProductId} - Name: {ProductName} - " +
                $"Amount Ordered: {AmounOrdered}";
        }
    }
}
