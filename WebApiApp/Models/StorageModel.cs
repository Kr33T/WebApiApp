using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApp.Models
{
    public class StorageModel
    {
        public StorageModel(Storage storage)
        {
            id_good = storage.id_good;
            goodName = storage.goodName;
            price = (int)storage.price;
            quantity = (int)storage.quantity;
            goodImage = storage.goodImage;
        }

        public int id_good { get; set; }
        public string goodName { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public byte[] goodImage { get; set; }
    }
}