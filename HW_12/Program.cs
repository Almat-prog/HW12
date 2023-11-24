using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    class Program
    {
        static void Main()
        {
            SportsCar sportsCar = new SportsCar("Спортивный автомобиль");
            SedanCar sedanCar = new SedanCar("Легковой автомобиль");
            Truck truck = new Truck("Грузовик");
            Bus bus = new Bus("Автобус");

            
            RacingGame racingGame = new RacingGame();

            racingGame.AddCar(sportsCar);
            racingGame.AddCar(sedanCar);
            racingGame.AddCar(truck);
            racingGame.AddCar(bus);

            racingGame.RaceFinished += racingGame_OnRaceFinished;

            racingGame.StartRace();

            Console.ReadLine(); 
        }

        
        private static void racingGame_OnRaceFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Гонка завершена!");
        }
    }

}
