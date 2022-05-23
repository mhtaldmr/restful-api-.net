using MuhammetAliDemir.TP.Net.Homework.Entity;

namespace MuhammetAliDemir.TP.Net.Homework.Services
{
    public class DriverManagerService : IDriverManagerService
    {
        public void RaceEnteredUpdater(Driver driver)
        {
            driver.RaceEntered++;
        }

        public void PodiumNumberUpdater(Driver driver)
        {
            driver.Podiums++;
        }

        public void MakeNewContract()
        {
            throw new System.NotImplementedException();
        }
        public void CancelContract()
        {
            throw new System.NotImplementedException();
        }

    }
}