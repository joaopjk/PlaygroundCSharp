using System;

namespace ChainOfResponsability
{
  public class Game
  {
    public event EventHandler<Query> Queries;

    public void PerformQuery(object sender, Query query)
    {
      Queries?.Invoke(sender, query);
    }
  }

  public class Query
  {
    public string CreatureName;
    public enum Argument
    {
      Attack, Defense
    }

    public Argument WhatToQuery;
    public int Value;

    public Query(string creatureName, Argument whatToQuery, int value)
    {
      CreatureName = creatureName;
      WhatToQuery = whatToQuery;
      Value = value;
    }
  }

  public class Creature2
  {
    private Game game;
    public string Name;
    private int attack, defense;

    public Creature2(Game game, string name, int attack, int defense)
    {
      this.game = game;
      Name = name;
      this.attack = attack;
      this.defense = defense;
    }

    public int Attack
    {
      get
      {
        var q = new Query(Name, Query.Argument.Attack, attack);
        game.PerformQuery(this, q);
        return q.Value;
      }
    }

    public int Defense
    {
      get
      {
        var q = new Query(Name, Query.Argument.Defense, defense);
        game.PerformQuery(this, q);
        return q.Value;
      }
    }
  }

  public abstract class CreatureModifier2
  {
    protected Game game;
    protected Creature2 creature;

    protected CreatureModifier2(Game game, Creature2 creature)
    {
      this.game = game;
      this.creature = creature;
      game.Queries += Handle;
    }

    protected abstract void Handle(object sender, Query q);
  }

  public class DoubleAttackModifier2 : CreatureModifier2
  {
    public DoubleAttackModifier2(Game game, Creature2 creature) : base(game, creature) { }

    protected override void Handle(object sender, Query q)
    {
      if (q.CreatureName == creature.Name && q.WhatToQuery == Query.Argument.Attack)
        q.Value *= 2;
    }
  }
}