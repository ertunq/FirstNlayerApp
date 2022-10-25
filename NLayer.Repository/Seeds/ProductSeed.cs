﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nlayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                Name = "Kalem 1",
                CategoryId = 1,
                Price = 100,
                Stock = 20,
                CreatedDate = DateTime.Now
            },
             new Product
             {
                 Id = 2,
                 Name = "Kalem 2",
                 CategoryId = 1,
                 Price = 200,
                 Stock = 20,
                 CreatedDate = DateTime.Now
             },
             new Product
             {
                 Id = 3,
                 Name = "Kalem 3",
                 CategoryId = 1,
                 Price = 600,
                 Stock = 30,
                 CreatedDate = DateTime.Now
             },
             new Product
             {
                 Id = 4,
                 Name = "Defter 1",
                 CategoryId = 2,
                 Price = 30,
                 Stock = 30,
                 CreatedDate = DateTime.Now
             },
             new Product
             {
                 Id = 5,
                 Name = "Defter 2",
                 CategoryId = 2,
                 Price = 330,
                 Stock = 30,
                 CreatedDate = DateTime.Now
             }
             );
        }
    }
}
