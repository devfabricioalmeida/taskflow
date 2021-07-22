using System;
using System.Collections.Generic;
using Taskflow.Core.Menssages;

namespace Taskflow.Core.Domain
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public DateTime DataCriacao { get; private set; }

        private List<Event> _notifications = new List<Event>();
        public IReadOnlyCollection<Event> Notifications => _notifications;

        public void AddNotification(Event notification)
        {
            _notifications.Add(notification);
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public bool MyProperty { get; set; }

    }
}
