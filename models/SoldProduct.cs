using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_tp1.models
{
    internal class SoldProduct // Id, IdProducto, Stock, IdVenta 

    {
        public int _id { get; set; }

        public int _idproduct { get; set; }

        public int _stock { get; set; }

        public int _idSale { get; set; }

        public SoldProduct() { }

        public SoldProduct(int id, int idproducto, int stock, int idsale)
        {

            _id = id;
            _idproduct = idproducto;
            _stock = stock;
            _idSale = idsale;






        }

    }
}












