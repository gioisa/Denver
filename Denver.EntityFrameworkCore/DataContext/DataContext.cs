using Denver._Model;
using Denver._Model.StoreModel;
using Denver._Model.UserModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Denver.EntityFrameworkCore
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cigarettes> Cigarettes { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<StoreModel> StroeModel { get; set; }
    }
}
