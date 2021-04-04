using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorks()
        {
            string expectedName = "Serafim";
            int expectedDamage = 50;
            int expectedHP = 100;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHP, actualHp);
        }

        [Test]
        public void TestWithNullName()
        {
            string name = null;
            int damage = 50;
            int hitPoints = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hitPoints);
            });

        }

        [Test]
        public void TestWIthEmptyName()
        {
            string name = String.Empty;
            int damage = 50;
            int hitPoints = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hitPoints);
            });
        }

        [Test]
        public void TestWIthWhitespaceName()
        {
            string name = "                  ";
            int damage = 50;
            int hitPoints = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hitPoints);
            });
        }

        [Test]
        public void TestWithZeroDamage()
        {
            string name = "Serafim";
            int damage = 0;
            int hitPoints = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hitPoints);
            });
        }

        [Test]
        public void TestWithNegativeDamage()
        {
            string name = "Serafim";
            int damage = -10;
            int hitPoints = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hitPoints);
            });
        }

        [Test]
        public void TestWithNegativeHitPoints()
        {
            string name = "Serafim";
            int damage = 10;
            int hitPonts = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hitPonts);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackWhenLowHP(int attackerHitPoints)
        {
            string attackerName = "Serafim";
            int attackerDamage = 10;

            string defenderName = "Pesho";
            int defenderDamage = 10;
            int defenderHitPoints = 40;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHitPoints);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHitPoints);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);

            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackEnemyWithLowHP(int defenderHitPoints)
        {
            string attackerName = "Serafim";
            int attackerDamage = 10;
            int attackerHitPoints = 100;

            string defenderName = "Pesho";
            int defenderDamage = 10;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHitPoints);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHitPoints);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);

            });
        }

        [Test]
        public void AttackingStrongerEnemy()
        {
            string attackerName = "Serafim";
            int attackerDamage = 10;
            int attackerHitPoints = 35;

            string defenderName = "Pesho";
            int defenderDamage = 40;
            int defenderHitPoints = 35;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHitPoints);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHitPoints);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);

            });
        }

        [Test]
        public void AttackingShouldDecreaseHP()
        {
            string attackerName = "Serafim";
            int attackerDamage = 10;
            int attackerHitPoints = 40;

            string defenderName = "Pesho";
            int defenderDamage = 5;
            int defenderHitPoints = 50;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHitPoints);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHitPoints);

            int expectedAttackerHP = attackerHitPoints - defenderDamage;
            int expectedDefenderHP = defenderHitPoints - attackerDamage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void KillingEnemyWithAttack()
        {
            string attackerName = "Serafim";
            int attackerDamage = 80;
            int attackerHitPoints = 100;

            string defenderName = "Pesho";
            int defenderDamage = 10;
            int defenderHitPoints = 60;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHitPoints);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHitPoints);

            int expectedAttackerHP = attackerHitPoints - defenderDamage;
            int expectedDefenderHP = 0;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}