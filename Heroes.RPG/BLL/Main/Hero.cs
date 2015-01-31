using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;
using Heroes.RPG.BLL.ValueTypes;

namespace Heroes.RPG.BLL.Main
{
    public class Hero
    {
        string name;
        long experience;

        public int Level
        {
            get
            {
                int lvl = 1;
                long ex = experience / 1500;
                while (ex != 0)
                {
                    ex /= 4;
                    lvl++;
                }
                return lvl;
            }
        }

        HeroParametersPerLevel parametersPerLevel;
        HeroFaction heroFaction;
        Inventory inventory;

        public ParametersSet Parameters
        {
            get
            {
                return parametersPerLevel.Parameters + inventory.Parameters;
            }
        }

        public HeroFaction FactionHero
        {
            get
            {
                return heroFaction;
            }
        }

        public Hero(string name, long experience, HeroFaction heroFaction, HeroParametersPerLevel parametersPerLevel)
        {
            this.name = name;
            this.experience = experience;
            this.heroFaction = heroFaction;
            this.parametersPerLevel = parametersPerLevel;
        }
    }
}
