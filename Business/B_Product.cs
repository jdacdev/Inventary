﻿using Entities;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business
{
    public class B_Product
    {
        /// <summary>
        /// Llamado simple de los elementos de Products
        /// </summary>
        /// <returns>List<ProductEntity></returns>
        public List<ProductEntity> ListProducts()
        {
            //la var db existe solo dentro de los corchetes del using
            //este using es utlizado para definir el tiempo de vida de un objeto.
            using (var db = new InventaryContext())
            {
                return db.Products.ToList();
            }
        }

        public void CreateProduct(ProductEntity objProduct)
        {
            using (var db = new InventaryContext())
            {
                db.Products.Add(objProduct); //se añade el nuevo objeto
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }

        public void UpdateProduct(ProductEntity objProduct)
        {
            using (var db = new InventaryContext())
            {
                db.Products.Update(objProduct); //ubica el objeto por su Id y ejecuta los cambios que tenga en las demas propiedades.
                db.SaveChanges();   //se confirman los cambios - agregar el nuevo elemento a la bd
            }
        }
    }
}
