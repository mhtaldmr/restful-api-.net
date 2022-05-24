using MuhammetAliDemir.TP.Net.Homework.Entity;
using System.Collections.Generic;

namespace MuhammetAliDemir.TP.Net.Homework.Services
{
    public class EuropeRacePointManager : IPointSystemManagerService
    {
        private static readonly List<string> raceList = new() { "China", "Japan", "Singpour" };

        public void PointCalculator(Driver driver, Race race)
        {
            var location = race.Location;

            //If the race in Asia Ponint System is increasing by *2*
            if (raceList.Contains(location))
                driver.PointsAtThisYear += 2;
        }

        public void RaceEnteredUpdater(Driver driver)
        {
            driver.RaceEntered++;
        }

        public void PodiumNumberUpdater(Driver driver)
        {
            if (driver.PointsAtThisYear > 10)
                driver.Podiums++;
        }

    }
}