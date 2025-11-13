using Dapper;
using NetCoreAPIPostgresQSL.Model; // Asumo que aquí está la clase Car
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgresQSL.Data.repositories
{
    public class CarRepository : ICarRepository
    {
        private PostgresSQLConfiguration _connectionString;

        public CarRepository(PostgresSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection bdConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        // --- Método Corregido 1: DeletetCar (Delete) ---
        public async Task<bool> DeleteCar(Car car) // 1. Cambié el nombre del método (DeletetCar -> DeleteCar) y el tipo de retorno (Task<Car> -> Task<bool>)
        {
            var db = bdConnection();
            var sql = @"
                    DELETE                          -- 2. Corregido: DELTE -> DELETE
                    FROM public.""Cars""
                    WHERE id = @Id";                // 3. Corregido: WHARE -> WHERE

            // 4. Se necesita la propiedad Id en la clase Car (ver respuesta anterior)
            var result = await db.ExecuteAsync(sql, new { car.Id });

            // ExecuteAsync devuelve el número de filas afectadas.
            return result > 0;
        }

        // --- Método Corregido 2: GetAllCars (Select All) ---
        public async Task<IEnumerable<Car>> GetAllCars() // 1. Cambié el tipo de retorno (Task<IEnumerable<Cars>> -> Task<IEnumerable<Car>>)
        {
            var db = bdConnection();
            var sql = @"
                    SELECT id, make, model, color, year, doors
                    FROM public.""Cars""";  // 2. Consulta corregida para obtener TODOS los carros (sin WHERE)

            // 3. Se usa QueryAsync para obtener una lista de objetos
            return await db.QueryAsync<Car>(sql);
        }

        // --- Método Corregido 3: GetCarDetails (Select One) ---
        // (Asumo que esta implementación es la que querías para GetCarDetails)
        public async Task<Car> GetCarDetails(int id)
        {
            var db = bdConnection();
            var sql = @"
                    SELECT id, make, model, color, year, doors
                    FROM public.""Cars""
                    WHERE id = @Id"; // 1. Usé @Id para el parámetro

            // 2. QueryFirstOrDefaultAsync se usa para obtener UN objeto y acepta el id como parámetro
            return await db.QueryFirstOrDefaultAsync<Car>(sql, new { Id = id });
        }


        // --- Método Corregido 4: InsertCar ---
        public async Task<bool> InsertCar(Car car) // 1. Cambié el tipo de retorno (Task<Car> -> Task<bool>)
        {
            var db = bdConnection();
            var sql = @"
                    INSERT INTO public.""Cars""(make, model, color, year, doors)
                    VALUES(@Make, @Model, @Color ,@Year, @Doors)";

            // 2. Uso las propiedades directamente del objeto 'car'
            var result = await db.ExecuteAsync(sql, car);

            return result > 0;
        }

        // --- Método Corregido 5: UpDateCar (Update) ---
        public async Task<bool> UpDateCar(Car car) // 1. Cambié el tipo de retorno (Task<Car> -> Task<bool>) y el nombre (UpDateCar -> UpdateCar)
        {
            var db = bdConnection();
            var sql = @"
                    UPDATE public.""Cars""
                    SET make = @Make,
                        model = @Model,
                        color = @Color,
                        year = @Year,
                        doors = @Doors
                    WHERE id = @Id"; // 2. Agregué @Id al final de la cláusula WHERE y eliminé la coma después de 'doors'

            // 3. Se necesita el objeto Car completo, incluyendo el Id, para que Dapper pueda mapear todos los parámetros
            var result = await db.ExecuteAsync(sql, car);

            return result > 0;
        }
    }
}