using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Root;
using System.Linq;
using Unity.VisualScripting;

namespace Nevalyashka.Brigade.Factory
{
    public class PlayerRootFactory : PresenterFactory<PlayerRoot, Config.PlayerNumber, Null, Null>
    {
        public override PlayerRoot GetTemplate(Config.PlayerNumber number, Null obj1, Null obj2 = null)
        {
            return Templates.FirstOrDefault(root => root.PlayerNumber == number);
        }
    }
}
