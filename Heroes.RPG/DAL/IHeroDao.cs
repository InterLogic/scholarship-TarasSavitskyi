using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Main;

namespace Heroes.RPG.DAL
{
    public interface IHeroDao
    {
        Hero GetHero(string name);
    }
}
