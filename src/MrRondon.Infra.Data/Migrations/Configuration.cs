using System;
using System.Linq;
using System.Collections.Generic;
using MrRondon.Domain.Entities;

namespace MrRondon.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context.MainContext context)
        {
            var userIds = new[]
            {
                Guid.Parse("2A3B3A45-2C1C-4CE1-9618-9D5AA6A2D56F"),
                Guid.Parse("1C868C4A-9EBD-4C8A-91FC-C326A4E9CAE1")
            };
            if (!context.Users.Any())
            {
                var emails = new[] { "administrator", "user" };

                var roles = new List<Role>
                {
                    new Role {RoleId = 1, Name = "Admin", Description = "Usu�rio que controla o sistema."},
                };

                for (var i = 0; i < emails.Length; i++)
                {
                    var cpf = i + 1;
                    var user = new User
                    {
                        UserId = userIds[i],
                        FirstName = "User",
                        LastName = "Master",
                        Cpf = string.Format("{0}{0}{0}.{0}{0}{0}.{0}{0}{0}-{0}{0}", cpf),
                        AccessFailed = 0,
                        Contacts = new List<Contact>
                        {
                            new Contact
                            {
                                ContactId = Guid.NewGuid(),
                                Description = $"{emails[i]}@gmail.com",
                                ContactType = ContactType.Email,
                                UserId = userIds[i]
                            }
                        },
                        Roles = new List<Role> { roles[0] }
                    };
                    user.EncryptPassword("111111");
                    context.Users.Add(user);
                }
            }


            if (!context.ApplicationClients.Any())
            {
                context.ApplicationClients.Add(new ApplicationClient
                {
                    ApplicationClientId = Guid.NewGuid(),
                    Secret = "Mr.Rondon.Turismo.App",
                    Name = "mrrondon.app",
                    RefreshTokenLifeTime = 1,
                    ApplicationType = ApplicationTypes.NativeConfidential,
                    AllowedOrigin = "*",
                    Active = true

                });
            }

            //if (!context.SubCategories.Any())
            //{
            //    context.SubCategories.AddRange(new List<SubCategory>
            //    {
            //        new SubCategory
            //        {
            //            SubCategoryId = 1,
            //            Name = "Aventura"
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 2,
            //            Name = "Rapel",
            //            CategoryId = 1
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 3,
            //            Name = "Camping's",
            //            CategoryId = 1
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 4,
            //            Name = "Aeroclube",
            //            CategoryId = 1
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 5,
            //            Name = "Kart",
            //            CategoryId = 1
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 6,
            //            Name = "Paintball",
            //            CategoryId = 1
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 7,
            //            Name = "AirSoft",
            //            CategoryId = 1
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 8,
            //            Name = "Trilha",
            //            CategoryId = 1
            //        },



            //        new SubCategory
            //        {
            //            SubCategoryId = 9,
            //            Name = "Hospedagem"
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 10,
            //            Name = "Hot�is",
            //            CategoryId = 9
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 11,
            //            Name = "Hot�is Fazenda",
            //            CategoryId = 9
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 12,
            //            Name = "Pousadas",
            //            CategoryId = 9
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 13,
            //            Name = "Resort's",
            //            CategoryId = 9
            //        },

            //        new SubCategory
            //        {
            //            SubCategoryId = 14,
            //            Name = "Gastronomia"
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 15,
            //            Name = "Restaurantes",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 16,
            //            Name = "Pizzarias",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 17,
            //            Name = "Lanchonetes",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 18,
            //            Name = "Restaurantes",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 19,
            //            Name = "Food Truck",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 20,
            //            Name = "Food Truck",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 21,
            //            Name = "Cafeterias",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 22,
            //            Name = "Sorveterias",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 23,
            //            Name = "A�aiterias",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 24,
            //            Name = "Bares",
            //            CategoryId = 14
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 25,
            //            Name = "Drive Thru",
            //            CategoryId = 14
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 26,
            //            Name = "Rent a Car"
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 27,
            //            Name = "Entretenimento",
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 28,
            //            Name = "Botecos",
            //            CategoryId = 27
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 29,
            //            Name = "Boates",
            //            CategoryId = 27
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 30,
            //            Name = "Bilhares",
            //            CategoryId = 27
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 31,
            //            Name = "Shopping",
            //            CategoryId = 27
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 32,
            //            Name = "Cinemas",
            //            CategoryId = 27
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 33,
            //            Name = "Treatros",
            //            CategoryId = 27
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 34,
            //            Name = "Casas de Espet�culos",
            //            CategoryId = 27
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 35,
            //            Name = "Boliches",
            //            CategoryId = 27
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 36,
            //            Name = "Pra�as",
            //            CategoryId = 27
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 37,
            //            Name = "Parques"
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 38,
            //            Name = "Parques Aqu�ticos",
            //            CategoryId = 37
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 39,
            //            Name = "Parques Tem�ticos",
            //            CategoryId = 37
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 40,
            //            Name = "Parques Naturais",
            //            CategoryId = 37
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 41,
            //            Name = "Marinas"
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 42,
            //            Name = "Servi�os �teis"
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 43,
            //            Name = "Aeroporto",
            //            CategoryId = 42
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 44,
            //            Name = "Rodovi�ria",
            //            CategoryId = 42
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 45,
            //            Name = "Coopetaxi",
            //            CategoryId = 42
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 46,
            //            Name = "Hospitais",
            //            CategoryId = 42
            //        },
            //        new SubCategory
            //        {
            //            SubCategoryId = 47,
            //            Name = "Pol�cia",
            //            CategoryId = 42
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 48,
            //            Name = "Loca��o de Equipamentos"
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 49,
            //            Name = "Centro de Conven��es"
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 50,
            //            Name = "Transporte Tur�stico"
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 51,
            //            Name = "Ag�ncias de Turismo"
            //        },


            //        new SubCategory
            //        {
            //            SubCategoryId = 52,
            //            Name = "Promotores de Eventos"
            //        }
            //    });
            //}

            //if (!context.HistoricalSights.Any())
            //{
            //    var address1 = new Address
            //    {
            //        AddressId = Guid.NewGuid(),
            //        Latitude = -8.7526757,
            //        Longitude = -63.9128231,
            //        Neighborhood = "Centro",
            //        Number = "S/N",
            //        Street = "Farquar",
            //        ZipCode = "76.817-003",
            //        CityId = 1
            //    };
            //    var historicalSight = new HistoricalSight
            //    {
            //        HistoricalSightId = 1,
            //        AddressId = address1.AddressId,
            //        Address = address1,
            //        Name = "Principe da Beira",
            //        SightHistory = "A hist�ria � interessante, mas outro vai contar  . . . "
            //    };
            //    context.HistoricalSights.Add(historicalSight);
            //}
            
            context.SaveChanges();
        }
    }
}