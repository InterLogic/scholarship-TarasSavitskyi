using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.RPG.BLL.Helpful
{
    public class LimitSetArmy
    {
        List<int> limitationWeights;
        List<List<int>> limitationOnCreaturesAmount;
        List<int> creaturesWeights;

        public LimitSetArmy()
        {
            limitationWeights = new List<int>();
            limitationOnCreaturesAmount = new List<List<int>>();
            creaturesWeights = new List<int>();
        }

        public LimitSetArmy(List<int> limitationWeights,
                List<List<int>> limitationOnCreaturesAmount, List<int> creaturesWeights)
        {
            this.limitationWeights = limitationWeights;
            this.limitationOnCreaturesAmount = limitationOnCreaturesAmount;
            this.creaturesWeights = creaturesWeights;
        }

        public int limitationWeightOnLevel(int level)
        {
            return limitationWeights[level];
        }

        public int limitationWeightOnCreaturesAmountOnLevel(int level, int creaturelevel)
        {
            return limitationOnCreaturesAmount[level][creaturelevel];
        }

        public int creatureWeight(int creaturelevel)
        {
            return creaturesWeights[creaturelevel];
        }
    }
}
