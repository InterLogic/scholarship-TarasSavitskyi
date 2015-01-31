using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;

namespace Heroes.RPG.BLL.ValueTypes
{
    public class CreatureType
    {
        string name;
        CreatureParameters defaultParameters;
        //List<CreatureAbility> creatureAbilities;

        public CreatureType()
        {
            name = "";
            defaultParameters = new CreatureParameters();
        }

        public CreatureType(string name, CreatureParameters defaultParameters)
        {
            this.name = name;
            this.defaultParameters = defaultParameters;
        }

        public CreatureParameters Parameters
        {
            get
            {
                return defaultParameters;
            }
        }
    }
}
