using NMP_Quoting_System.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NMP_Quoting_System.Services
{
    public class GearboxSelectionService
    {

        public ObservableCollection<ARWGearbox> arwGearboxes;
        public IEnumerable<ARWGearbox>? sameTypeGearboxes;
        public IEnumerable<ARWGearbox>? sameRatingGearboxes;
        public IEnumerable<ARWGearbox>? samePolesGearboxes;
        public IEnumerable<ARWGearbox>? sameFinalRpmGearboxes;
        public List<String> gearboxTypes;

        public GearboxSelectionService()
        {
            arwGearboxes = new ObservableCollection<ARWGearbox>();

            ARWGearbox arwGearbox = new ARWGearbox(0.18, "ARW", 30, 7.5, 2, 1400, 187, 7.7, 14, 2.3);
            ARWGearbox arwGearbox2 = new ARWGearbox(0.15, "ARW", 30, 10, 2, 1400, 140, 10, 14, 1.8);
            ARWGearbox arwGearbox3 = new ARWGearbox(0.16, "ARW", 30, 15, 6, 1400, 94, 14, 14, 1.3);
            ARWGearbox arwGearbox4 = new ARWGearbox(0.18, "ARW", 40, 15, 2, 1400, 94, 15, 18, 2.9);
            ARWGearbox arwGearbox5 = new ARWGearbox(0.15, "ARW", 30, 20, 4, 1400, 70, 18, 14, 1);
            ARWGearbox arwGearbox6 = new ARWGearbox(0.16, "ARW", 40, 20, 6, 1400, 70, 19, 18, 2.1);
            ARWGearbox arwGearbox7 = new ARWGearbox(0.18, "ARW", 30, 25, 2, 1400, 56, 20, 14, 1);
            ARWGearbox arwGearbox8 = new ARWGearbox(0.15, "ARW", 40, 25, 4, 1400, 56, 23, 18, 1.7);
            ARWGearbox arwGearbox9 = new ARWGearbox(0.16, "ARW", 40, 30, 6, 1400, 47, 25, 18, 1.8);
            ARWGearbox arwGearbox10 = new ARWGearbox(0.18, "ARW", 40, 40, 2, 1400, 35, 32, 18, 1.3);
            ARWGearbox arwGearbox11 = new ARWGearbox(0.15, "ARW", 50, 40, 6, 1400, 35, 33, 25, 2.3);
            ARWGearbox arwGearbox12 = new ARWGearbox(0.16, "ARW", 40, 50, 6, 1400, 28, 37, 18, 1);
            ARWGearbox arwGearbox13 = new ARWGearbox(0.18, "ARW", 50, 50, 2, 1400, 28, 39, 25, 1.9);
            ARWGearbox arwGearbox14 = new ARWGearbox(0.15, "ARW", 50, 60, 4, 1400, 24, 43, 25, 1.6);
            ARWGearbox arwGearbox15 = new ARWGearbox(0.16, "TRC", 50, 80, 6, 1400, 18, 52, 25, 1.2);
            ARWGearbox arwGearbox16 = new ARWGearbox(0.18, "TRC", 40, 30, 2, 1400, 47, 25, 18, 1.8);
            ARWGearbox arwGearbox17 = new ARWGearbox(0.15, "TRC", 40, 40, 4, 1400, 35, 32, 18, 1.3);
            ARWGearbox arwGearbox18 = new ARWGearbox(0.16, "TRC", 50, 40, 6, 1400, 35, 33, 25, 2.3);
            ARWGearbox arwGearbox19 = new ARWGearbox(0.18, "TRC", 40, 50, 2, 1400, 28, 37, 18, 1);
            ARWGearbox arwGearbox20 = new ARWGearbox(0.15, "TRC", 50, 50, 4, 1400, 28, 39, 25, 1.9);
            ARWGearbox arwGearbox21 = new ARWGearbox(0.16, "TRC", 50, 60, 6, 1400, 24, 43, 25, 1.6);
            ARWGearbox arwGearbox22 = new ARWGearbox(0.18, "TRC", 50, 80, 2, 1400, 18, 52, 25, 1.2);

            arwGearboxes.Add(arwGearbox);
            arwGearboxes.Add(arwGearbox2);
            arwGearboxes.Add(arwGearbox3);
            arwGearboxes.Add(arwGearbox4);
            arwGearboxes.Add(arwGearbox5);
            arwGearboxes.Add(arwGearbox6);
            arwGearboxes.Add(arwGearbox7);
            arwGearboxes.Add(arwGearbox8);
            arwGearboxes.Add(arwGearbox9);
            arwGearboxes.Add(arwGearbox10);
            arwGearboxes.Add(arwGearbox11);
            arwGearboxes.Add(arwGearbox12);
            arwGearboxes.Add(arwGearbox13);
            arwGearboxes.Add(arwGearbox14);
            arwGearboxes.Add(arwGearbox15);
            arwGearboxes.Add(arwGearbox16);
            arwGearboxes.Add(arwGearbox17);
            arwGearboxes.Add(arwGearbox18);
            arwGearboxes.Add(arwGearbox19);
            arwGearboxes.Add(arwGearbox20);
            arwGearboxes.Add(arwGearbox21);
            arwGearboxes.Add(arwGearbox22);

            //Here we are trying to obtain a list of unique names from the list of the list of Gearboxes
            gearboxTypes = arwGearboxes.GroupBy(gearbox => gearbox.Type).Select(gearbox => gearbox.First().Type).ToList();
        }

        /// <summary>
        /// Returns a List of strings containing the names of all the available gearbox types
        /// </summary>
        /// <returns>List of strings</returns>
        public List<String> GetGearboxTypes()
        {

            return gearboxTypes;
        }

        /// <summary>
        /// Filters the List of all Gearboxes by the given type and returns only unique power ratings in ascending order
        /// </summary>
        /// <param name="type">string type</param>
        /// <returns>List of doubles</returns>
        public List<double> GetGearboxRatings(string type)
        {
            //Filter the list to get only the type required then get only unique power ratings from the filtered list.
            sameTypeGearboxes = arwGearboxes.Where(gearbox => gearbox.Type == type);
            List<double> gearboxRatings = sameTypeGearboxes.Select(gearbox => gearbox.Rating).Distinct().ToList();
            gearboxRatings.Sort();  //Sorting in ascending order.
            return gearboxRatings;
        }

        /// <summary>
        /// Filters the List of all gearboxes according to the given type and power ratings and returns a List of all the available poles
        /// for the given type and ratings
        /// </summary>
        /// <param name="type">string</param>
        /// <param name="rating">double</param>
        /// <returns>List of integers</returns>
        public List<int> GetPoles(double? rating)
        {
            //Filter the list to get on the required type and power rating required then get only unique poles from the filtered list
            sameRatingGearboxes = sameTypeGearboxes.Where(gearbox => gearbox.Rating == rating);
            List<int> poles = sameRatingGearboxes.Select(gearbox => gearbox.Poles).Distinct().ToList();
            return poles;
        }


        /// <summary>
        /// Filters the list of filtered gearboxes according to the given number of poles returns a list of distinct final rpms
        /// </summary>
        /// <param name="poles">int</param>
        /// <returns>List of doubles</returns>
        public List<double> GetFinalRpms(int? poles)
        {
            samePolesGearboxes = sameRatingGearboxes.Where(gearbox => gearbox.Poles == poles);
            List<double> finalRpms = samePolesGearboxes.Select(gearbox => gearbox.FinalRpm).Distinct().ToList();
            return finalRpms;
        }

        /// <summary>
        /// Filters the list of filtered gearboxes according to the given number of poles returns a list of distinct gear ratios
        /// </summary>
        /// <param name="poles">int</param>
        /// <returns>List of doubles</returns>
        public List<double> GetGearRatios(int? poles) 
        {
            sameFinalRpmGearboxes = samePolesGearboxes.Where(gearbox => gearbox.Poles == poles);
            List<double> finalRpms = sameFinalRpmGearboxes.Select(gearbox => gearbox.Ratio).Distinct().ToList();
            return finalRpms;
        }

        /// <summary>
        /// Gets the corresponding gear ratio given the number of poles and required final rpm
        /// </summary>
        /// <param name="finalRpm">double</param>
        /// <param name="poles">int</param>
        /// <returns>double</returns>
        public double GetGearRatio(double? finalRpm, int? poles) 
        {

            ARWGearbox gearbox = samePolesGearboxes.First(gearbox => (gearbox.Poles == poles && gearbox.FinalRpm == finalRpm));
            return gearbox.Ratio;
        }

        /// <summary>
        /// Gets the corresponding final rpm given the number of poles and the required gear ratio
        /// </summary>
        /// <param name="gearRatio">double</param>
        /// <param name="poles">int</param>
        /// <returns>double</returns>
        public double GetFinalRpm(double? gearRatio, int? poles) 
        {
            ARWGearbox gearbox = samePolesGearboxes.First(gearbox => (gearbox.Poles == poles && gearbox.Ratio == gearRatio));
            return gearbox.FinalRpm;
        }

        public IEnumerable<ARWGearbox> GetGearboxes(double? gearRatio) 
        {
            return samePolesGearboxes.Where(gearbox => gearbox.Ratio == gearRatio);
        }

        public ObservableCollection<ARWGearbox> GetGearboxes() 
        {
            return arwGearboxes;
        }
    }
}
