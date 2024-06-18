using PieShop.InventoryManagment.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.InventoryManagment.Domain.ProductManagment
{
    public class Product
    {
        private int id;
        private string name = string.Empty;
        private string? description;

        private int maxItemsInStock = 0;
        

        public Product(int id) : this(id, string.Empty) { }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Product(int id, string name, UnitType unitType, Price price, string? description, int maxAmountInStock)
        {
            Id = id;
            Name = name;
            Description = description;
            UnitType = unitType;
            Price = price;

            maxItemsInStock = maxAmountInStock;

            UpdateLowStock();

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value.Length > 50 ? value[..50] : value; }
        public string? Description
        {
            get => description;
            set
            {
                if (value == null)
                    description = string.Empty;
                else
                    description = value.Length > 250 ? value[..250] : value;
            }
        }
        public UnitType UnitType { get; set; }
        public int AmountInStock { get; private set; }
        public bool IsBelowStockThreshold { get; private set; }

        public Price Price { get; set; }

        public void UserProduct(int items)
        {
            if (items <= AmountInStock)
            {
                // use items in stock
                AmountInStock -= items;

                UpdateLowStock();

                Log($"Amount in stock update. Now {AmountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {AmountInStock} available but {items} requested");
            }
        }

        private void UpdateLowStock()
        {
            if (AmountInStock <= 00)
            {
                IsBelowStockThreshold = true;
            }
        }

        public void IncreaseStock() { AmountInStock++; }

        public void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount;

            if (newStock <= maxItemsInStock)
                AmountInStock += amount;
            else
            {
                AmountInStock = maxItemsInStock;
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} " +
                    $"item(s) ordered that couldn't be stored.");
            }

            if (AmountInStock > 10)
                IsBelowStockThreshold = false;
        }

        private void DecreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }
            UpdateLowStock();
            Log(reason);

        }

        public string DisplayDetailShort()
        {
            return $"{Id}. {Name} \n {AmountInStock} items in stock";
        }

        public string DisplayDetailsull()
        {
            return DisplayDetailsull("");
        }

        public string DisplayDetailsull(string extraDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Id}. {Name}\n{Description}\n{Price}\n{AmountInStock} items in stock");
            sb.Append(extraDetails);

            if (IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }
            return sb.ToString();
        }

        public void Log(string message) { Console.WriteLine(message); }

        private string CreateSimpleProductRepresentation() { return $"Product {Id} ({Name})"; }
    }

}
