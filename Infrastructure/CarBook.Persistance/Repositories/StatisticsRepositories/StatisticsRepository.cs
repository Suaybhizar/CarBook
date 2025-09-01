using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            //Select Top(1) BlogId,Coun(*) as 'Sayi' From Comments Group By BlogId Order By Sayi Desc

            var values = _context.Comments.GroupBy(x => x.BlogId).
                Select(y => new {
                    BlogId = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogID == values.BlogId).Select(y => y.Title).FirstOrDefault();
            return blogName;
        }

        public string GetBrandNameByMaxCar()
        {
            //Select Top(1) Brands.Name,Count(*) as 'ToplamArac' From Cars
            //Inner Join Brands
            //on
            //Cars.BrandID=Brands.BrandID
            //Group By Brands.Name
            //oreder by Count(*) ToplamArac Desc
            var values=_context.Cars.GroupBy(x=>x.BrandID).
                Select(y => new {
                    BrandID=y.Key,
                    Count=y.Count()
                }).OrderByDescending(z=>z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();
            return values;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //Select Avg(Amount) from CarPricings where PricingID=(Select PricingID from Pricings where Name='Günlük')
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var values = _context.Blogs.Count();
            return values;
        }

        public int GetBrandCount()
        {
            var values = _context.Brands.Count();
            return values;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
           // Select * From CarPricings Where Amount = (Select Max(Amount) from CarPricings Where PricingID = 3)
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingID == pricingID).Max(y => y.Amount);
            int carID = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            // Select * From CarPricings Where Amount = (Select Max(Amount) from CarPricings Where PricingID = 3)
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingID == pricingID).Min(y => y.Amount);
            int carID = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmDrivenLessThan1000()
        {
            var value = _context.Cars.Where(x => x.Km < 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
