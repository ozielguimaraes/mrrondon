using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MrRondon.Domain.Entities;
using MrRondon.Infra.Security.Entities;

namespace MrRondon.Services.Api.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context.MainContext context)
        {
            if (!context.Clients.Any())
            {
                context.Clients.Add(new Client
                {
                    ClientId = Guid.NewGuid(),
                    Secret = "Mr.Rondon.Turismo.App",
                    Name = "mrrondon.app",
                    RefreshTokenLifeTime = 1,
                    ApplicationType = ApplicationTypes.NativeConfidential,
                    AllowedOrigin = "*",
                    Active = true

                });
            }
            if (context.Categories.Any()) return;

            context.Categories.AddRange(new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Aventura"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Hospedagem"
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Servi�os �teis"
                },
                new Category
                {
                    CategoryId = 4,
                    Name = "Gastronomia"
                },
                new Category
                {
                    CategoryId = 5,
                    Name = "Aeroclube",
                    SubCategoryId = 1
                },
                new Category
                {
                    CategoryId = 6,
                    Name = "Airsoft",
                    SubCategoryId = 1
                },
                new Category
                {
                    CategoryId = 7,
                    Name = "Camping",
                    SubCategoryId = 1
                }
            });

            if (!context.Events.Any())
            {
                var address1 = new Address
                {
                    AddressId = Guid.NewGuid(),
                    Latitude = -8.8013796,
                    Longitude = -63.9260293,
                    Neighborhood = "Centro",
                    Number = "S/N",
                    Street = "Farquar",
                    ZipCode = "76.817-003"
                };

                var address2 = new Address
                {
                    AddressId = Guid.NewGuid(),
                    Latitude = -12.4242083,
                    Longitude = -64.4219781,
                    Neighborhood = "Centro",
                    Number = "S/N",
                    Street = "Farquar",
                    ZipCode = "76.817-003"
                };

                context.Events.AddRange(
                    new List<Event>
                    {
                        new Event
                        {
                            EventId = Guid.NewGuid(),
                            AddressId = address1.AddressId,
                            Address = address1,
                            Name = "Luminato Festival",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(2),
                            Value = 10
                        },
                        new Event
                        {
                            EventId = Guid.NewGuid(),
                            AddressId = address2.AddressId,
                            Address = address2,
                            Name = "Canadian National Exhibition",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(1),
                            Value = 100
                        }
                    }
                );
            }

            context.SaveChanges();
        }
    }
}