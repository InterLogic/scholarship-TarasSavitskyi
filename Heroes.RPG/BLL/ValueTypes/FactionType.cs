using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;

namespace Heroes.RPG.BLL.ValueTypes
{
    public class FactionType
    {
        string name;
        ArmyType armyType;
        //List<Ability> abilities;

        public FactionType()
        {
            name = "";
            armyType = new ArmyType();
        }

        public FactionType(string name,ArmyType armyType)
        {
            this.name = name;
            this.armyType = armyType;
        }

        public LimitSetArmy LimitOnArmy
        {
            get
            {
                return armyType.LimitOnArmy;
            }
        }

        public ArmyType GetArmyType
        {
            get
            {
                return armyType;
            }
        }
    }
}
