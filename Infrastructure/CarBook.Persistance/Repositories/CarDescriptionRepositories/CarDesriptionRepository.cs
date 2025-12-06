using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarDescriptionRepositories
{
    public class CarDesriptionRepository : ICarDesriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDesriptionRepository(CarBookContext context)
        {
            _context = context;
        }

        async Task<CarDescription> ICarDesriptionRepository.GetCarDescription(int carId)
        {
            var values = await _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();
            return values;
        }
    }
}
