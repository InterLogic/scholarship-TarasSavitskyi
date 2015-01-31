using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Main;

namespace Heroes.RPG.BLL.Helpful
{
    public class HeroParametersPerLevel
    {
        Hero heroOwner;
        ParametersSet parametersSet;

        public HeroParametersPerLevel(Hero hero, int attack, int defense, int magicPower, int knowledge)
        {
            this.heroOwner = hero;
            parametersSet = new ParametersSet(attack, defense, magicPower, knowledge, 0, 0, 0);
        }

        public void SetHeroOwner(Hero hero)
        {
            this.heroOwner = hero;
        }

        public ParametersSet Parameters
        {
            get
            {
                return parametersSet;
            }
        }

        public int FreeParameters()
        {
            return heroOwner.Level - parametersSet.attack - parametersSet.defense
                - parametersSet.knowledge - parametersSet.magicPower;
        }

        public bool AddAttack()
        {
            if (FreeParameters()<=0) return false;
            parametersSet = parametersSet + new ParametersSet(1, 0, 0, 0, 0, 0, 0);
            return true;
        }

        public bool AddDefense()
        {
            if (FreeParameters() <= 0) return false;
            parametersSet = parametersSet + new ParametersSet(0, 1, 0, 0, 0, 0, 0);
            return true;
        }

        public bool AddMagicPower()
        {
            if (FreeParameters() <= 0) return false;
            parametersSet = parametersSet + new ParametersSet(0, 0, 1, 0, 0, 0, 0);
            return true;
        }

        public bool AddKnowledge()
        {
            if (FreeParameters() <= 0) return false;
            parametersSet = parametersSet + new ParametersSet(0, 0, 0, 1, 0, 0, 0);
            return true;
        }

        public void ResetParameters()
        {
            parametersSet = new ParametersSet(0, 0, 0, 0, 0, 0, 0);
        }
    }
}
