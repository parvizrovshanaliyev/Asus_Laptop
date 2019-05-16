namespace AsusLaptop.Migrations
{
    using AsusLaptop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AsusLaptop.DAL.AsusDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AsusLaptop.DAL.AsusDbContext context)
        {

            context.Products.AddOrUpdate(p => new { p.Model },
                
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 12", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

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
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 12", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },

                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 13", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 14", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 15", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 16", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 17", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 18", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 19", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 20", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 21", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 22", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 23", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 24", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 25", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 26", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 27", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 28", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 29", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 30", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 31", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 32", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 33", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 34", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                },
                new Product
                {
                    Status=true, Brand="Asus", Model= "TP202NA-DH01T 35", CategoryId=1,Price=199, Colors="1", Discount=0, OperatingSystem= "Windows 10 Pro", Display= " '11.6' HD(1366 * 768)", Graphic= "Intel HD",Processor= "Intel Dual-Core Celeron N3350 1.1GHz (Turbo up to 2.4GHz)",Memory= "4GB DDR3 (On Board)",Storage= "32GB EMMC",Wireless= "Wireless Data Network 802.11AC Bluetooth 4.1",Dimensions= "'11.0' x 7.9' x 0.7'", Ports= "1x Headphone-out & Audio-in Combo Jack,1x HDMI,1x USB 2.0,1x USB 3.0,1x Micro SD (SD, MMC) Card Reader",Weight= "2.8 lbs",ImageL= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageM= "products/b7b7c20d-fe62-471c-ba0c-0a5bafa8aeb5ASUS VivoBook Flip.jpg",ImageS= "products/2602777f-a13c-4bae-86c6-fe7e5cf1b75dASUS_VivoBook_Flip_mini.jpg",CreateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0),UpdateAt= new DateTime(2019, 03, 08, 09, 44, 0, 0)

                }

                );
        }
    }
}
