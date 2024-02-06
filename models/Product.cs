using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_tp1.models
{
    class Product //Id, Descripcion, Costo, PrecioVenta, Stock, IdUsuario
    {
        public int id { get; set; }

        public string description { get; set; }

        public double price { get; set; }

        public double salePrice { get; set; }

        public int stock { get; set; }

        public int idUser { get; set; }

        public Product() { }
        public Product(int id, string description, double price, double salePrice, int stock, int idUser)
        {
            id = id;
            this.description = description;
            this.price = price;
            this.salePrice = salePrice;
            this.stock = stock;
            this.idUser = idUser;
        }



    }

}

