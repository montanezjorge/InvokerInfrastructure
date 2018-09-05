namespace Invoker.Infrastructure
{
    using System;

    public class Id
    {
        public Id()
        {
            this.Value = Guid.Empty;
        }

        public Id(Guid id)
        {
            this.Value = id;
        }

        public Id(string id)
        {
            this.Value = new Guid(id);
        }

        public Guid Value { get; set; }

        public override bool Equals(object obj)
        {
            return this == (obj as Id)
                || this == (obj as Guid?)
                || this == (obj as string);
        }

        public override int GetHashCode()
        {
            return this.Value.ToString().GetHashCode();
        }

        public static bool operator ==(Id a, string b)
        {
            return a.Value.ToString() == b;
        }

        public static bool operator ==(Id a, Guid b)
        {
            return a.Value == b;
        }

        public static bool operator ==(Id a, Id b)
        {
            return a == b || a.Value == b.Value;
        }

        public static bool operator !=(Id a, string b)
        {
            return a.Value.ToString() != b;
        }

        public static bool operator !=(Id a, Guid b)
        {
            return a.Value == b;
        }

        public static bool operator !=(Id a, Id b)
        {
            return a != b && a.Value != b.Value;
        }

        public static implicit operator Id(Guid guid)
        {
            return new Id(guid);
        }

        public static implicit operator Id(string guidString)
        {
            var guid = Guid.Empty;

            if (!Guid.TryParse(guidString, out guid))
            {
                throw new ArgumentException("The specified argument is not a string representation of a Guid");
            }

            return guid;
        }
    }
}
