using Entities;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business
{
    public class B_InOut
    {
        /// <summary>
        /// Llamado simple de los elementos de InOuts
        /// </summary>
        /// <returns>List<InOutEntity></returns>
        public static List<InOutEntity> ListInOuts()
        {
            //la var db existe solo dentro de los corchetes del using
            //este using es utlizado para definir el tiempo de vida de un objeto.
            using (var db = new InventaryContext())
            {
                return db.InOuts.ToList();
            }
        }

        /// <summary>
        /// Llamado simple de productos
        /// </summary>
        /// <returns>List<ProductEntity></returns>
        public static InOutEntity GetInOutsById(string id)
        {
            //la var db existe solo dentro de los corchetes del using
            //este using es utlizado para definir el tiempo de vida de un objeto.
            using (var db = new InventaryContext())
            {
                return db.InOuts.ToList().Where(x => x.InOutId.Equals(id)).FirstOrDefault();
            }
        }

        public static void CreateInOut(InOutEntity objInOut)
        {
            using (var db = new InventaryContext())
            {
                objInOut.InOutId = Guid.NewGuid().ToString();
                db.InOuts.Add(objInOut); //se añade el nuevo objeto
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }

        public static void UpdateInOut(InOutEntity objInOut)
        {
            using (var db = new InventaryContext())
            {
                db.InOuts.Update(objInOut); //ubica el objeto por su Id y ejecuta los cambios que tenga en las demas propiedades.
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }
    }
}
