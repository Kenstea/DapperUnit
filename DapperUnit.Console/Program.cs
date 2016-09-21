﻿using DapperUnit.Core;
using DapperUnit.Data;
using DapperUnit.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperUnit.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DapperUnit"].ConnectionString;

            using (var uow = new MyUnit(connectionString))
            {
                uow.Repositories.Add(typeof(Pirate), new PirateRepository(uow));

                var id = uow.Repository<Pirate>().Add(new Pirate { Name = "Stanny" });
                uow.Commit();

                var count = uow.Repository<Pirate>().Count();

                uow.Repository<Pirate>().Delete(Enumerable.Range(id, count).ToArray());
                uow.Commit();

                count = uow.Repository<Pirate>().Count();
            }
        }
    }
}
