using Entities;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business
{
    public class B_Warehouse
    {
        /// <summary>
        /// Llamado simple de los elementos de Warehouses
        /// </summary>
        /// <returns>List<WarehouseEntity></returns>
        public static List<WarehouseEntity> ListWarehouses()
        {
            //la var db existe solo dentro de los corchetes del using
            //este using es utlizado para definir el tiempo de vida de un objeto.
            using (var db = new InventaryContext())
            {
                return db.Warehouses.ToList();
            }
        }
        
        /// <summary>
        /// Llamado simple de productos
        /// </summary>
        /// <returns>List<ProductEntity></returns>
        public static WarehouseEntity GetWarehouseById(string id)
        {
            //la var db existe solo dentro de los corchetes del using
            //este using es utlizado para definir el tiempo de vida de un objeto.
            using (var db = new InventaryContext())
            {
                return db.Warehouses.ToList().Where(x => x.WarehouseId.Equals(id)).FirstOrDefault();
            }
        }

        public static void CreateWarehouse(WarehouseEntity objWarehouse)
        {
            using (var db = new InventaryContext())
            {
                objWarehouse.WarehouseId = Guid.NewGuid().ToString();
                db.Warehouses.Add(objWarehouse); //se añade el nuevo objeto
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }

        public static void UpdateWarehouse(WarehouseEntity objWarehouse)
        {
            using (var db = new InventaryContext())
            {
                db.Warehouses.Update(objWarehouse); //ubica el objeto por su Id y ejecuta los cambios que tenga en las demas propiedades.
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }
    }
}
