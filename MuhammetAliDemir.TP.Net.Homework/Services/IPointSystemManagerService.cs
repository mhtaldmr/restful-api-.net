using MuhammetAliDemir.TP.Net.Homework.Entity;

namespace MuhammetAliDemir.TP.Net.Homework.Services
{
    public interface IPointSystemManagerService
    {
        void RaceEnteredUpdater(Driver driver);
        void PodiumNumberUpdater(Driver driver);
        void PointCalculator(Driver driver, Race race);

    }
}
