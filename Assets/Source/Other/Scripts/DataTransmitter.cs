using Nevalyashka.Brigade.Presenter;

namespace Nevalyashka.Brigade.Transmitter
{
    public static class DataTransmitter
    {
        public static PlayerModelPresenter[] PlayersModels { get; private set; }
        public static int CountPlayer => 2;

        public static void SetPlayersModels(PlayerModelPresenter[] playersModels)
        {
            PlayersModels = playersModels;
        }
    }
}
