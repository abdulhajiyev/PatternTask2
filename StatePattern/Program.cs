using System;

namespace StatePattern
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Player player = new();
            player.BulletHit(3);
            player.BulletHit(9);
            player.BulletHit(12);

            Console.ReadKey();
        }
    }

    // Context class
    public class Player
    {
        IState _currentState;

        public Player()
        {
            _currentState = new HealthyState();
        }

        public void BulletHit(int bullets)
        {
            Console.WriteLine($"{bullets} bullets hit the player");
            _currentState = bullets switch
            {
                < 5 => new HealthyState(),
                >= 5 and < 10 => new HurtState(),
                >= 10 => new DeadState()
            };

            _currentState.ExecuteCommand(this);
        }
    }

    // State interface
    public interface IState
    {
        void ExecuteCommand(Player player);
    }

    // 'ConcreteStateA' class
    public class HealthyState : IState
    {
        public void ExecuteCommand(Player player)
        {
            Console.WriteLine("The player is healthy\n");
        }
    }

    // ConcreteStateB class
    public class HurtState : IState
    {
        public void ExecuteCommand(Player player)
        {
            Console.WriteLine("The player is wounded. Please search health points\n");
        }
    }

    // ConcreteStateC class
    public class DeadState : IState
    {
        public void ExecuteCommand(Player player)
        {
            Console.WriteLine("The player is dead. Game Over");
        }
    }
}
