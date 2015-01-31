using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Heroes.RPG.BLL.Main;
using Heroes.RPG.BLL.Helpful;
using Heroes.RPG.BLL.ValueTypes;

namespace Heroes.RPG.DAL.Text
{
    public class TextHeroDao : IHeroDao
    {
        public Hero GetHero(string name)
        {
            Hero hero = null;
            StreamReader sr = new StreamReader("F:\\Documents and Settings\\Taras\\Мои документы\\Visual Studio 2010\\Projects\\Heroes.RPG\\Heroes.RPG\\DAL\\Text\\HeroInfo.txt");
            while (!sr.EndOfStream)
                if (sr.ReadLine() == name)
                {
                    string exp = sr.ReadLine();
                    int experience = Convert.ToInt32(exp);

                    string faction = sr.ReadLine();
                    FactionType factionType = new FactionType(faction, (new TextValueTypeDao()).GetArmyType(faction));

                    string[] amountArmy = sr.ReadLine().Split(' ');
                    List<int> amountHeroArmy = new List<int>();
                    for (int i = 0; i < amountArmy.Count(); i++)
                        amountHeroArmy.Add(Convert.ToInt32(amountArmy[i]));

                    string[] heroParametersStr = sr.ReadLine().Split(' ');
                    List<int> heroParameters = new List<int>();
                    for (int i = 0; i < heroParametersStr.Count(); i++)
                        heroParameters.Add(Convert.ToInt32(heroParametersStr[i]));

                    HeroFaction heroFaction = new HeroFaction(hero, factionType, amountHeroArmy);
                    HeroParametersPerLevel heroParametersPerLevel = new HeroParametersPerLevel(hero, heroParameters[0],
                        heroParameters[1], heroParameters[2], heroParameters[3]);
                    sr.Close();
                    hero = new Hero(name, experience, heroFaction, heroParametersPerLevel);
                    return hero;
                }
                else
                {
                    sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                }

            throw new ArgumentNullException("no hero with name "+name);
        }
    }
}
