using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Materials
{
	public class Material : Entity
	{
        private readonly List<Event> history = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool InStock { get; private set; } = true;

        public bool OutOfStock => !InStock;
        public IReadOnlyList<Event> History => history.AsReadOnly();

        private Material() { }

        public Material(string name, string description)
        {
            Name = Guard.Against.NullOrWhiteSpace(name,nameof(name));
            Description = description;
        }

        public void Borrow(string student)
        {
            if (OutOfStock)
            {
                throw new ApplicationException();
            }

            Guard.Against.NullOrWhiteSpace(student ,nameof(student));

            history.Add(new Event(student, Event.ActionType.Borrow));
            InStock = false;
        }
    }
}

