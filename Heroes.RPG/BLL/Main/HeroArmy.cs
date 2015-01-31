using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.BLL.Helpful;
using Heroes.RPG.BLL.ValueTypes;

namespace Heroes.RPG.BLL.Main
{
    public class HeroArmy
    {
        Hero heroOwner;
        List<Creature> creatures;
        LimitSetArmy limitSetArmy;
        List<int> numberOfTakenCreatures;

        public HeroArmy(Hero heroOwner, ArmyType armyType, List<int> numberOfTakenCreatures)
        {
            //if (heroOwner == null)
            //    throw new ArgumentNullException("heroOwner");
            this.heroOwner = heroOwner;
            this.limitSetArmy = armyType.LimitOnArmy;
            this.numberOfTakenCreatures = numberOfTakenCreatures;
            List<Creature> creatures = new List<Creature>();
            List<CreatureType> creaturesDefault = armyType.CreaturesBelongToArmy;
            if (creaturesDefault != null)
                for (int i = 0; i < creaturesDefault.Count; i++)
                    creatures.Add(new Creature(heroOwner, creaturesDefault[i]));
        }

        public void SetHeroOwner(Hero hero)
        {
            this.heroOwner = hero;
        }

        // TODO: re-factor to function
        private List<int> NumberOfFreeCreature()
        {
                List<int> numberOfFreeCeature = new List<int>();
                LimitSetArmy limitArmy = limitSetArmy;
                int freeWeight = limitArmy.limitationWeightOnLevel(heroOwner.Level-1);
                for (int i = 0; i < numberOfTakenCreatures.Count; i++)
                    freeWeight -= numberOfTakenCreatures[i] * limitArmy.creatureWeight(i);
                for (int i = 0; i < numberOfTakenCreatures.Count; i++)
                    numberOfFreeCeature.Add(
                        Math.Min(freeWeight / limitArmy.creatureWeight(i),
                                 limitArmy.limitationWeightOnCreaturesAmountOnLevel(heroOwner.Level-1, i) - numberOfTakenCreatures[i])
                    );
                return numberOfFreeCeature;
        }

        public bool IncreaseCreatureAmmount(int levelCreature, int amount)
        {
            if (NumberOfFreeCreature()[levelCreature] >= amount)
                numberOfTakenCreatures[levelCreature] += amount;
            else return false;
            return true;
        }

        public bool DecreaseCreatureAmmount(int levelCreature, int amount)
        {
            if (numberOfTakenCreatures[levelCreature] >= amount)
                numberOfTakenCreatures[levelCreature] -= amount;
            else return false;
            return true;
        }

        public string ToString()
        {
            string info = "";
            for (int i = 0; i < numberOfTakenCreatures.Count; i++)
            {
                info += numberOfTakenCreatures[i] + " ";
            }
            return info;
        }
    }
}
