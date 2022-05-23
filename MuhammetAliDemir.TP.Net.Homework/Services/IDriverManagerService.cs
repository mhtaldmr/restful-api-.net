using MuhammetAliDemir.TP.Net.Homework.Entity;

namespace MuhammetAliDemir.TP.Net.Homework.Services
{
    public interface IDriverManagerService
    {
        void RaceEnteredUpdater(Driver driver);
        void PodiumNumberUpdater(Driver driver);
        void MakeNewContract();
        void CancelContract();

    }
}
