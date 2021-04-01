using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv8
{
    class ArchivTeplot
    {
        #region Attributes
        private SortedDictionary<int, RocniTeplota> _archiv;
        #endregion

        #region Constructor
        public ArchivTeplot()
        {
            _archiv = new SortedDictionary<int, RocniTeplota>();
        }

        public ArchivTeplot(SortedDictionary<int, RocniTeplota> data)
        {
            _archiv = data;
        }
        #endregion

        #region Methods
        public void AddData(RocniTeplota data)
        {
            try
            {
                _archiv.Remove(data.Rok);
            }
            catch {}
            _archiv.Add(data.Rok, data);
        }

        public void RemoveData(int year)
        {
            _archiv.Remove(year);
        }

        public void Kalibrace(double constant)
        {
            foreach (var kvp in _archiv)
            {
                for (int i = 0; i < kvp.Value.MesicniTeploty.Count; i++)
                {
                    kvp.Value.MesicniTeploty[i] += constant;
                }
            }
        }

        public RocniTeplota Vyhledej(int year)
        {
            return _archiv[year];
        }

        public void TiskTeplot()
        {
            foreach (var kvp in _archiv)
            {
                Console.WriteLine(kvp.Value.ToString());
            }
        }

        public void TiskPrumernychRocnichTeplot()
        {
            foreach (var kvp in _archiv)
            {
                Console.WriteLine(kvp.Key.ToString() + ":  "+ kvp.Value.PrumRocniTeplota());
            }
        }

        public void TiskPrumernychMesicnichTeplot()
        {
            double[] averages = new double[12];

            for (int i = 0; i < 12; i++)
            {
                double sum = 0;
                foreach (var kvp in _archiv)
                {
                    sum += kvp.Value.MesicniTeploty[i];
                }

                averages[i] = Math.Round((sum / Convert.ToDouble(_archiv.Count())), 1, MidpointRounding.AwayFromZero);
            }

            Console.Write("Prum.:");
            foreach (double value in averages)
            {
                Console.Write("   " + value);
            }
        }

        public void Load(string path)
        {
            try
            {
                foreach (int key in _archiv.Keys)
                {
                    RemoveData(key);
                }
            }
            catch
            {
                Console.WriteLine("Archive was not yet initialized.");
            }
            

            StreamReader reader = File.OpenText(@path);

            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                AddData(RocniTeplota.ToRocniTeplota(line));
            }

            reader.Close();
        }

        public void Save(string path)
        {
            StreamWriter writer = File.CreateText(@path);

            foreach (RocniTeplota data in _archiv.Values)
            {
                writer.WriteLine(data.ToString());
            }

            writer.Close();
        }
        #endregion
    }
}