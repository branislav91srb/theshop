using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Base;
using TheShop.Models.Suppliers;

namespace TheShop.Services
{
    public static class SupplierFactory
    {
        /// <summary>
        /// Returns specific suplier
        /// </summary>
        /// <param name="id"></param>
        public static ISupplier Get(int id)
        {
            switch (id)
            {
                case 1:
                    return new Supplier1();
                case 2:
                    return new Supplier2();
                case 3:
                    return new Supplier3();
                default:
                    return new Supplier1();
            }
        }

        /// <summary>
        /// Returns all existing supliers
        /// </summary>
        public static List<ISupplier> GetAll()
        {
            return new List<ISupplier>
            {
                new Supplier1(),
                new Supplier2(),
                new Supplier3()
            };
        }
    }
}
