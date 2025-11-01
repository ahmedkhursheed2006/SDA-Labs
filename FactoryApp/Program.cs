using System;
using System.Collections.Generic;

namespace FactoryApp
{
    class MainApp
    {
        static void Main()
        {
            VehicleCreator[] vehicleCreators = new VehicleCreator[3];
            vehicleCreators[0] = new SUVCreator();
            vehicleCreators[1] = new SedanCreator();
            vehicleCreators[2] = new HatchbackCreator();

            foreach (VehicleCreator creator in vehicleCreators)
            {
                Console.WriteLine("\n" + creator.GetType().Name + "--");
                foreach (Feature feature in creator.CurrentVehicle.GetFeatures())
                {
                    Console.WriteLine(" " + feature.GetType().Name);
                }
            }
        }
    }

    abstract class Feature { }

    class ABS : Feature { }

    class CruiseControl : Feature { }

    class EngineCapacity : Feature { }

    class Hybrid : Feature { }

    class EcoMode : Feature { }

    class PushStart : Feature { }

    abstract class Vehicle
    {
        protected List<Feature> features = [];

        public void AddFeature(Feature feature)
        {
            features.Add(feature);
        }

        public List<Feature> GetFeatures()
        {
            return features;
        }
    }

    class SUV : Vehicle { }

    class Sedan : Vehicle { }

    class Hatchback : Vehicle { }

    abstract class VehicleCreator
    {
        private Vehicle vehicle;

        public Vehicle CurrentVehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }
        public abstract void CreateVehicle();
    }

    class SUVCreator : VehicleCreator
    {
        public SUVCreator()
        {
            this.CurrentVehicle = new SUV();
            CreateVehicle();
        }

        public override void CreateVehicle()
        {
            CurrentVehicle.AddFeature(new ABS());
            CurrentVehicle.AddFeature(new CruiseControl());
            CurrentVehicle.AddFeature(new EngineCapacity());
            CurrentVehicle.AddFeature(new PushStart());
            CurrentVehicle.AddFeature(new EcoMode());
        }
    }

    class SedanCreator : VehicleCreator
    {
        public SedanCreator()
        {
            this.CurrentVehicle = new Sedan();
            CreateVehicle();
        }

        public override void CreateVehicle()
        {
            CurrentVehicle.AddFeature(new ABS());
            CurrentVehicle.AddFeature(new CruiseControl());
            CurrentVehicle.AddFeature(new EngineCapacity());
            CurrentVehicle.AddFeature(new Hybrid());
            CurrentVehicle.AddFeature(new PushStart());
        }
    }

    class HatchbackCreator : VehicleCreator
    {
        public HatchbackCreator()
        {
            this.CurrentVehicle = new Hatchback();
            CreateVehicle();
        }

        public override void CreateVehicle()
        {
            CurrentVehicle.AddFeature(new ABS());
            CurrentVehicle.AddFeature(new EngineCapacity());
            CurrentVehicle.AddFeature(new EcoMode());
        }
    }
}
