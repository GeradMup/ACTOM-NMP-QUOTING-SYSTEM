using NMP_Quoting_System.Models;
using NMP_Quoting_System.ViewModels;
using PDF_GEN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

        public IEnumerable<Gearbox>? Gearboxes;
        public IEnumerable<Gearbox>? sameTypeGearboxes;
        public IEnumerable<Gearbox>? sameRatingGearboxes;
        public IEnumerable<Gearbox>? samePolesGearboxes;
        public IEnumerable<Gearbox>? sameFinalRpmGearboxes;
        public List<String>? gearboxTypes;

        private GearboxQuote gearboxQuote;

        public GearboxSelectionService()
        {
            gearboxQuote = new GearboxQuote();
            Gearboxes = new ObservableCollection<Gearbox>();

            TextFilesService textFilesService = new TextFilesService();
            Paths? paths = TextFilesService.GetProgramPaths();
            Gearboxes = new List<Gearbox>();

            if (paths == null)
            {
                //Here we need to report an error
            }
            else
            {
                string[] allFiles = Directory.GetFiles(paths.GearboxOptions, "*.csv");

                foreach (string file in allFiles) {
                    IEnumerable<Gearbox> gearboxes = File.ReadAllLines(file)
                                                        .Skip(1)
                                                        .Select(v => Gearbox.FromCSV(v))
                                                        .ToList();

                    Gearboxes = Gearboxes.Concat(gearboxes);
                }
            }

            if (Gearboxes != null) { 
                //Here we are trying to obtain a list of unique names from the list of the list of Gearboxes
                gearboxTypes = Gearboxes.GroupBy(gearbox => gearbox.Type).Select(gearbox => gearbox.First().Type).ToList();
            }
        }


        /// <summary>
        /// Returns a List of strings containing the names of all the available gearbox types
        /// </summary>
        /// <returns>List of strings</returns>
        public List<String>? GetGearboxTypes()
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
            sameTypeGearboxes = Gearboxes.Where(gearbox => gearbox.Type == type);
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

            Gearbox gearbox = samePolesGearboxes.First(gearbox => (gearbox.Poles == poles && gearbox.FinalRpm == finalRpm));
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
            Gearbox gearbox = samePolesGearboxes.First(gearbox => (gearbox.Poles == poles && gearbox.Ratio == gearRatio));
            return gearbox.FinalRpm;
        }


        /// <summary>
        /// Gets gear boxes that match the required ratio. 
        /// This function looks at the list that only has the same number of poles.
        /// </summary>
        /// <param name="gearRatio">double</param>
        /// <returns>IEnumerable<Gearbox></returns>
        public IEnumerable<Gearbox> GetGearboxes(double? gearRatio) 
        {
            return samePolesGearboxes.Where(gearbox => gearbox.Ratio == gearRatio);
        }

        public void SelectedGearBox(Gearbox selectedGearbox)  
        {
            Dimensions dimensions = new Dimensions(56, 100, 40, 11);
            Lubricant lubricant = new Lubricant("Shell", "Synthetic", "VG31", 0.05);
            User user = new User("Jane Goldwyer", "Central Sales Manager");
            gearboxQuote.generateQuote(selectedGearbox, dimensions, lubricant, user);
            //return Gearboxes;
        }

        public void Reset() 
        {
            sameTypeGearboxes = null;
            sameFinalRpmGearboxes = null;
            samePolesGearboxes = null;
            sameRatingGearboxes = null;
            if (Gearboxes != null)
            {
                //Here we are trying to obtain a list of unique names from the list of the list of Gearboxes
                gearboxTypes = Gearboxes.GroupBy(gearbox => gearbox.Type).Select(gearbox => gearbox.First().Type).ToList();
            }
        }
    }
}
