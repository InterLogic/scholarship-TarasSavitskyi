using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Heroes.RPG.BLL.ValueTypes;
using Heroes.RPG.BLL.Helpful;

namespace Heroes.RPG.DAL.Text
{
    class TextValueTypeDao
    {
        public CreatureType GetCreatureType(string name)
        {
            StreamReader sr = new StreamReader("F:\\Documents and Settings\\Taras\\Мои документы\\Visual Studio 2010\\Projects\\Heroes.RPG\\Heroes.RPG\\DAL\\Text\\InfoAboutCreature.txt");
            while (!sr.EndOfStream)
                if (sr.ReadLine() == name)
                {
                    string[] stringParameters = sr.ReadLine().Split(' ');
                    sr.Close();
                    List<int> pars = new List<int>();
                    for (int i = 0; i < stringParameters.Length; i++)
                        pars.Add(Convert.ToInt32(stringParameters[i]));
                    CreatureParameters creatureParameters = new CreatureParameters(pars[0], pars[1], pars[2], new Tuple<int, int>(pars[3], pars[4]),
                        pars[5], pars[6], pars[7], pars[8], pars[9], pars[10], pars[11]);
                    return new CreatureType(name, creatureParameters);
                }
                else sr.ReadLine();
            sr.Close();
            throw new ArgumentNullException("there isn't creature with name ", name);
        }

        public LimitSetArmy LimitSetArmyForFraction(string name)
        {
            List<int> limitationWeights = new List<int>();
            List<int> creaturesWeights = new List<int>();
            List<List<int>> limitationOnCreaturesCount = new List<List<int>>();
            StreamReader sr = new StreamReader("F:\\Documents and Settings\\Taras\\Мои документы\\Visual Studio 2010\\Projects\\Heroes.RPG\\Heroes.RPG\\DAL\\Text\\LimitSetArmy.txt");
            string info = sr.ReadLine();
            int maxLevel = Convert.ToInt32(info.Split(' ')[0]);
            int maxCreatureLevel = Convert.ToInt32(info.Split(' ')[1]);
            while (!sr.EndOfStream)
                if (sr.ReadLine() == name)
                {
                    string[] limitationWeightsString = sr.ReadLine().Split(' ');
                    for (int i = 1; i <= maxLevel; i++)
                        limitationWeights.Add(Convert.ToInt32(limitationWeightsString[i - 1]));
                    string[] creaturesWeightsString = sr.ReadLine().Split(' ');
                    for (int i = 1; i <= maxCreatureLevel; i++)
                        creaturesWeights.Add(Convert.ToInt32(creaturesWeightsString[i - 1]));

                    for (int i = 1; i <= maxLevel; i++)
                    {
                        limitationOnCreaturesCount.Add(new List<int>());
                        string[] limitOnCreature = sr.ReadLine().Split(' ');
                        for (int j = 1; j <= maxCreatureLevel; j++)
                            limitationOnCreaturesCount[i - 1].Add(Convert.ToInt32(limitOnCreature[j - 1]));
                    }
                    return new LimitSetArmy(limitationWeights, limitationOnCreaturesCount, creaturesWeights);
                }
                else
                {
                    sr.ReadLine();
                    sr.ReadLine();
                    for (int i = 0; i < maxLevel; i++)
                        sr.ReadLine();
                }
            sr.Close();
            throw new ArgumentNullException("there isn't limitset for fraction with name ", name);
        }

        public List<CreatureType> CreatureTypeForFraction(string name)
        {
            List<CreatureType> armyType = new List<CreatureType>();
            StreamReader sr = new StreamReader("F:\\Documents and Settings\\Taras\\Мои документы\\Visual Studio 2010\\Projects\\Heroes.RPG\\Heroes.RPG\\DAL\\Text\\CreatureTypeForFraction.txt");
            while (!sr.EndOfStream)
                if (sr.ReadLine() == name)
                {
                    string[] stringParameters = sr.ReadLine().Split(' ');
                    sr.Close();
                    for (int i = 0; i < stringParameters.Length; i++)
                        armyType.Add(GetCreatureType(stringParameters[i]));
                    return armyType;
                }
                else sr.ReadLine();
            sr.Close();
            throw new ArgumentNullException("there isn't creature types for fraction with name ", name);
        }

        public ArmyType GetArmyType(string name)
        {
            return new ArmyType(LimitSetArmyForFraction(name), CreatureTypeForFraction(name));
        }

        public FactionType GetFactionType(string name)
        {
            return new FactionType(name, GetArmyType(name));
        }

        public ArtefactType GetArtefactType(string name)
        {
            return new ArtefactType();
        }
    }
}
