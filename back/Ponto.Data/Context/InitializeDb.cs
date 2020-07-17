using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ponto.Data.Identities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Data.Context
{
    public class InitializeDb
    {
        private readonly PontoDBContext _pontoDbContext;
        private readonly ApplicationDbContext _applicationDbContext;
       
        public InitializeDb(PontoDBContext pontoDbContext, ApplicationDbContext applicationDbContext)
        {
            _pontoDbContext = pontoDbContext;
            _applicationDbContext = applicationDbContext;
            
           CreateDefaultData();
        }

        public async void CreateDefaultData()
        {
            // await _applicationDbContext.Database.EnsureCreatedAsync();
            await _applicationDbContext.Database.MigrateAsync();
            //await _pontoDbContext.Database.MigrateAsync();
        }


    }
}
