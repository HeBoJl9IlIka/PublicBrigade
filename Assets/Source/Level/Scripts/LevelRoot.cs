using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using Nevalyashka.Brigade.Transmitter;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Nevalyashka.Brigade.Root
{
    public class LevelRoot : Root
    {
        [SerializeField] private PlayerModelPresenter[] _playersModels;



        [SerializeField] private PlayersContainer _playersContainer;
        
        private PlayerSpawnPoint[] _spawnPoints;
        private PlayerRoot[] _playersRoots;
        private InputRouter _inputRouter;
        private PlayerRootFactory _playerRootFactory;
        private PlayerModelFactory _playerModelFactory;
        private TasksCounterRoot _tasksCounterRoot;
        private TaskGoalIndicatorRoot _taskGoalIndicatorRoot;

        public bool IsMobile => true;
        private int CountPlayer => DataTransmitter.CountPlayer;
        
        public override void Compose()
        {
            DataTransmitter.SetPlayersModels(_playersModels);


            _spawnPoints = _playersContainer.GetComponentsInChildren<PlayerSpawnPoint>(true);
            _playerRootFactory = GetComponent<PlayerRootFactory>();
            _playerModelFactory = GetComponent<PlayerModelFactory>();
            _tasksCounterRoot = GetComponentInChildren<TasksCounterRoot>(true);
            _taskGoalIndicatorRoot = GetComponentInChildren<TaskGoalIndicatorRoot>(true);

            _tasksCounterRoot.Init();
            _taskGoalIndicatorRoot.Init();

            _inputRouter = new InputRouter();
            _playersRoots = new PlayerRoot[CountPlayer];
            CreatePlayers();

            for (int i = 0; i < _playersRoots.Length; i++)
                _playersRoots[i].Init(this, _spawnPoints[i].transform, _taskGoalIndicatorRoot.Model);
        }

        private void OnEnable()
        {
            _inputRouter.Enable();
        }

        private void OnDisable()
        {
            _inputRouter.Disable();
        }

        public InputActionMap GetActionMap() => _inputRouter.GetActionMap();

        private void CreatePlayers()
        {
            if (_spawnPoints.Length < CountPlayer)
                throw new ArgumentOutOfRangeException(nameof(CountPlayer));

            PlayerRoot playerRoot;

            for (int i = 0; i < CountPlayer; i++)
            {
                playerRoot = _playerRootFactory.Create(_playersContainer.transform, (Config.PlayerNumber)i);
                Config.TypePlayerModel model = DataTransmitter.PlayersModels[i].Type;
                _playerModelFactory.Create(playerRoot.transform, model);
                _playersRoots[i] = playerRoot;
            }
        }
    }
}
