using MuhammetAliDemir.TP.Net.Homework.Entity;
using System.Collections.Generic;

namespace MuhammetAliDemir.TP.Net.Homework.Services
{
    public class AsiaRacePointManager : IPointSystemManagerService
    {
        private static readonly List<string> _raceList = new() { "Italy", "Spain", "France", "Belgium", "Nederlands", "Monaco" };
      
        public void PointCalculator(Driver driver, Race race)
        {
            var location = race.Location;

            //If the race in Europe Ponint System is increasing by *5*
            if (_raceList.Contains(location))
                driver.PointsAtThisYear += 5;
        }

        public void RaceEnteredUpdater(Driver driver)
        {
            driver.RaceEntered++;
        }

        public void PodiumNumberUpdater(Driver driver)
        {
            if(driver.PointsAtThisYear > 15)
                driver.Podiums++;
        }

    }
}
