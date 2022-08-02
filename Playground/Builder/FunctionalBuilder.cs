using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder
{
    public class PersonF
    {
        public string Name, Position;
    }

    public sealed class PersonBuilderF
    {
        private readonly List<Func<PersonF, PersonF>> actions = new();
        public PersonBuilderF Called(string name) => Do(_ => _.Name = name);
        public PersonBuilderF Do(Action<PersonF> action) => AddAction(action);
        public PersonF Build() => actions.Aggregate(new PersonF(), (p, f) => f(p));
        private PersonBuilderF AddAction(Action<PersonF> action)
        {
            actions.Add(_ =>
            {
                action(_);
                return _;
            });
            return this;
        }
    }

    public static class PersonBuilderExtensions
    {
        public static PersonBuilderF WorkAs(this PersonBuilderF builder, string position)
            => builder.Do(_ => _.Position = position);
    }
}
