using Nevalyashka.Brigade.Presenter;
using System.Linq;
using Unity.VisualScripting;

namespace Nevalyashka.Brigade.Factory
{
    public class TasksCounterBarFactory : PresenterFactory<TasksCounterBarPresenter, Null, Null, Null>
    {
        public override TasksCounterBarPresenter GetTemplate(Null obj = null, Null obj1 = null, Null obj2 = null)
        {
            return Templates.FirstOrDefault(presenter => presenter != null);
        }
    }
}
