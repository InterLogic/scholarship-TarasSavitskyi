using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.RPG.BLL.Helpful
{
    public class ParametersSet
    {
        readonly public int attack;
        readonly public int defense;
        readonly public int magicPower;
        readonly public int knowledge;
        readonly public int initiative;
        readonly public int luck;
        readonly public int morale;

        public ParametersSet()
        {
            attack = defense = 0;
            magicPower = knowledge = 0;
            initiative = 0;
            luck = 0;
            morale = 0;
        }

        public ParametersSet(int attack, int defense, int magicPower, int knowledge,
            int initiative, int luck, int morale)
        {
            this.attack = attack;
            this.defense = defense;
            this.magicPower = magicPower;
            this.knowledge = knowledge;
            this.initiative = initiative;
            this.luck = luck;
            this.morale = morale;
        }

        public static ParametersSet operator +(ParametersSet parameters1, ParametersSet parameters2)
        {
            return new ParametersSet(
                parameters1.attack + parameters2.attack,
                parameters1.defense + parameters2.defense,
                parameters1.magicPower + parameters2.magicPower,
                parameters1.knowledge + parameters2.knowledge,
                parameters1.initiative + parameters2.initiative,
                parameters1.luck + parameters2.luck,
                parameters1.morale + parameters2.morale);
        }
    }
}
