using BM.Model;
using BM.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BM.Data
{
    public class BirthdaysSeedData : DropCreateDatabaseAlways<BirthdaysEntities>
    {
        private static BirthdaysEntities context;

        protected override void Seed(BirthdaysEntities _context)
        {
            context = _context;

            GetCategories().ForEach(c => context.Categories.Add(c));
            GetGadgets().ForEach(g => context.Gadgets.Add(g));

            GetRoles().ForEach(c => context.Roles.Add(c));
            GetUsers().ForEach(g => context.Users.Add(g));
            context.Commit();

            GetPayments().ForEach(g => context.Payments.Add(g));
            GetGifts().ForEach(g => context.Gifts.Add(g));
            GetBirthdayArrangements().ForEach(g => context.BirthdayArrangements.Add(g));

            context.Commit();
        }

        private static List<AppRole> GetRoles()
        {
            return new List<AppRole>
            {
                new AppRole {
                    Name = "user"
                },
                new AppRole {
                    Name = "admin"
                }
            };
        }

        private static List<AppUser> GetUsers()
        {
            return new List<AppUser>
            {
                new AppUser {
                    AdditionalId = 1,
                    FirstName = "Vladislav",
                    LastName = "Guleaev",
                    OldUsername = "vguleaev",
                    Password = "12345",
                    Balance = 100,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    //RoleId = 2
                },
                new AppUser {
                    AdditionalId = 2,
                    FirstName = "Serghei",
                    LastName = "Tibulschii",
                    OldUsername = "stibulschii",
                    Password = "12345",
                    Balance = -100,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    //RoleId = 2
                },
                new AppUser {
                    AdditionalId = 3,
                    FirstName = "Natalia",
                    LastName = "Curusi",
                    OldUsername = "ncurusi",
                    Password = "12345",
                    Balance = 0,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    //RoleId = 1
                },
                new AppUser {
                    AdditionalId = 4,
                    FirstName = "Sandu",
                    LastName = "Guzun",
                    OldUsername = "sguzun",
                    Password = "12345",
                    Balance = 75,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    //RoleId = 1
                },
                new AppUser {
                    AdditionalId = 5,
                    FirstName = "Alexandru",
                    LastName = "Diacov",
                    OldUsername = "adiacov",
                    Password = "12345",
                    Balance = 0,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    //RoleId = 1
                },
            };
        }

        private static List<Payment> GetPayments()
        {
            return new List<Payment>
            {
                new Payment {
                    UserId = 1,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
                new Payment {
                    UserId = 1,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Serghei",
                },
                new Payment {
                    UserId = 1,
                    Amount = 100,
                    Date = DateTime.Now,
                    Message = "For next birthdays",
                },
                new Payment {
                    UserId = 2,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
                new Payment {
                    UserId = 2,
                    Amount = 100,
                    Date = DateTime.Now,
                    Message = "For Vlad",
                },
                new Payment {
                    UserId = 3,
                    Amount = 50,
                    Date = DateTime.Now,
                    Message = "For Vlad",
                },
                new Payment {
                    UserId = 4,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
                new Payment {
                    UserId = 4,
                    Amount = 200,
                    Date = DateTime.Now,
                    Message = "For next bitrhtdays",
                },
                new Payment {
                    UserId = 5,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
            };
        }

        private static List<Gift> GetGifts()
        {
            return new List<Gift>
            {
                new Gift {
                    GiftId = 1,
                    Price = 1000,
                    Name = "Books"
                },
                new Gift {
                    GiftId = 2,
                    Price = 2000,
                    Name = "Wathces"
                },
                new Gift {
                    GiftId = 3,
                    Price = 1500,
                    Name = "Tattoo sertificate"
                },
                new Gift {
                    GiftId = 4,
                    Price = 700,
                    Name = "Alcohol"
                }
            };
        }

        private static List<BirthdayArrangement> GetBirthdayArrangements()
        {
            DateTime dt = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                    System.Globalization.CultureInfo.InvariantCulture);

            var str = dt.ToString("MM-dd-yyyy");

            dt = DateTime.ParseExact(str, "MM-dd-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);

            var users = context.Users;

            return new List<BirthdayArrangement>
            {
                new BirthdayArrangement
                {
                    BirthdayManId = 3,
                    IsCompleted = true,
                    Date = dt,
                    GiftId = 1,
                    Сongratulators = new List<AppUser>() {
                        users.FirstOrDefault(x => x.AdditionalId == 1),
                        users.FirstOrDefault(x => x.AdditionalId == 2),
                        users.FirstOrDefault(x => x.AdditionalId == 4),
                        users.FirstOrDefault(x => x.AdditionalId == 5)
                    }
                },
                new BirthdayArrangement
                {
                    BirthdayManId = 1,
                    IsCompleted = true,
                    Date = dt,
                    GiftId = 4,
                    Сongratulators = new List<AppUser>() {
                        users.FirstOrDefault(x => x.AdditionalId == 2),
                        users.FirstOrDefault(x => x.AdditionalId == 3),
                        users.FirstOrDefault(x => x.AdditionalId == 4)
                    }
                },
                new BirthdayArrangement
                {
                    BirthdayManId = 4,
                    IsCompleted = false,
                    Date = dt,
                    GiftId = 2,
                    Сongratulators = new List<AppUser>() { }
                },
                 new BirthdayArrangement
                {
                    BirthdayManId = 5,
                    IsCompleted = false,
                    Date = dt,
                    GiftId = 3,
                    Сongratulators = new List<AppUser>() {
                        users.FirstOrDefault(x => x.AdditionalId == 1),
                        users.FirstOrDefault(x => x.AdditionalId == 2)
                    }
                },
            };
        }

        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = "Tablets"
                },
                new Category {
                    Name = "Laptops"
                },
                new Category {
                    Name = "Mobiles"
                }
            };
        }

        private static List<Gadget> GetGadgets()
        {
            return new List<Gadget>
            {
                new Gadget {
                    Name = "ProntoTec 7",
                    Description = "Android 4.4 KitKat Tablet PC, Cortex A8 1.2 GHz Dual Core Processor,512MB / 4GB,Dual Camera,G-Sensor (Black)",
                    CategoryID = 1,
                    Price = 46.99m,
                    Image = "prontotec.jpg"
                },
                new Gadget {
                    Name = "Samsung Galaxy",
                    Description = "Android 4.4 Kit Kat OS, 1.2 GHz quad-core processor",
                    CategoryID = 1,
                    Price = 120.95m,
                    Image= "samsung-galaxy.jpg"
                },
                new Gadget {
                    Name = "NeuTab® N7 Pro 7",
                    Description = "NeuTab N7 Pro tablet features the amazing powerful, Quad Core processor performs approximately Double multitasking running speed, and is more reliable than ever",
                    CategoryID = 1,
                    Price = 59.99m,
                    Image= "neutab.jpg"
                },
                new Gadget {
                    Name = "Dragon Touch® Y88X 7",
                    Description = "Dragon Touch Y88X tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Price = 54.99m,
                    Image= "dragon-touch.jpg"
                },
                new Gadget {
                    Name = "Alldaymall A88X 7",
                    Description = "This Alldaymall tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Price = 47.99m,
                    Image= "Alldaymall.jpg"
                },
                new Gadget {
                    Name = "ASUS MeMO",
                    Description = "Pad 7 ME170CX-A1-BK 7-Inch 16GB Tablet. Dual-Core Intel Atom Z2520 1.2GHz CPU",
                    CategoryID = 1,
                    Price = 94.99m,
                    Image= "asus-memo.jpg"
                },
                // Code ommitted 
            };
        }
    }
}
