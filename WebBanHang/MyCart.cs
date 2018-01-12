using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using BUS;
namespace WebBanHang
{
    public class MyCart
    {
        public string Username { get; set; }
        public Dictionary<ProductEntity, int> Products = new Dictionary<ProductEntity, int>();
        public MyCart(string username)
        {
            Username = username;
        }

        public void AddToCart(ProductEntity product, int count)
        {
            int number = 0;
            Products.TryGetValue(product, out number);
            if (number == 0)
                Products.Add(product, count);
            else
                Products[product] = number + count;
        }
    }
}