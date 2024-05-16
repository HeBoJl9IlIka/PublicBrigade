using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using System.Linq;
using Unity.VisualScripting;

namespace Nevalyashka.Brigade.Factory
{
    public class PlayerModelFactory : PresenterFactory<PlayerModelPresenter, Config.TypePlayerModel, Null, Null>
    {
        public override PlayerModelPresenter GetTemplate(Config.TypePlayerModel type, Null obj1, Null obj2 = null)
        {
            return Templates.FirstOrDefault(presenter => presenter.Type == type);
        }
    }
}
