using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System;

namespace myproj.EntityFrameworkCore
{
    public static class myprojDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<myprojDbContext> builder, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
            builder.UseMySql(connectionString, serverVersion);     
        }

        public static void Configure(DbContextOptionsBuilder<myprojDbContext> builder, DbConnection connection)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
            builder.UseMySql(connection, serverVersion);
        }
    }
}
