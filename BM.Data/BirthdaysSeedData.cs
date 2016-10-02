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

        private static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role {
                    RoleId = 1,
                    Name = "user"
                },
                new Role {
                    RoleId = 2,
                    Name = "admin"
                }
            };
        }

        private static List<User> GetUsers()
        {
            return new List<User>
            {
                new User {
                    UserId = 1,
                    FirstName = "Vladislav",
                    LastName = "Guleaev",
                    Username = "vguleaev",
                    Password = "12345",
                    Balance = 100,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    RoleId = 2
                },
                new User {
                    UserId = 2,
                    FirstName = "Serghei",
                    LastName = "Tibulschii",
                    Username = "stibulschii",
                    Password = "12345",
                    Balance = -100,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    RoleId = 2
                },
                new User {
                    UserId = 3,
                    FirstName = "Natalia",
                    LastName = "Curusi",
                    Username = "ncurusi",
                    Password = "12345",
                    Balance = 0,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    RoleId = 1
                },
                new User {
                    UserId = 4,
                    FirstName = "Sandu",
                    LastName = "Guzun",
                    Username = "sguzun",
                    Password = "12345",
                    Balance = 75,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    RoleId = 1
                },
                new User {
                    UserId = 5,
                    FirstName = "Alexandru",
                    LastName = "Diacov",
                    Username = "adiacov",
                    Password = "12345",
                    Balance = 0,
                    DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                    RoleId = 1
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
                    Сongratulators = new List<User>() {
                        users.FirstOrDefault(x => x.UserId == 1),
                        users.FirstOrDefault(x => x.UserId == 2),
                        users.FirstOrDefault(x => x.UserId == 4),
                        users.FirstOrDefault(x => x.UserId == 5)
                    }
                },
                new BirthdayArrangement
                {
                    BirthdayManId = 1,
                    IsCompleted = true,
                    Date = dt,
                    GiftId = 4,
                    Сongratulators = new List<User>() {
                        users.FirstOrDefault(x => x.UserId == 2),
                        users.FirstOrDefault(x => x.UserId == 3),
                        users.FirstOrDefault(x => x.UserId == 4)
                    }
                },
                new BirthdayArrangement
                {
                    BirthdayManId = 4,
                    IsCompleted = false,
                    Date = dt,
                    GiftId = 2,
                    Сongratulators = new List<User>() { }
                },
                 new BirthdayArrangement
                {
                    BirthdayManId = 5,
                    IsCompleted = false,
                    Date = dt,
                    GiftId = 3,
                    Сongratulators = new List<User>() {
                        users.FirstOrDefault(x => x.UserId == 1),
                        users.FirstOrDefault(x => x.UserId == 2)
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
