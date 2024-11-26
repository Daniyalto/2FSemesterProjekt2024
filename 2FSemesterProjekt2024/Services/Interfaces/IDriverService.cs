﻿using _2FSemesterProjekt2024.Models;

namespace _2FSemesterProjekt2024.Services.Interfaces
{
    public interface IDriverService
    {
        public IEnumerable<Driver> GetDrivers();

         public Driver GetDriverById(int did);

        public void AddDriver(Driver driver);

        void DeleteDriver(Driver driver);


        public void UpdateDriver(Driver driver);



    }
}
