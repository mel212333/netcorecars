using NetCoreAPIPostgresQSL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgresQSL.Data.repositories
{
    internal interface ICarRepository
    {
        Task<IEnumerable<Cars>> GetAllCars();
        Task<Car> GetCarDetails(int id);
        Task<Car> InsertCar(Car car);
        Task<Car> UpDateCar(Car car);
        Task<Car> DeletetCar(Car car);

    }
}
