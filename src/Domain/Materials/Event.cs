using System;
using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Materials
{
	public class Event : Entity
	{
        public string Student { get; }
        public ActionType Action { get; }

		private Event() { }

		public Event(string student, ActionType action)
		{
			Student = Guard.Against.NullOrWhiteSpace(student, nameof(student));
			Action = action;
		}
			
		public enum ActionType
		{
			Return,
			Borrow,
		}
	}
}

