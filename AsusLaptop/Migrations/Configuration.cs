namespace AsusLaptop.Migrations
{
    using AsusLaptop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<AsusLaptop.DAL.AsusDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AsusLaptop.DAL.AsusDbContext context)
        {
            context.Roles.AddOrUpdate(r => new { r.Name }, new RoleApp { Name = "admin" }, new RoleApp { Name = "member" });

            context.Users.AddOrUpdate(u => new { u.Email, u.UserName },

               new Models.UserApp
               {

                   Email = "parviz@gmail.com",
                   UserName = "parvizra",
                   Fullname="ParvizRA",
                   Status = true,
                   PasswordHash = Crypto.HashPassword("parviz123"),
                   SecurityStamp = Crypto.Hash(DateTime.Now.ToString("yyyyMMddHHmmssfff")),
               });

            //context.AspNetUserRoles.Add(new AspNetUserRole
            //{
            //    UserId = "44b8d597-3913-4d59-bb43-a9faad0c48ed",
            //    RoleId = "fdea3a88-9798-47fa-9ae6-3cd6560d1409",
            //});

            context.Products.AddOrUpdate(p => new { p.Model },

                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 12",
                    CategoryId = 1,
                    Price = 199,
                    Colors = "1",
                    Discount = 0,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "4GB DDR3 (On Board)",
                    Storage = "512GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 12",
                    CategoryId = 4,
                    Price = 1000,
                    Colors = "1",
                    Discount = 10,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "4GB DDR3 (On Board)",
                    Storage = "512GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    IsNew = true

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 12",
                    CategoryId = 5,
                    Price = 1200,
                    Colors = "1",
                    Discount = 10,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "16GB DDR3 (On Board)",
                    Storage = "512GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    IsNew = true

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 12",
                    CategoryId = 1,
                    Price = 199,
                    Colors = "1",
                    Discount = 0,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "16GB DDR3 (On Board)",
                    Storage = "512GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },

                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 13",
                    CategoryId = 6,
                    Price = 1234,
                    Colors = "1",
                    Discount = 3,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "16GB DDR3 (On Board)",
                    Storage = "512GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 14",
                    CategoryId = 1,
                    Price = 567,
                    Colors = "1",
                    Discount = 5,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "8GB DDR3 (On Board)",
                    Storage = "512GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },

                //cat2
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 36",
                    CategoryId = 7,
                    Price = 2000,
                    Colors = "1",
                    Discount = 5,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "32GB DDR3 (On Board)",
                    Storage = "1TB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    IsNew = true

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 37",
                    CategoryId = 4,
                    Price = 500,
                    Colors = "1",
                    Discount = 0,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "32GB DDR3 (On Board)",
                    Storage = "1TB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    IsNew = true

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 38",
                    CategoryId = 4,
                    Price = 199,
                    Colors = "8",
                    Discount = 0,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "32GB DDR3 (On Board)",
                    Storage = "256GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    IsNew = true

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 39",
                    CategoryId = 9,
                    Price = 3400,
                    Colors = "1",
                    Discount = 3,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "32GB DDR3 (On Board)",
                    Storage = "512GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 40",
                    CategoryId = 4,
                    Price = 1500,
                    Colors = "1",
                    Discount = 3,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "32GB DDR3 (On Board)",
                    Storage = "32GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 41",
                    CategoryId = 9,
                    Price = 1230,
                    Colors = "1",
                    Discount = 5,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "32GB DDR3 (On Board)",
                    Storage = "256GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    IsNew = true

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 42",
                    CategoryId = 4,
                    Price = 456,
                    Colors = "1",
                    Discount = 0,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "4GB DDR3 (On Board)",
                    Storage = "256GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },


                ///cat3
                ///
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 63",
                    CategoryId = 5,
                    Price = 678,
                    Colors = "1",
                    Discount = 4,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "4GB DDR3 (On Board)",
                    Storage = "256GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 64",
                    CategoryId = 5,
                    Price = 456,
                    Colors = "1",
                    Discount = 0,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "4GB DDR3 (On Board)",
                    Storage = "256GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 65",
                    CategoryId = 7,
                    Price = 199,
                    Colors = "1",
                    Discount = 0,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "4GB DDR3 (On Board)",
                    Storage = "32GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 66",
                    CategoryId = 8,
                    Price = 1234,
                    Colors = "1",
                    Discount = 3,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "8GB DDR3 (On Board)",
                    Storage = "256GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 67",
                    CategoryId = 6,
                    Price = 678,
                    Colors = "1",
                    Discount = 3,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "8GB DDR3 (On Board)",
                    Storage = "256GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 68",
                    CategoryId = 8,
                    Price = 1256,
                    Colors = "1",
                    Discount = 5,
                    OperatingSystem = "Windows 10 Pro",
                    Display = " '11.6' HD(1366 * 768)",
                    Graphic = "Intel HD",
                    Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                    Memory = "4GB DDR3 (On Board)",
                    Storage = "32GB EMMC",
                    Wireless = "Wireless Data Network 802.11AC Bluetooth 4.1",
                    Dimensions = "'11.0' x 7.9' x 0.7'",
                    Ports = "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",
                    Weight = "2.8 lbs",
                    ImageL = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageM = "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",
                    ImageS = "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",
                    CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0),
                    UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)

                }
                );
        }
    }
}
