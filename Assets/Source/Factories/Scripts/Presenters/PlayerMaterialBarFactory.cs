using Nevalyashka.Brigade.Presenter;
using System.Linq;
using Unity.VisualScripting;

namespace Nevalyashka.Brigade.Factory
{
    public class PlayerMaterialBarFactory : PresenterFactory<PlayerMaterialBarPresenter, Null, Null, Null>
    {
        public override PlayerMaterialBarPresenter GetTemplate(Null obj = null, Null obj1 = null, Null obj2 = null)
        {
            return Templates.FirstOrDefault(presenter => presenter != null);
        }
    }
}
