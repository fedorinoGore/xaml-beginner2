using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RestaurantManager.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string SpecialRequests { get; set; }

        public List<MenuItem> Items { get; set; }

        public Table Table { get; set; }

        public bool Complete { get; set; }

        public bool Expedite { get; set; }

        public Order()
        {
            Id = Guid.NewGuid().ToString().GetHashCode();
        }

        //private string GetUniqueKey()
        //{
        //    int maxSize = 8;
        //    int minSize = 5;
        //    char[] chars = new char[62];
        //    string a;
        //    a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //    chars = a.ToCharArray();
        //    int size = maxSize;
        //    byte[] data = new byte[1];
        //    RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        //    crypto.GetNonZeroBytes(data);
        //    size = maxSize;
        //    data = new byte[size];
        //    crypto.GetNonZeroBytes(data);
        //    StringBuilder result = new StringBuilder(size);
        //    foreach (byte b in data)
        //    {
        //        result.Append(chars[__b % (chars.Length - 1));
        //    }
        //    return result.ToString();
        //}
        //public override string ToString()
        //{
        //    return String.Join(", ", Items.Select(i => i.Title));
        //}
    }
}
