using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
   public abstract class Car
    {
        public double Acceleration { get; protected set; } = 10;
        public double Speed { get; protected set; } = 100;

        public void Start()
        {
            Console.WriteLine("Turningo on the engine");
            Console.WriteLine($"running at: {Speed}");
        }


        public void Stop()
        {
            Console.WriteLine("Stopping the car...");
        }

        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating...");
            Speed += Acceleration;
            Console.WriteLine($"Running at: {Speed} km/h");
        }
        public abstract void Boost();
       

    }



    public class Truck : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating...");
            base.Accelerate();
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting Truck...");
            Speed += 50;
            Console.WriteLine($"Running at: {Speed} km/h");
        }
    }
        public class SportCar : Car
        {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating...");
            base.Accelerate();
        }
        public override void Boost()
        {
            Console.WriteLine("Boosting SportCar...");
            Speed += 100;
            Console.WriteLine($"Running at: {Speed} km/h");
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Jestem samochodem");
        }
    }

        public class Race
        {


        public void Begin()
        {
            SportCar sportCar = new SportCar();
            Truck truck = new Truck();

            List<Car> cars = new List<Car>
                {
                    sportCar, truck
                };

            foreach (Car car in cars)
            {
                car.Start();
                car.Accelerate();
                car.Boost();
            }
        }
           public void casting()
        {
          Car sportCar = new SportCar();
            Car truck = new Truck();

            bool isSportCar = sportCar is SportCar;
            if(isSportCar)
            {
                ((SportCar)sportCar).DisplayInfo();
            }
        }
            }
        }


    

    