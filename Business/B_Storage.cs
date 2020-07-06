using Entities;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business
{
    public class B_Storage
    {
        /// <summary>
        /// Llamado simple de los elementos de Storages
        /// </summary>
        /// <returns>List<StorageEntity></returns>
        public List<StorageEntity> ListStorages()
        {
            //la var db existe solo dentro de los corchetes del using
            //este using es utlizado para definir el tiempo de vida de un objeto.
            using (var db = new InventaryContext())
            {
                return db.Storages.ToList();
            }
        }

        public void CreateStorage(StorageEntity objStorage)
        {
            using (var db = new InventaryContext())
            {
                db.Storages.Add(objStorage); //se añade el nuevo objeto
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }

        public void UpdateStorage(StorageEntity objStorage)
        {
            using (var db = new InventaryContext())
            {
                db.Storages.Update(objStorage); //ubica el objeto por su Id y ejecuta los cambios que tenga en las demas propiedades.
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }
    }
}
