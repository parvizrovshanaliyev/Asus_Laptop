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

            context.Users.AddOrUpdate(u => new{ u.Email, u.UserName },

            new Models.UserApp
            {

                Email = "parviz@gmail.com",
                UserName = "parvizra",
                Fullname = "ParvizRA",
                Status = true,
                PasswordHash = Crypto.HashPassword("parviz123"),
                SecurityStamp = Crypto.Hash(DateTime.Now.ToString("yyyyMMddHHmmssfff")),
            });

            //context.AspNetUserRoles.Add(new AspNetUserRole
            //{
            //    UserId = "912832aa-5392-4f44-9e92-bfc95031ab79",
            //    RoleId = "3c9db372-f223-40c2-bdc2-99f3f5dd22db",
            //});
            //slider
            //context.Sliders.AddOrUpdate(
            //    new Slider { Image= "slider/d8d0f04a-f306-467d-b427-6dbddfc4ee7c642404c8-0b66-471e-8e2b-a24eeebb8357slider1.jpg" },
            //    new Slider { Image= "slider/46e167d0-ef68-4349-b377-b1be8a33b00e6646838b-0725-4b78-be15-f44af58b959eslider2.jpg" },
            //    new Slider { Image= "slider/9edc6c9b-50d9-4dd1-bd01-2b66ed0bc5c2e645d3e8-2271-43a2-8a6f-8d5a9f7f9e2dslider1.jpg" }
            //    );
            ////banner
            //context.Banners.AddOrUpdate(
            //    new Banner { Image= "banner/b0881184-f37d-4307-b089-e857c39906ecb0dcd30f-6857-4994-99f7-2041fdd61695b2.jpg" },
            //    new Banner { Image = "banner/97f047a5-20fd-4f4c-89d7-a5ce9188d644c9ed58cb-db98-4b68-afa1-f00105d186a2b3.jpg" }
            //    );


            ///blog
            ///

            context.Blogs.AddOrUpdate(b => new { b.Name },

                new Blog {Status=true, Name= "ASUSPRO Series", Title= "SPRING 2019 GAMING LAPTOP GUIDE: ROG RETURNS TO REDEFINE EXPECTATIONS", Description= "Dawn is rising over the Republic of Gamers. The availability of new components like 9th Gen Intel Core processors, NVIDIA GeForce GTX 16-series graphics, and insanely fast 240Hz displays has prompted a top-to-bottom update of our entire gaming laptop family. The ROG Spring 2019", ImageL= "blog/12f712a2-eb2a-4ad2-bcbf-e8c2d6680c940d919222-4e26-4c66-9e66-0a607c8820d4b3.jpg", ImageS= "blog/aaa4e43b-f672-45aa-bf77-205b7894301e0d919222-4e26-4c66-9e66-0a607c8820d4b3.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0) },
                new Blog {Status=true,Name= "ASUS Laptop Series", Title= "Use Motion Graphics templates on ZenBook Pro to spice up your Premiere Pro videos", Description= "Viski is an Estonian actor and hairdresser. He debuted as an actor in 2007 film The Class directed by Ilmar Raag, where he had one of the lead roles. In 2008, Pedaja participated as", ImageL= "blog/06ab0013-4e85-4878-866a-c5d3418d7d306fd1b95a-a530-4ad7-a770-e0767372d034b2.jpg", ImageS= "blog/21e11e73-f053-4aa7-aebb-bd71e319b2eb6fd1b95a-a530-4ad7-a770-e0767372d034b2.jpg", CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0), UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0) },
                new Blog {Status=true, Name= "ASUS TUF Gaming Series", Title= " Motion Graphics templates on ZenBook Pro to spice up your Premiere Pro videos", Description= "Dawn is rising over the Republic of Gamers. The availability of new components like 9th Gen Intel Core processors, NVIDIA GeForce GTX 16-series graphics, and insanely fast 240Hz displays has prompted a top-to-bottom update of our entire gaming laptop family. The ROG Spring 2019", ImageL= "blog/e4b64e15-8e5c-4f04-894f-27b9d03776a00d919222-4e26-4c66-9e66-0a607c8820d4b3.jpg", ImageS= "blog/0d0ff4f8-3f00-4c80-8a6e-fcb9e000ea770d919222-4e26-4c66-9e66-0a607c8820d4b3.jpg", CreateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0), UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0) }

                );

            ///categories
            context.Categories.AddOrUpdate(c => new { c.Name },
                new Category { Name = "ZenBook Series", Status = true },
                new Category { Name = "ZenBook Pro Series", Status = true },
                new Category { Name = "ZenBook S Series", Status = true },
                new Category { Name = "ZenBook Classic Series", Status = true },
                new Category { Name = "VivoBook Series", Status = true },
                new Category { Name = "VivoBook Pro Series", Status = true },
                new Category { Name = "VivoBook S Series", Status = true },
                new Category { Name = "VivoBook Classic Series", Status = true },
                new Category { Name = "StudioBook Series", Status = true },
                new Category { Name = "Chromebook Series", Status = true },
                new Category { Name = "ASUSPRO Series", Status = true },
                new Category { Name = "Gaming Series", Status = true },
                new Category { Name = "ASUS TUF Gaming Series", Status = true }
                );


            ////product 20 tane
            context.Products.AddOrUpdate(p => new {p.Model},

                new Product
                {
                    Status = true,
                    Brand = "Asus",
                    Model = "TP202NA-DH01T 1",
                    CategoryId = 44,
                    IsNew = true,
                    Price = 1000,
                    Colors = "1",
                    Discount = 4,
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
                Model = "TP202NA-DH01T 2",
                CategoryId = 45,
                IsNew = true,
                Price = 1000,
                Colors = "1",
                Discount = 4,
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
                Model = "TP202NA-DH01T 3",
                CategoryId = 46,
                IsNew = true,
                Price = 1000,
                Colors = "1",
                Discount = 4,
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
            new Product
            {
                Status = true,
                Brand = "Asus",
                Model = "TP202NA-DH01T 4",
                CategoryId = 45,
                IsNew = true,
                Price = 1230,
                Colors = "1",
                Discount = 4,
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
                Model = "TP202NA-DH01T 5",
                CategoryId = 45,
                IsNew = true,
                Price = 1234,
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
            new Product
            {
                Status = true,
                Brand = "Asus",
                Model = "TP202NA-DH01T 6",
                CategoryId = 44,
                IsNew = true,
                Price = 1234,
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
            new Product
            {
                Status = true,
                Brand = "Asus",
                Model = "TP202NA-DH01T 7",
                CategoryId = 46,
                IsNew = true,
                Price = 1234,
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
            new Product
            {
                Status = true,
                Brand = "Asus",
                Model = "TP202NA-DH01T 8",
                CategoryId = 47,
                Price = 1234,
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
            new Product
            {
                Status = true,
                Brand = "Asus",
                Model = "TP202NA-DH01T 9",
                CategoryId = 47,
                Price = 1234,
                Colors = "1",
                Discount = 5,
                OperatingSystem = "Windows 10 Pro",
                Display = " '11.6' HD(1366 * 768)",
                Graphic = "Intel HD",
                Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                Memory = "16GB DDR3 (On Board)",
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
                Model = "TP202NA-DH01T 10",
                CategoryId = 48,
                IsNew = true,
                Price = 1234,
                Colors = "1",
                Discount = 0,
                OperatingSystem = "Windows 10 Pro",
                Display = " '11.6' HD(1366 * 768)",
                Graphic = "Intel HD",
                Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                Memory = "16GB DDR3 (On Board)",
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
                Model = "TP202NA-DH01T 11",
                CategoryId = 49,
                Price = 1234,
                Colors = "1",
                Discount = 0,
                OperatingSystem = "Windows 10 Pro",
                Display = " '11.6' HD(1366 * 768)",
                Graphic = "Intel HD",
                Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                Memory = "16GB DDR3 (On Board)",
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
                Model = "TP202NA-DH01T 12",
                CategoryId = 49,
                IsNew = true,
                Price = 2345,
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
                CategoryId = 50,
                IsNew = true,
                Price = 2345,
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
                Model = "TP202NA-DH01T 14",
                CategoryId = 50,
                Price = 2000,
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
                Model = "TP202NA-DH01T 15",
                CategoryId = 53,
                Price = 2345,
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
                Model = "TP202NA-DH01T 16",
                CategoryId = 50,
                Price = 3003,
                Colors = "1",
                Discount = 3,
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
                UpdateAt = new DateTime(2019, 03, 08, 09, 44, 0, 0)
            },
            new Product
            {
                Status = true,
                Brand = "Asus",
                Model = "TP202NA-DH01T 17",
                CategoryId = 51,
                Price = 1234,
                Colors = "1",
                Discount = 6,
                OperatingSystem = "Windows 10 Pro",
                Display = " '11.6' HD(1366 * 768)",
                Graphic = "Intel HD",
                Processor = "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",
                Memory = "8GB DDR3 (On Board)",
                Storage = "1TB EMMC",
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
                Model = "TP202NA-DH01T 18",
                CategoryId = 51,
                Price = 456,
                IsNew = true,
                Colors = "1",
                Discount = 6,
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
                Model = "TP202NA-DH01T 19",
                CategoryId = 54,
                Price = 456,
                IsNew = true,
                Colors = "1",
                Discount = 1,
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
                Model = "TP202NA-DH01T 20",
                CategoryId = 52,
                Price = 678,
                IsNew = true,
                Colors = "1",
                Discount = 1,
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
            }

            );
            ///// product images
            ///

            context.ProductImages.AddOrUpdate(
                new ProductImage { ProductId = 9, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId = 9, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId = 9, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId = 9, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },



                new ProductImage {ProductId=10, Image= "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage {ProductId= 10, Image= "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage {ProductId= 10, Image= "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage {ProductId= 10, Image= "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=11, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=11, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=11, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=11, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=12, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=12, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=12, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=12, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=13, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=13, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=13, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=13, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },


                new ProductImage { ProductId=14, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=14, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=14, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=14, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=15, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=15, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=15, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=15, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=16, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=16, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=16, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=16, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=17, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=17, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=17, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=17, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=18, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=18, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=18, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=18, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=19, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=19, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=19, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=19, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=20, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=20, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=20, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=20, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=21, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=21, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=21, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=21, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=22, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=22, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=22, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=22, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=23, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=23, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=23, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=23, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=24, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=24, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=24, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=24, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=25, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=25, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=25, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=25, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },


                new ProductImage { ProductId=26, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=26, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=26, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=26, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },

                new ProductImage { ProductId=27, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=27, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=27, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=27, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" },


                new ProductImage { ProductId=28, Image = "productsMultiples/9594a497-d167-4cc0-9e56-60dab7045aea5a2bb6dd-c980-4823-81ed-0be724a6a4f2fd84a367-6a54-4d8c-bf4b-0150d293db39ASUS_VivoBook_Flip4.jpg" },
                new ProductImage { ProductId=28, Image = "productsMultiples/825af3db-fa76-4e3e-8b4f-ebd2800f1a626b9f4374-4649-41cc-8aca-bd393b054b11d6c020bd-563f-46b3-9c9c-438b50f1772eASUS_VivoBook_Flip3.jpg" },
                new ProductImage { ProductId=28, Image = "productsMultiples/755b7e24-7636-49d9-b297-dc6b88c14f432586ffb7-d754-4e20-b5b4-038a76cf11dc38794e78-e310-483f-bd7a-9a36ea1f6396ASUS VivoBook Flip.jpg" },
                new ProductImage { ProductId=28, Image = "productsMultiples/6d396c51-0e20-48be-9b04-1f34c80d26beea15d943-4ba1-42d3-961b-e11c72371937aa112be1-67f6-4d9a-8ae7-048f253d52c8ASUS_VivoBook_Flip2.jpg" }
                
                );
        }
    }
}
