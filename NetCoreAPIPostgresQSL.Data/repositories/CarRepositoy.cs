using NetCoreAPIPostgresQSL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgresQSL.Data.repositories
{
    public class  CarRepository  : ICarRepository
    {
        public Task<Car> DeletetCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cars>> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetCarDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Car> InsertCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<Car> UpDateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
