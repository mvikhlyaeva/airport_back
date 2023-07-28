using airport_back.Table;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Flight> flights { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Pilot> pilots { get; set; }
        public DbSet<Airport> airports { get; set; }

        public DbSet<Passenger> passengers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //SqlConnectionFactory defaultFactory =
            //new SqlConnectionFactory("Server=(localdb)\\MSSQLLocalDB;Initial Catalog = airportdb;Integrated Security = false;User ID = user1;Password =123");
            //this.SetDefaultConnectionFactory(defaultFactory);
        }

        private void SetDefaultConnectionFactory(SqlConnectionFactory defaultFactory)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new AirportConfiguration());
            modelBuilder.ApplyConfiguration(new PilotConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (DbManager.DbName != null && !optionsBuilder.IsConfigured)
        //    {
        //        var dbName = DbManager.DbName;
        //        var dbConnectionString = DbManager.GetDbConnectionString(dbName);
        //        optionsBuilder.UseSqlServer(dbConnectionString);
        //    }
        //}
    }

    //public class DbConnection
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("dbconnection")]
    //    public string Dbconnection { get; set; }

    //    public static List<DbConnection> FromJson(string json) => JsonConvert.DeserializeObject<List<DbConnection>>(json, Converter.Settings);
    //}

    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters =
    //        {
    //            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
    //        },
    //    };
    //}

    //public static class DbConnectionManager
    //{
    //    public static List<DbConnection> GetAllConnections()
    //    {
    //        List<DbConnection> result;
    //        using (StreamReader r = new StreamReader("config.json"))
    //        {
    //            string json = r.ReadToEnd();
    //            result = DbConnection.FromJson(json);
    //        }
    //        return result;
    //    }

    //    public static string GetConnectionString(string dbName)
    //    {
    //        return GetAllConnections().FirstOrDefault(c => c.Name == dbName)?.Dbconnection;
    //    }
    //}

    //public static class DbManager
    //{
    //    public static string DbName;

    //    public static string GetDbConnectionString(string dbName)
    //    {
    //        return DbConnectionManager.GetConnectionString(dbName);
    //    }
    //}

}