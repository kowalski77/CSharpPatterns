using System;

namespace ChainOfResponsibilityAlternative
{
    public class Number
    {
        private Number(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            this.Value = value;
        }

        public static Number CreateInstance(int value)
        {
            return new Number(value);
        }

        public int Value { get; }

        public bool IsDivisibleBy(int value) => this.Value % value == 0;
    }
}