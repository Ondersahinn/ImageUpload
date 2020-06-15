using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImageUploadEF.Models.Managers
{
    public class DatabaseContex : DbContext
    {
        public DbSet<Images> Images { get; set; }

        public DatabaseContex()
        {
            Database.SetInitializer(new CreateDatabase());
        }
    }
    public class CreateDatabase : CreateDatabaseIfNotExists<DatabaseContex>
    {
        protected override void Seed(DatabaseContex context)
        {
            Images image = new Images();
            image.ImageFileName = "penguen.jpg";
            image.Name = "Cv Resmi";
            context.Images.Add(image);
            context.SaveChanges();

        }
    }
}