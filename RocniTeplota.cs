using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv8
{
    class RocniTeplota
    {
        #region Attributes
        private int rok;
        private List<double> mesicniTeploty;

        public int Rok
        {
            get { return rok; }
            set { rok = value; }
        }
        public List<double> MesicniTeploty
        {
            get { return mesicniTeploty; }
            set { mesicniTeploty = value; }
        }
        #endregion

        #region Constructor
        public RocniTeplota(int year, List<double> temperatures)
        {
            MesicniTeploty = temperatures;
            Rok = year;
        }
        #endregion

        #region Methods
        public double MaxTeplota()
        {
            double maximum = MesicniTeploty[0];
            foreach (double temperature in MesicniTeploty)
            {
                if (temperature > maximum) maximum = temperature;
            }
            return maximum;
        }

        public double MinTeplota()
        {
            double minimum = MesicniTeploty[0];
            foreach (double temperature in MesicniTeploty)
            {
                if (temperature < minimum) minimum = temperature;
            }
            return minimum;
        }

        public double PrumRocniTeplota()
        {
            double i = 0;
            double sum = 0;
            foreach (double temperature in MesicniTeploty)
            {
                sum += temperature;
                i++;
            }
            return Math.Round((sum / i), 1, MidpointRounding.AwayFromZero);
        }

        public override string ToString()
        {
            string temperatures = "";
            foreach (double number in MesicniTeploty)
            {
                if (number <= -10)
                {
                    temperatures = temperatures + " " + number + ";";
                }
                else if (number < 0)
                {
                    temperatures = temperatures + "  " + number + ";";
                }
                else if (number < 10)
                {
                    temperatures = temperatures + "   " + number + ";";
                }
                else
                {
                    temperatures = temperatures + "  " + number + ";";
                }
            }
            temperatures.TrimEnd(';');
            return Rok.ToString() + ":" + temperatures;
        }

        public static RocniTeplota ToRocniTeplota(string text)
        {
            string[] split = text.Split(':');
            string[] values = split[1].Split(new char[] { ' ', ';'});
            int year = 0;
            List<double> temperatures = new List<double>();
            try
            {
                year = int.Parse(split[0]);

                foreach (string s in values)
                {
                    if (s.Length > 0)
                    {
                        temperatures.Add(double.Parse(s));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new RocniTeplota(year, temperatures);
        }
        #endregion
    }
}