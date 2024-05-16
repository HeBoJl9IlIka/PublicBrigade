using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    public class PlayerRoot : Root
    {
        [SerializeField] private Config.PlayerNumber _playerNumber;

        private LevelRoot _levelRoot;
        private PlayerRouter _playerRouter;
        private Movement _movement;
        private AnimatorModel _animatorModel;
        private Dragger _dragger;
        private Taker _taker;
        private Giver _giver;
        private Sprinkler _sprinkler;
        private Doer _doer;
        private WaterFiller _waterFiller;
        private Waterer _waterer;
        private HammerUser _hammerUser;
        private RepairDrawingUser _repairDrawingUser;
        private CameraRotator _cameraRotator;
        private Inventory _inventory;
        private JoystickModel _joystickModel;
        private MovementPresenter _movementPresenter;
        private JoystickPresenter _joystickPresenter;
        private MobileControl _mobileControl;
        private TaskGoalIndicator _taskGoalIndicator;
        private AnimatorPresenter _animatorPresenter;
        private LiftableInspectorPresenter _draggerInspectorPresenter;
        private PointForObjectPresenter _pointForObject;
        private DraggerPresenter _draggerPresenter;
        private RotationPresenter _rotationPresenter;
        private TakerInspectorPresenter _takerInspectorPresenter;
        private PlayerMaterialBarFactory _materialBarFactory;
        private PlayerMaterialBarPresenter _materialBarPresenter;
        private GiverInspectorPresenter _giverInspectorPresenter;
        private SprinklerInspectorPresenter _sprinklerInspectorPresenter;
        private DoerInspectorPresenter _doerInspectorPresenter;
        private WaterFillerInspectorPresenter _waterFillerInspectorPresenter;
        private WatererInspectorPresenter _watererInspectorPresenter;
        private HammerTaskInspectorPresenter _hammerTaskInspectorPresenter;
        private CameraRotatorPreseneter _cameraRotatorPreseneter;

        public Config.PlayerNumber PlayerNumber => _playerNumber;

        public void Init(LevelRoot levelRoot, Transform spawnPoint, TaskGoalIndicator taskGoalIndicator)
        {
            _levelRoot = levelRoot;
            _taskGoalIndicator = taskGoalIndicator;

            _movementPresenter = GetComponentInChildren<MovementPresenter>(true);
            _joystickPresenter = GetComponentInChildren<JoystickPresenter>(true);
            _mobileControl = GetComponentInChildren<MobileControl>(true);
            _animatorPresenter = GetComponentInChildren<AnimatorPresenter>(true);
            _draggerInspectorPresenter = GetComponentInChildren<LiftableInspectorPresenter>(true);
            _pointForObject = GetComponentInChildren<PointForObjectPresenter>(true);
            _draggerPresenter = GetComponentInChildren<DraggerPresenter>(true);
            _rotationPresenter = GetComponentInChildren<RotationPresenter>(true);
            _takerInspectorPresenter = GetComponentInChildren<TakerInspectorPresenter>(true);
            _materialBarFactory = GetComponent<PlayerMaterialBarFactory>();
            _giverInspectorPresenter = GetComponentInChildren<GiverInspectorPresenter>(true);
            _sprinklerInspectorPresenter = GetComponentInChildren<SprinklerInspectorPresenter>(true);
            _doerInspectorPresenter = GetComponentInChildren<DoerInspectorPresenter>(true);
            _waterFillerInspectorPresenter = GetComponentInChildren<WaterFillerInspectorPresenter>(true);
            _watererInspectorPresenter = GetComponentInChildren<WatererInspectorPresenter>(true);
            _hammerTaskInspectorPresenter = GetComponentInChildren<HammerTaskInspectorPresenter>(true);
            _cameraRotatorPreseneter = GetComponentInChildren<CameraRotatorPreseneter>(true);

            _joystickModel = new JoystickModel();
            _playerRouter = new PlayerRouter(_levelRoot.GetActionMap(), _joystickModel);
            _cameraRotator = new CameraRotator();
            _movement = new Movement(_playerRouter, Config.CharacterMoveSpeed, Config.CharacterSpeedChangeRate, _cameraRotator);
            _dragger = new Dragger(_playerRouter, _pointForObject.transform);
            _inventory = new Inventory();
            _taker = new Taker(_playerRouter, _inventory);
            _giver = new Giver(_playerRouter, _inventory);
            _sprinkler = new Sprinkler(_playerRouter, _dragger);
            _doer = new Doer(_playerRouter, _inventory);
            _waterFiller = new WaterFiller(_playerRouter, _dragger);
            _waterer = new Waterer(_playerRouter, _dragger);
            _hammerUser = new HammerUser(_playerRouter, _dragger);
            _repairDrawingUser = new RepairDrawingUser(_playerRouter, _dragger, _cameraRotator, _taskGoalIndicator);
            _animatorModel = new AnimatorModel(_movement, _dragger);

            _materialBarPresenter = _materialBarFactory.Create(_movementPresenter.transform);

            _movementPresenter.Init(_movement);
            _joystickPresenter.Init(_joystickModel);
            _animatorPresenter.Init(_animatorModel);
            _draggerInspectorPresenter.Init(_dragger);
            _draggerPresenter.Init(_dragger);
            _rotationPresenter.Init(_movement);
            _takerInspectorPresenter.Init(_taker);
            _materialBarPresenter.Init(_inventory);
            _giverInspectorPresenter.Init(_giver);
            _sprinklerInspectorPresenter.Init(_sprinkler);
            _doerInspectorPresenter.Init(_doer);
            _waterFillerInspectorPresenter.Init(_waterFiller);
            _watererInspectorPresenter.Init(_waterer);
            _hammerTaskInspectorPresenter.Init(_hammerUser);
            _cameraRotatorPreseneter.Init(_cameraRotator);

            enabled = true;

            _mobileControl.gameObject.SetActive(_levelRoot.IsMobile);
            _movementPresenter.transform.position = spawnPoint.position;
        }

        private void OnEnable()
        {
            _playerRouter.Enable();
            _movement.Enable();
            _animatorModel.Enable();
            _dragger.Enable();
            _taker.Enable();
            _giver.Enable();
            _sprinkler.Enable();
            _doer.Enable();
            _waterFiller.Enable();
            _waterer.Enable();
            _hammerUser.Enable();
            _repairDrawingUser.Enable();

            _dragger.Dragging += OnDragging;
            _dragger.Dropping += OnDropping;
        }

        private void OnDisable()
        {
            _playerRouter.Disable();
            _movement.Disable();
            _animatorModel.Disable();
            _dragger.Disable();
            _taker.Disable();
            _giver.Disable();
            _sprinkler.Disable();
            _doer.Disable();
            _waterFiller.Disable();
            _waterer.Disable();
            _hammerUser.Disable();
            _repairDrawingUser.Disable();

            _dragger.Dragging -= OnDragging;
            _dragger.Dropping -= OnDropping;
        }

        private void Update()
        {
            _movement.Update(Time.deltaTime);
            _animatorModel.Update(Time.deltaTime);
        }

        private void OnDragging(bool obj)
        {
            _taker.Disable();
            _giver.Disable();
        }

        private void OnDropping(bool obj)
        {
            _taker.Enable();
            _giver.Enable();
        }
    }
}
