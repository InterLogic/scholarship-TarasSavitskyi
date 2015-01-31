using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Heroes.RPG.DAL;
using Heroes.RPG.BLL.Main;
using Heroes.RPG.BLL.Helpful;
using Heroes.RPG.BLL.ValueTypes;

namespace TestHeroesRPG.FakeDao
{
    public class FakeHeroDao : IHeroDao, IValueTypesDao
    {
        public Hero GetHero(string name)
        {
            Hero hero = null;
            List<int> takenCreature;
            HeroFaction heroFaction;
            HeroParametersPerLevel hppl;
            if (name == "Arthas")
            {
                takenCreature = new List<int> { 4, 2, 0, 0 };
                heroFaction = new HeroFaction(hero, GetFactionType("Knight"), takenCreature);
                hppl = new HeroParametersPerLevel(hero, 1, 0, 0, 0);
                hero = new Hero("name", 100, heroFaction, hppl);
            }
            else
            {
                takenCreature = new List<int> { 10, 10, 10, 0 };
                heroFaction = new HeroFaction(hero, GetFactionType("Elf"), takenCreature);
                hppl = new HeroParametersPerLevel(hero, 0, 1, 0, 0);
                hero = new Hero("name", 6100, heroFaction, hppl);
            }
            heroFaction.SetHeroOwner(hero);
            hppl.SetHeroOwner(hero);
            return hero;
        }

        public CreatureType GetCreatureType(string name)
        {
            throw new NotImplementedException();
        }

        public ArmyType GetArmyType(string name)
        {
            List<int> creatureWeights;
            List<int> limitationWeights;
            List<List<int>> limitationOnCreatureAmount;
            if (name == "Knight")
            {
                creatureWeights = new List<int> { 1, 4, 5, 9 };
                limitationWeights = new List<int> { 85, 94, 185, 199, 285 };
                limitationOnCreatureAmount = new List<List<int>>
                {new List<int>{27, 20, 0, 0},
                 new List<int>{35, 21, 0, 0},
                 new List<int>{40, 28, 20, 0},
                 new List<int>{44, 31, 23, 0},
                 new List<int>{52, 31, 23, 10}};
            }
            else
            {
                creatureWeights = new List<int> { 3, 4, 7, 11 };
                limitationWeights = new List<int> { 71, 92, 159, 168, 234 };
                limitationOnCreatureAmount = new List<List<int>>
                {new List<int>{11, 14, 0, 0},
                 new List<int>{16, 17, 0, 0},
                 new List<int>{20, 20, 10, 0},
                 new List<int>{20, 22, 11, 0},
                 new List<int>{23, 25, 12, 6}};
            }
            LimitSetArmy lsa = new LimitSetArmy(limitationWeights, limitationOnCreatureAmount, creatureWeights);
            return new ArmyType(lsa,null);
        }

        public FactionType GetFactionType(string name)
        {
            return new FactionType(name, GetArmyType(name));
        }

        public ArtefactType GetArtefactType(string name)
        {
            throw new NotImplementedException();
        }
    }
}
