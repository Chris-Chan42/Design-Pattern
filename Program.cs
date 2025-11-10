using System.Xml.Serialization;

namespace Design_Pattern
{
    // The Design Pattern demonstrated here is the Strategy Pattern.
    // The type of pattern is Behavioral.
    // Example Scenario: In a game, different enemy types exhibit different behaviors (aggressive, defensive, passive).
    // https://en.wikipedia.org/wiki/Strategy_pattern#/media/File:Strategy_Pattern_in_UML.png
    // I would want to use this pattern in the future because I want to eventually make a game and learning how to use the Strategy Pattern more effectively will help me design better AI for enemies in the game.
    public class Program
    {
        public static void Main(string[] args)
        {
            Enemy goblin = new Enemy("Goblin", new AggressiveBehavior());
            Enemy golem = new Enemy("Golem", new DefensiveBehavior());
            Enemy elf = new Enemy("Elf", new PassiveBehavior());

            goblin.PerformBehavior();
            golem.PerformBehavior();
            elf.PerformBehavior();

            Console.WriteLine("\n-- Changing Behaviors --\n");

            goblin.SetBehaviorStrategy(new DefensiveBehavior());
            golem.SetBehaviorStrategy(new PassiveBehavior());
            elf.SetBehaviorStrategy(new AggressiveBehavior());

            goblin.PerformBehavior();
            golem.PerformBehavior();
            elf.PerformBehavior();

        }

    }

    public interface IBehaviorStrategy
    {
        void ExecuteBehavior(string enemyName);
    }

    public class AggressiveBehavior : IBehaviorStrategy
    {
        public void ExecuteBehavior(string enemyName)
        {
            Console.WriteLine($"{enemyName} charges toward the player attacks ferociously!");
        }
    }

    public class DefensiveBehavior : IBehaviorStrategy
    {
        public void ExecuteBehavior(string enemyName)
        {
            Console.WriteLine($"{enemyName} takes a firm stance and defends cautiously.");
        }
    }

    public class PassiveBehavior : IBehaviorStrategy
    {
        public void ExecuteBehavior(string enemyName)
        {
            Console.WriteLine($"{enemyName} stays back and avoids conflict.");
        }
    }

    public class Enemy
    {
        private IBehaviorStrategy _behaviorStrategy;
        public string Name { get; }

        public Enemy(string name, IBehaviorStrategy initialBehavior)
        {
            Name = name;
            _behaviorStrategy = initialBehavior;
        }

        public void SetBehaviorStrategy(IBehaviorStrategy newBehavior)
        {
            _behaviorStrategy = newBehavior;
            Console.WriteLine($"{Name} changed behavior.");
        }

        public void PerformBehavior()
        {
            _behaviorStrategy.ExecuteBehavior(Name);
        }
    }

}
