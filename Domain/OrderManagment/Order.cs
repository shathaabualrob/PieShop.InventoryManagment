﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagment.Domain.OrderManagment
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime OrderFulfillmentDate { get; private set; }

        public List<OrderItem> OrderItems { get; private set; }

        public bool Fulfilled {  get; set; } = false;

        public Order() 
        { 
            Id = new Random().Next(999999);

            int numberOfSeconds = new Random().Next(100);
            OrderFulfillmentDate = DateTime.Now.AddSeconds(numberOfSeconds);

            OrderItems = new List<OrderItem>();
        }
    }
}
