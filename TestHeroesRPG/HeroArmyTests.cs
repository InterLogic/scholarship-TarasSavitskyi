using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using Heroes.RPG.DAL;
using Heroes.RPG.BLL.Main;
using TestHeroesRPG.FakeDao;

namespace TestHeroesRPG
{
    /// <summary>
    ///Это класс теста для HeroArmyTest, в котором должны
    ///находиться все модульные тесты HeroArmyTest
    ///</summary>
    [TestClass()]
    public class HeroArmyTests
    {
        private IHeroDao heroDao; 

        [TestInitialize]
        public void Init()
        {
            heroDao = new FakeHeroDao();
        }

        [TestMethod]
        public void DecreaseCreatureAmountTest1_1()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Arthas"); //Hero lvl 1; Army: 4 2 0 0

            // WHEN
            bool actual = hero.FactionHero.ArmyHero.DecreaseCreatureAmmount(0, 4);

            // SHOULD
            Assert.AreEqual(true, actual);
            //Army: 0 2 0 0
        }

        [TestMethod]
        public void DecreaseCreatureAmountTest1_2()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Arthas"); //Hero lvl 1; Army: 4 2 0 0

            // WHEN
            bool actual = hero.FactionHero.ArmyHero.DecreaseCreatureAmmount(0, 5);

            // SHOULD
            Assert.AreEqual(false, actual);
            //Army: -1 2 0 0
        }

        [TestMethod]
        public void IncreaseCreatureAmountTest1_1()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Arthas"); //Hero lvl 1; Army: 4 2 0 0

            // WHEN
            bool actual = hero.FactionHero.ArmyHero.IncreaseCreatureAmmount(1, 18);

            // SHOULD
            Assert.AreEqual(true, actual);
            //Army: 4 20 0 0
        }

        [TestMethod]
        public void IncreaseCreatureAmountTest1_2()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Arthas"); //Hero lvl 1; Army: 4 2 0 0

            // WHEN
            bool actual = hero.FactionHero.ArmyHero.IncreaseCreatureAmmount(1, 19);

            // SHOULD
            Assert.AreEqual(false, actual);
            //Army: 4 21 0 0
        }

        [TestMethod]
        public void IncreaseCreatureAmountTest1_3()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Arthas"); //Hero lvl 1; Army: 4 2 0 0

            // WHEN
            bool actual = hero.FactionHero.ArmyHero.IncreaseCreatureAmmount(2, 1);

            // SHOULD
            Assert.AreEqual(false, actual);
            //Army: 4 2 1 0
        }

        [TestMethod]
        public void DecreaseCreatureAmountTest2_1()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Elven"); //Hero lvl 3; Army: 10 10 10 0

            // WHEN
            bool actual = hero.FactionHero.ArmyHero.DecreaseCreatureAmmount(2, 0);

            // SHOULD
            Assert.AreEqual(true, actual);
            //Army: 10 10 10 0
        }

        [TestMethod]
        public void DecreaseCreatureAmountTest2_2()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Elven"); //Hero lvl 3; Army: 10 10 10 0

            // WHEN
            bool actual1 = hero.FactionHero.ArmyHero.DecreaseCreatureAmmount(2, 11);
            bool actual2 = hero.FactionHero.ArmyHero.DecreaseCreatureAmmount(2, 6);

            // SHOULD
            Assert.AreEqual(false, actual1);
            Assert.AreEqual(true, actual2);
            //Army: 10 4 0 0
        }

        [TestMethod]
        public void IncreaseCreatureAmountTest2_1()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Elven"); //Hero lvl 3; Army: 10 10 10 0

            // WHEN
            bool actual = hero.FactionHero.ArmyHero.IncreaseCreatureAmmount(2, 1);

            // SHOULD
            Assert.AreEqual(false, actual);
            //Army: 10 10 11 0
        }

        [TestMethod]
        public void IncreaseCreatureAmountTest2_2()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Elven"); //Hero lvl 3; Army: 10 10 10 0

            // WHEN
            bool actual = hero.FactionHero.ArmyHero.IncreaseCreatureAmmount(0, 1);

            // SHOULD
            Assert.AreEqual(true, actual);
            //Army: 16 10 10 0
        }

        [TestMethod]
        public void IncreaseCreatureAmountTest2_3()
        {
            // GIVEN
            Hero hero = heroDao.GetHero("Elven"); //Hero lvl 3; Army: 10 10 10 0

            // WHEN
            bool actual = hero.FactionHero.ArmyHero.IncreaseCreatureAmmount(1, 6);

            // SHOULD
            Assert.AreEqual(false, actual);
            //Army: 10 17 10 0
        }
    }
}
