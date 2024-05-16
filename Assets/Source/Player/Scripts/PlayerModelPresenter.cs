using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class PlayerModelPresenter : MonoBehaviour
    {
        [SerializeField] private Config.TypePlayerModel _type;

        public Config.TypePlayerModel Type => _type;
    }
}
