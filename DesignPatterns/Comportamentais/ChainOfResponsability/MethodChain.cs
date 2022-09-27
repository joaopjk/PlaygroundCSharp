using System.ComponentModel;

namespace ChainOfResponsability
{
  class Creature
  {
    public string Name;
    public int Attack, Defense;

    public Creature(string name, int attack, int defense)
    {
      Name = name;
      Attack = attack;
      Defense = defense;
    }
  }

  class CreatureModifier
  {
    protected Creature creature;
    protected CreatureModifier next; // linked list

    public CreatureModifier(Creature creature)
    {
      this.creature = creature;
    }

    public void Add(CreatureModifier cm)
    {
      if (next != null) next.Add(cm);
      else next = cm;
    }

    public virtual void Handle() => next?.Handle();
  }

  class DoubleAttackModifier : CreatureModifier
  {
    public DoubleAttackModifier(Creature creature) : base(creature) { }

    public override void Handle()
    {
      creature.Attack *= 2;
      base.Handle();
    }
  }

  class IncreasedDefenseModifier : CreatureModifier
  {
    public IncreasedDefenseModifier(Creature creature) : base(creature) { }

    public override void Handle()
    {
      creature.Defense *= 2;
      base.Handle();
    }
  }

  class NoBonusesModifier : CreatureModifier
  {
    public NoBonusesModifier(Creature creature) : base(creature) { }

    public override void Handle() { }
  }
}