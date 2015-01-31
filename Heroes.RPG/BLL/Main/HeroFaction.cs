using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;
using Heroes.RPG.BLL.ValueTypes;

namespace Heroes.RPG.BLL.Main
{
    public class HeroFaction
    {
        Hero heroOwner;
        FactionType fractionType;
        HeroArmy heroArmy;

        public HeroFaction(Hero heroOwner, FactionType fractionType, List<int> numberOfTakenCreatures)
        {
            this.heroOwner = heroOwner;
            this.fractionType = fractionType;
            this.heroArmy = new HeroArmy(heroOwner, fractionType.GetArmyType, numberOfTakenCreatures);
        }

        public void SetHeroOwner(Hero hero)
        {
            this.heroOwner=hero;
            this.heroArmy.SetHeroOwner(hero);
        }

        public HeroArmy ArmyHero
        {
            get
            {
                return heroArmy;
            }
        }
    }
}
