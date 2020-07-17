using Entities;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business
{
    public class B_Category
    {
        /// <summary>
        /// Llamado simple de los elementos de Catogories
        /// </summary>
        /// <returns>List<CategoryEntity></returns>
        public static List<CategoryEntity> ListCategories()
        {
            //la var db existe solo dentro de los corchetes del using
            //este using es utlizado para definir el tiempo de vida de un objeto.
            using (var db = new InventaryContext())
            {
                return db.Categories.ToList();
            }
        }

        /// <summary>
        /// Llamado simple de productos
        /// </summary>
        /// <returns>List<ProductEntity></returns>
        public static CategoryEntity GetCategoryById(string id)
        {
            //la var db existe solo dentro de los corchetes del using
            //este using es utlizado para definir el tiempo de vida de un objeto.
            using (var db = new InventaryContext())
            {
                return db.Categories.ToList().Where(x => x.CategoryId.Equals(id)).FirstOrDefault();
            }
        }

        public static void CreateCategory(CategoryEntity objCategory)
        {
            using (var db = new InventaryContext())
            {
                db.Categories.Add(objCategory); //se añade el nuevo objeto
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }

        public static void UpdateCategory(CategoryEntity objCategory)
        {
            using (var db = new InventaryContext())
            {
                db.Categories.Update(objCategory); //ubica el objeto por su Id y ejecuta los cambios que tenga en las demas propiedades.
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }

    }
}
