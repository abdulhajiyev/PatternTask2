using System;

namespace StrategyPattern
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            IAttack strategy = new AssaultRifle();
            AttackStrategy soldier = new(strategy);
            soldier.Attack();

            strategy = new Shotgun();
            soldier = new(strategy);
            soldier.Attack();

            strategy = new SubmachineGun();
            soldier = new(strategy);
            soldier.Attack();

            Console.ReadLine();
        }
    }

    // IStrategy interface
    public interface IAttack
    {
        void Attack();
    }

    // ConcreteStrategyA class
    public class AssaultRifle : IAttack
    {
        // Implementing A strategy
        public void Attack() => Console.WriteLine("Attacked with Assault Rifle");
    }

    // ConcreteStrategyB class
    public class Shotgun : IAttack
    {
        // Implementing B strategy
        public void Attack() => Console.WriteLine("Attacked with Shotgun");
    }

    // ConcreteStrategyC class
    public class SubmachineGun : IAttack
    {
        // Implementing C strategy
        public void Attack() => Console.WriteLine("Attacked with Submachine Gun");
    }

    // Context class
    public class AttackStrategy
    {
        private IAttack _strategy;

        public AttackStrategy(IAttack strategy)
        {
            _strategy = strategy;
        }

        public void Attack()
        {
            _strategy.Attack();
        }
    }
}
