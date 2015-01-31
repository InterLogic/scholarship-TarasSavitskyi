using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.RPG.BLL.Helpful
{
    public class CreatureParameters
    {
        readonly public int levelId;
        readonly public int attack;
        readonly public int defense;
        readonly public Tuple<int, int> damage;
        readonly public int hp;
        readonly public int speed;
        readonly public double initiative;
        readonly public int shoots;
        readonly public int mp;
        readonly public int luck;
        readonly public int morale;

        public CreatureParameters()
        {
            levelId = 1;
            attack = defense = 1;
            damage = new Tuple<int, int>(1, 1);
            hp = 4;
            mp = 0;
            speed = 4;
            initiative = 7;
            luck = 0;
            morale = 1;
        }

        public CreatureParameters(int levelId, int attack, int defense, Tuple<int, int> damage, int hp,
            int speed, double initiative, int shoots, int mp, int luck, int morale)
        {
            this.levelId = levelId;
            this.attack = attack;
            this.defense = defense;
            this.damage = damage;
            this.hp = hp;
            this.speed = speed;
            this.initiative = initiative;
            this.shoots = shoots;
            this.mp = mp;
            this.luck = luck;
            this.morale = morale;
        }
    }
}
