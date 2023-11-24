using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    
    public abstract class Car
    {
        public string Model { get; set; }
        public int Position { get; protected set; }
        public int Speed { get; protected set; }

        
        public delegate void FinishEventHandler(object sender, EventArgs e);
        public event FinishEventHandler Finish;

        
        public Car(string model)
        {
            Model = model;
            Position = 0;
            Speed = 0;
        }

        
        public virtual void Move()
        {
            Speed = new Random().Next(1, 20);
            Position += Speed;
        }

        
        protected virtual void OnFinish()
        {
            Finish?.Invoke(this, EventArgs.Empty);
        }
    }
    
    public class SportsCar : Car
    {
        public SportsCar(string model) : base(model) { }

        
        public override void Move()
        {
            Speed = new Random().Next(10, 30);
            Position += Speed;
            // Проверка на финиш при каждом движении
            if (Position >= 100)
            {
                OnFinish();
            }
        }
    }

    // Класс легкового автомобиля
    public class SedanCar : Car
    {
        public SedanCar(string model) : base(model) { }

        // Переопределение метода для изменения скорости легкового автомобиля
        public override void Move()
        {
            Speed = new Random().Next(5, 15);
            Position += Speed;
            if (Position >= 100)
            {
                OnFinish();
            }
        }
    }

    public class Truck : Car
    {
        public Truck(string model) : base(model) { }

        public override void Move()
        {
            Speed = new Random().Next(1, 10);
            Position += Speed;
            if (Position >= 100)
            {
                OnFinish();
            }
        }
    }

    
    public class Bus : Car
    {
        public Bus(string model) : base(model) { }

        public override void Move()
        {
            Speed = new Random().Next(3, 12);
            Position += Speed;
            if (Position >= 100)
            {
                OnFinish();
            }
        }
    }

}
