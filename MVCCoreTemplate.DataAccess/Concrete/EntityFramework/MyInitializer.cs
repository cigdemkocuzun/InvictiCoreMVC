using Microsoft.EntityFrameworkCore;
using MVCCoreTemplate.DataAccess.Concrete.EntityFramework;
using MVCCoreTemplate.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreBlogApp.DataAccess.Concrete.EntityFramework
{
    public static class MyInitializer
    {
        public static void Seed()
        {
            DatabaseContext context = new DatabaseContext();

            context.Database.Migrate();

        }
    }
}
