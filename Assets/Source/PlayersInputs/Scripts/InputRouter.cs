using UnityEngine.InputSystem;

namespace Nevalyashka.Brigade.Model
{
    public class InputRouter : ISwitchable
    {
        private PlayersInputs _playersInputs;
        private PlayersInputs.Player1Actions _player1Actions;
        private PlayersInputs.Player2Actions _player2Actions;
        private PlayersInputs.Player3Actions _player3Actions;
        private PlayersInputs.Player4Actions _player4Actions;
        private int _count;

        public bool IsEnabled { get; private set; }

        public InputRouter()
        {
            _playersInputs = new PlayersInputs();

            _player1Actions = _playersInputs.Player1;
            _player2Actions = _playersInputs.Player2;
            _player3Actions = _playersInputs.Player3;
            _player4Actions = _playersInputs.Player4;
        }

        public void Enable()
        {
            IsEnabled = true;
            _playersInputs.Enable();
        }

        public void Disable()
        {
            IsEnabled = false;
            _playersInputs.Disable();
        }

        public InputActionMap GetActionMap()
        {
            InputActionMap inputActionMap;

            switch (_count)
            {
                case 0:
                    inputActionMap = _player1Actions;
                    break;
                case 1:
                    inputActionMap = _player2Actions;
                    break;
                case 2:
                    inputActionMap = _player3Actions;
                    break;
                case 3:
                    inputActionMap = _player4Actions;
                    break;
                default:
                    inputActionMap = null;
                    break;
            }

            ++_count;
            return inputActionMap;
        }
    }
}
