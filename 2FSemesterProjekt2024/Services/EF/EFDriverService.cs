﻿using _2FSemesterProjekt2024.Models;
using _2FSemesterProjekt2024.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace _2FSemesterProjekt2024.Services.EF
{
    public class EFDriverService : IDriverService
    {

        private DriverDBContext _context;

        public EFDriverService(DriverDBContext context)
        {
            _context = context; 
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _context.Drivers;
        }

        public void AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }

        public void DeleteDriver(Driver driver)
        {
            _context.Drivers.Remove(driver);
            _context.SaveChanges();
        }

        public Driver GetDrivers(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDriver(Driver driver)
        {
            _context.Update(driver);
            _context.SaveChanges();
        }
    }
}
