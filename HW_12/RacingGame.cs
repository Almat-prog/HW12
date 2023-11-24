using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    public class RacingGame
    {
        public event Car.FinishEventHandler RaceFinished;

        private List<Car> cars;

        public RacingGame()
        {
            cars = new List<Car>();
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
            car.Finish += Car_Finish;
        }

        public void StartRace()
        {
            Console.WriteLine("Гонка началась!");

            while (true)
            {
                foreach (var car in cars)
                {
                    car.Move(); 
                    Console.WriteLine($"{car.Model}: {car.Position}");
                }

                
                if (cars.Any(c => c.Position >= 100))
                {
                    
                    OnRaceFinished(cars.First(c => c.Position >= 100));
                    return;
                }

                Console.WriteLine("-------------");
                System.Threading.Thread.Sleep(500); 
            }
        }

        
        protected virtual void OnRaceFinished(Car winner)
        {
            RaceFinished?.Invoke(winner, EventArgs.Empty);
        }

        
        private void Car_Finish(object sender, EventArgs e)
        {
            Console.WriteLine($"Гонка завершена! Победил автомобиль: {((Car)sender).Model}");
            
            Environment.Exit(0);
        }
    }

}
