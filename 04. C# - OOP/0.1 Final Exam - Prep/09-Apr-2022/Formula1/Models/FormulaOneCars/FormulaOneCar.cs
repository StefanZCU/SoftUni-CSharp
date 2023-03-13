namespace Formula1.Models.FormulaOneCars
{
    using System;

    using Contracts;
    using Utilities;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }

                model = value;
            }
        }
        public int Horsepower
        {
            get => horsePower;
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }

                horsePower = value;
            }
        }
        public double EngineDisplacement
        {
            get => engineDisplacement;
            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }

                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps) => engineDisplacement / horsePower * laps;
    }
}
