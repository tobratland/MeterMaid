using MeterMaid3.Models;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaid3.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<MeterData> MeterData { get; set; }
        public DbSet<MeterValue> MeterValues { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MeterData>().ToTable("MeterData");
            builder.Entity<MeterData>().HasKey(p => p.Id);
            builder.Entity<MeterData>().Property(p => p.Id).IsRequired();
            builder.Entity<MeterData>().Property(p => p.Meter_Id).IsRequired();
            builder.Entity<MeterData>().Property(p => p.Customer_Id).IsRequired();
            builder.Entity<MeterData>().Property(p => p.Resolution).IsRequired();
            builder.Entity<MeterData>().Property(p => p.From).IsRequired();
            builder.Entity<MeterData>().Property(p => p.To).IsRequired().HasMaxLength(30);

            builder.Entity<MeterData>().HasData
            (
                new MeterData
                {
                    Id = Guid.Parse("9fd6ae9f-1e47-471c-b071-65f341bc7cb6"),
                    Meter_Id = "123qwe",
                    Customer_Id = "asp123",
                    Resolution = "Hour",
                    From = DateTime.Parse("2017-08-08T00:00:00Z").ToUniversalTime(),
                    To = DateTime.Parse("2017-08-08T23:00:00Z").ToUniversalTime(),
                },
                new MeterData
                {
                    Id = Guid.Parse("d3c3783e-3071-4fd0-b852-c72bd5f4b63f"),
                    Meter_Id = "345qwe",
                    Customer_Id = "qwe345",
                    Resolution = "Hour",
                    From = DateTime.Parse("2017-08-09T00:00:00Z").ToUniversalTime(),
                    To = DateTime.Parse("2017-08-09T23:00:00Z").ToUniversalTime(),
                }
            );

            builder.Entity<MeterValue>().ToTable("MeterValues");
            builder.Entity<MeterValue>().HasKey(p => p.Id);
            builder.Entity<MeterValue>().Property(p => p.Id).IsRequired();
            builder.Entity<MeterValue>().Property(p => p.MeterDataId).IsRequired();
            builder.Entity<MeterValue>().Property(p => p.Meter_Id).IsRequired();
            builder.Entity<MeterValue>().Property(p => p.Custormer_Id).IsRequired();
            builder.Entity<MeterValue>().Property(p => p.Hour).IsRequired();
            builder.Entity<MeterValue>().Property(p => p.Value).IsRequired();

            builder.Entity<MeterValue>().HasData
            (
                new MeterValue
                {
                    Id = Guid.Parse("0225c1d9-d950-4a01-abe9-3a7611d205bf"),
                    MeterDataId = Guid.Parse("9fd6ae9f-1e47-471c-b071-65f341bc7cb6"),
                    Meter_Id = "123qwe",
                    Custormer_Id = "asp123",
                    Hour = DateTime.Parse("2018-08-09T01:00:00Z").ToUniversalTime(),
                    Value = 12.4  
                },
                new MeterValue
                {
                    Id = Guid.Parse("3fc009ed-bf8c-461b-8ba8-28cc37badc1f"),
                    MeterDataId = Guid.Parse("9fd6ae9f-1e47-471c-b071-65f341bc7cb6"),
                    Meter_Id = "123qwe",
                    Custormer_Id = "asp123",
                    Hour = DateTime.Parse("2018-08-09T02:00:00Z").ToUniversalTime(),
                    Value = 13.4
                }, new MeterValue
                {
                    Id = Guid.Parse("24ef89ec-f899-4c1e-991c-540933d74fb9"),
                    MeterDataId = Guid.Parse("9fd6ae9f-1e47-471c-b071-65f341bc7cb6"),
                    Meter_Id = "123qwe",
                    Custormer_Id = "asp123",
                    Hour = DateTime.Parse("2018-08-09T03:00:00Z").ToUniversalTime(),
                    Value = 14.4
                }, new MeterValue
                {
                    Id = Guid.Parse("032c8082-e56f-4b94-8354-75564eeaf652"),
                    MeterDataId = Guid.Parse("d3c3783e-3071-4fd0-b852-c72bd5f4b63f"),
                    Meter_Id = "345qwe",
                    Custormer_Id = "qwe345",
                    Hour = DateTime.Parse("2018-08-09T04:00:00Z").ToUniversalTime(),
                    Value = 15.4
                }, new MeterValue
                {
                    Id = Guid.Parse("89e03bb3-1ffc-4031-82a7-e3ebe1f6ca2b"),
                    MeterDataId = Guid.Parse("d3c3783e-3071-4fd0-b852-c72bd5f4b63f"),
                    Meter_Id = "345qwe",
                    Custormer_Id = "asp123",
                    Hour = DateTime.Parse("2018-08-09T17:00:00Z").ToUniversalTime(),
                    Value = 16.4
                }, new MeterValue
                {
                    Id = Guid.Parse("f5c46d23-17c4-4000-84b5-61dda40227cf"),
                    MeterDataId = Guid.Parse("d3c3783e-3071-4fd0-b852-c72bd5f4b63f"),
                    Meter_Id = "345qwe",
                    Custormer_Id = "asp123",
                    Hour = DateTime.Parse("2018-08-09T14:00:00Z").ToUniversalTime(),
                    Value = 17.4
                }, new MeterValue
                {
                    Id = Guid.Parse("89e03bb3-1ffc-4031-82a7-e3eb23d6ca2b"),
                    MeterDataId = Guid.Parse("d3c3783e-3071-4fd0-b852-c72bd5f4b63f"),
                    Meter_Id = "345qwe",
                    Custormer_Id = "asp123",
                    Hour = DateTime.Parse("2018-08-09T13:00:00Z").ToUniversalTime(),
                    Value = 25
                }, new MeterValue
                {
                    Id = Guid.Parse("f5c46d23-17c4-4000-84b5-61ffa40227cf"),
                    MeterDataId = Guid.Parse("d3c3783e-3071-4fd0-b852-c72bd5f4b63f"),
                    Meter_Id = "345qwe",
                    Custormer_Id = "asp123",
                    Hour = DateTime.Parse("2018-08-10T18:00:00Z").ToUniversalTime(),
                    Value = 40
                }
            );
        }
    }
}
