using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class InventaryContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }
        public DbSet<WarehouseEntity> Warehouses { get; set; }
        public DbSet<InOutEntity> InOuts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Solo configuramos una cadena de conexion si no fue configurada antes
            if (!options.IsConfigured)
            {
                //Item de la cadena de conexion
                //Server  : Nombre de la instancia de base de datos / Ip .
                //Database: Nombre de la base de datos a que vamos a acceder.
                //User Id : Nombre de usuario para acceder a la instancia
                //Password: Contraseña con la que se accede a la instancia.
                options.UseSqlServer("Server=localhost; Database = InventaryDataBase; User Id = sa; Password=juan1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //realizamos la ejecucion original del metod
            base.OnModelCreating(modelBuilder);

            //cargar data en Category
            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { CategoryId = "ASH", CategoryName = "Aseo Hogar" },
                new CategoryEntity { CategoryId = "ASP", CategoryName = "Aseo Personal" },
                new CategoryEntity { CategoryId = "HGR", CategoryName = "Hogar" },
                new CategoryEntity { CategoryId = "PRF", CategoryName = "Perfumería" },
                new CategoryEntity { CategoryId = "SLD", CategoryName = "Salud" },
                new CategoryEntity { CategoryId = "VDJ", CategoryName = "Video Juegos" }
                );

            //cargar data en Werehouseces
            modelBuilder.Entity<WarehouseEntity>().HasData(
                new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Central", WarehouseAddress = "Calle 8 con 23" },
                new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Norte", WarehouseAddress = "Calle norte con occidente" },
                new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Alternativa", WarehouseAddress = "Calle falsa 123" },
                new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Secreta", WarehouseAddress = "Calle x con y" }
                );

            //cargar data en Products
            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { ProductId = "ASJ-98745", ProductName = "Crema para manos marca Tersa", ProductDescription = "", CategoryId = "PRF" },
                new ProductEntity { ProductId = "RPT-5465879", ProductName = "Pastillas para la garganta LESUS", ProductDescription = "", CategoryId = "SLD" }
                );
        }


    }
}
