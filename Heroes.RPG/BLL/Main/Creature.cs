using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;
using Heroes.RPG.BLL.ValueTypes;

namespace Heroes.RPG.BLL.Main
{
    public class Creature
    {
        Hero heroOwner;
        CreatureType creatureType;

        public Creature()
        {
            creatureType = new CreatureType();
        }

        public Creature(Hero hero, CreatureType creatureType)
        {
            this.heroOwner = hero;
            this.creatureType = creatureType;
        }

        public CreatureParameters Parameters
        {
            get
            {
                CreatureParameters defaultParams = creatureType.Parameters;
                ParametersSet heroParams = heroOwner.Parameters;
                return new CreatureParameters(defaultParams.levelId, defaultParams.attack + heroParams.attack,
                    defaultParams.defense + heroParams.defense, defaultParams.damage, defaultParams.hp,
                    defaultParams.speed, defaultParams.initiative * (1.0 + heroParams.initiative / 100),
                    defaultParams.shoots, defaultParams.mp, defaultParams.luck + heroParams.luck,
                    defaultParams.morale + heroParams.morale);
            }
        }
    }
}
