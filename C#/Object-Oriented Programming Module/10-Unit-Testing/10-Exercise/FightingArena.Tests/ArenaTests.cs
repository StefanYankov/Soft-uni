using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior1;
        private Warrior attacker;
        private Warrior defender;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();

            this.warrior1 = new Warrior("Serafim", 5, 50);
            this.attacker = new Warrior("Serafim", 5, 100);
            this.defender = new Warrior("Pesho", 8, 200);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollShouldAddWarriorToArena()
        {
            this.arena.Enroll(warrior1);

            Assert.That(this.arena.Warriors, Has.Member(this.warrior1));
        }

        [Test]
        public void EnrollShouldIncreaseCount()
        {
            int expectedCount = 2;

            this.arena.Enroll(this.warrior1);
            this.arena.Enroll(new Warrior("Pesho", 5, 60));

            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount,actualCount);

        }

        [Test]
        public void EnrollTheSameWarriorTwice()
        {
            this.arena.Enroll(this.warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(this.warrior1);

            });
        }

        [Test]
        public void EnrollAWarriorWithTheSameNameTwice()
        {
            Warrior warrior1Copy = new Warrior(warrior1.Name, warrior1.Damage, warrior1.HP);
            this.arena.Enroll(this.warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior1Copy);

            });
        }

        [Test]
        public void FightWithMissingAttacker()
        {
            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });
        }

        [Test]
        public void FightWithMissingDefender()
        {
            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });
        }

        [Test]
        public void BothWarriorFighting()
        {
            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            int expectedAttackerHp = this.attacker.HP - this.defender.Damage;
            int expectedDefenderHP = this.defender.HP - this.attacker.Damage;

            this.arena.Fight(this.attacker.Name, this.defender.Name);


            Assert.AreEqual(expectedAttackerHp, this.attacker.HP);
            Assert.AreEqual(expectedDefenderHP, this.defender.HP);

        }
    }
}
