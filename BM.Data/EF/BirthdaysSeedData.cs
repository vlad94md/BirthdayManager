using BM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BM.Data.EF
{
    public class BirthdaysSeedData : DropCreateDatabaseAlways<BirthdaysContext>
    {
        private static BirthdaysContext context;

        protected override void Seed(BirthdaysContext _context)
        {
            context = _context;

            if(context.Users.Any())
                return;

            GetRoles().ForEach(c => context.Roles.Add(c));
            GetUsers().ForEach(g => context.Users.Add(g));
            context.SaveChanges();

            GetPayments().ForEach(g => context.Payments.Add(g));
            GetGifts().ForEach(g => context.Gifts.Add(g));
            GetBirthdayArrangements().ForEach(g => context.BirthdayArrangements.Add(g));

            context.SaveChanges();
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
            var currentDate = DateTime.Now;
            string thisMonth = currentDate.Month > 10 ? currentDate.Month.ToString() : ("0" + currentDate.Month);


            return new List<AppUser>
            {
                new AppUser {
                    FirstName = "Vladislav",
                    LastName = "Guleaev",
                    UserName= "vguleaev",
                    PasswordHash = stringToBase64ByteArray("12345"),
                    Balance = 100,
                    DateOfBirth = DateTime.ParseExact("1994.01." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
                new AppUser {
                    FirstName = "Serghei",
                    LastName = "Tibulschii",
                    UserName = "stibulschii",
                    PasswordHash = stringToBase64ByteArray("12345"),
                    Balance = -100,
                    DateOfBirth = DateTime.ParseExact("1994.05." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
                new AppUser {
                    FirstName = "Natalia",
                    LastName = "Curusi",
                    UserName = "ncurusi",
                    PasswordHash = stringToBase64ByteArray("12345"),
                    Balance = 0,
                    DateOfBirth = DateTime.ParseExact("1980.15." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
                new AppUser {
                    FirstName = "Sandu",
                    LastName = "Guzun",
                    UserName = "sguzun",
                    PasswordHash = stringToBase64ByteArray("12345"),
                    Balance = 75,
                    DateOfBirth = DateTime.ParseExact("1992.20." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
                new AppUser {
                    FirstName = "Alexandru",
                    LastName = "Diacov",
                    UserName = "adiacov",
                    PasswordHash = stringToBase64ByteArray("12345"),
                    Balance = 0,
                    DateOfBirth = DateTime.ParseExact("1993.25." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
            };
        }

        private static List<Payment> GetPayments()
        {
            var users = context.Users.ToList();

            return new List<Payment>
            {
                new Payment {
                    UserId = users[0].Id,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
                new Payment {
                    UserId = users[0].Id,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Serghei",
                },
                new Payment {
                    UserId = users[0].Id,
                    Amount = 100,
                    Date = DateTime.Now,
                    Message = "For next birthdays",
                },
                new Payment {
                    UserId = users[1].Id,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
                new Payment {
                    UserId = users[1].Id,
                    Amount = 100,
                    Date = DateTime.Now,
                    Message = "For Vlad",
                },
                new Payment {
                    UserId = users[2].Id,
                    Amount = 50,
                    Date = DateTime.Now,
                    Message = "For Vlad",
                },
                new Payment {
                    UserId = users[3].Id,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
                new Payment {
                    UserId = users[3].Id,
                    Amount = 200,
                    Date = DateTime.Now,
                    Message = "For next bitrhtdays",
                },
                new Payment {
                    UserId = users[4].Id,
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
                    Id = 1,
                    Price = 1000,
                    Name = "Books"
                },
                new Gift {
                    Id = 2,
                    Price = 2000,
                    Name = "Wathces"
                },
                new Gift {
                    Id = 3,
                    Price = 1500,
                    Name = "Tattoo sertificate"
                },
                new Gift {
                    Id = 4,
                    Price = 700,
                    Name = "Alcohol"
                }
            };
        }

        private static List<BirthdayArrangement> GetBirthdayArrangements()
        {
            var users = context.Users.ToList();

            return new List<BirthdayArrangement>
            {
                new BirthdayArrangement
                {
                    BirthdayMan = users.FirstOrDefault(x => x.UserName == "ncurusi"),
                    IsCompleted = true,
                    GiftId = 1,
                    Date = users.First(x => x.UserName == "ncurusi").DateOfBirth,
                    Сongratulators = new List<AppUser>() {
                        users.FirstOrDefault(x => x.UserName == "vguleaev"),
                        users.FirstOrDefault(x => x.UserName == "stibulschii"),
                        users.FirstOrDefault(x => x.UserName == "sguzun"),
                        users.FirstOrDefault(x => x.UserName == "adiacov")
                    }
                },
                new BirthdayArrangement
                {
                    BirthdayMan = users.FirstOrDefault(x => x.UserName == "vguleaev"),
                    IsCompleted = true,
                    GiftId = 4,
                    Date = users.First(x => x.UserName == "vguleaev").DateOfBirth,
                    Сongratulators = new List<AppUser>() {
                        users.FirstOrDefault(x => x.UserName == "stibulschii"),
                        users.FirstOrDefault(x => x.UserName == "ncurusi"),
                        users.FirstOrDefault(x => x.UserName == "sguzun")
                    }
                },
                new BirthdayArrangement
                {
                    BirthdayMan = users.FirstOrDefault(x => x.UserName == "sguzun"),
                    IsCompleted = false,
                    GiftId = 2,
                    Date = users.First(x => x.UserName == "sguzun").DateOfBirth,
                    Сongratulators = new List<AppUser>() { }
                },
                 new BirthdayArrangement
                {
                    BirthdayMan = users.FirstOrDefault(x => x.UserName == "adiacov"),
                    IsCompleted = false,
                    GiftId = 3,
                    Date = users.First(x => x.UserName == "adiacov").DateOfBirth,
                    Сongratulators = new List<AppUser>() {
                        users.FirstOrDefault(x => x.UserName == "vguleaev"),
                        users.FirstOrDefault(x => x.UserName == "stibulschii")
                    }
                },
            };
        }

        private static string stringToBase64ByteArray(String input)
        {
            byte[] ret = System.Text.Encoding.Unicode.GetBytes(input);
            string s = Convert.ToBase64String(ret);
            return s;
        }
    }
}
