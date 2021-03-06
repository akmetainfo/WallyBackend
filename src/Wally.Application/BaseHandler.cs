﻿using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Usol.Wally.Persistence;

namespace Usol.Wally.Application
{
    public class BaseHandler
    {
        protected readonly ApplicationDbContext ApplicationDbContext;

        protected IDbConnection Db => this.ApplicationDbContext.Database.GetDbConnection();

        protected BaseHandler(ApplicationDbContext applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }
    }
}