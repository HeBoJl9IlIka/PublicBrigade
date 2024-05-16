using Nevalyashka.Brigade.Presenter;
using System.Linq;
using Unity.VisualScripting;

namespace Nevalyashka.Brigade.Factory
{
    public class WateringCanAmountBarFactory : PresenterFactory<WateringCanAmountBarPresenter, Null, Null, Null>
    {
        public override WateringCanAmountBarPresenter GetTemplate(Null obj = null, Null obj1 = null, Null obj2 = null)
        {
            return Templates.FirstOrDefault(presenter => presenter != null);
        }
    }
}
