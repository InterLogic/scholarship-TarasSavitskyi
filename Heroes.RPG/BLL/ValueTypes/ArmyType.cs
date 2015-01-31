using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;

namespace Heroes.RPG.BLL.ValueTypes
{
    public class ArmyType
    {
        List<CreatureType> creatures;
        LimitSetArmy limitSetArmy;

        public ArmyType()
        {
            limitSetArmy = new LimitSetArmy();
            creatures = new List<CreatureType>();
        }

        public ArmyType(LimitSetArmy limitSetArmy, List<CreatureType> creatures)
        {
            this.limitSetArmy = limitSetArmy;
            this.creatures = creatures;
        }

        public LimitSetArmy LimitOnArmy
        {
            get
            {
                return limitSetArmy;
            }
        }

        public List<CreatureType> CreaturesBelongToArmy
        {
            get
            {
                return creatures;
            }
        }
    }
}
