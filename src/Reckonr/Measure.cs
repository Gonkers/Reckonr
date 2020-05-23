using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace Reckonr
{
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct Measure : IEquatable<Measure>
    {
        public static Measure Time { get; } = new Measure(Dimension.Time);
        public static Measure Length { get; } = new Measure(Dimension.Length);
        public static Measure Mass { get; } = new Measure(Dimension.Mass);
        public static Measure ElectricCurrent { get; } = new Measure(Dimension.ElectricCurrent);
        public static Measure Temperature { get; } = new Measure(Dimension.Temperature);
        public static Measure AmountOfSubstance { get; } = new Measure(Dimension.AmountOfSubstance);
        public static Measure LuminousIntensity { get; } = new Measure(Dimension.LuminousIntensity);







        public static Measure Area { get; } = Length ^ 2;
        public static Measure Volume { get; } = Length ^ 3;
        public static Measure Speed { get; } = Length / Time;
        public static Measure VolumetricFlowRate { get; } = Volume / Time;
        public static Measure LinearDensity { get; } = Volume / Length;
        public static Measure AeralDensity { get; } = Volume / Area;
        public static Measure Density { get; } = Mass / Volume;
        public static Measure Acceleration { get; } = Length / Time ^ 2;


        public IEnumerable<(Dimension Dimension, sbyte Power)> GetDimensions()
        {
            if (_time != 0) yield return (Dimension.Time, _time);
            if (_length != 0) yield return (Dimension.Length, _length);
            if (_mass != 0) yield return (Dimension.Mass, _mass);
            if (_electricCurrent != 0) yield return (Dimension.ElectricCurrent, _electricCurrent);
            if (_temperature != 0) yield return (Dimension.Temperature, _temperature);
            if (_substance != 0) yield return (Dimension.AmountOfSubstance, _substance);
            if (_luminousIntensity != 0) yield return (Dimension.LuminousIntensity, _luminousIntensity);
        }

        private Measure(Dimension dimension)
        {
            _time = _length = _mass = _electricCurrent = _temperature = _substance = _luminousIntensity = 0;
            _dimensions = (long)dimension;
        }

        private Measure(int time, int length, int mass, int electricCurrent, int temperature, int substance, int luminousIntensity)
        {
            sbyte castGuard(int val, string paramName)
            {
                if (val < sbyte.MinValue || val > sbyte.MaxValue)
                    throw new ArgumentException($"Converting {val} to sbyte would result in overflow.", paramName, new OverflowException());
                return (sbyte)val;
            }

            _dimensions = 0;
            _time = castGuard(time, nameof(time));
            _length = castGuard(length, nameof(length));
            _mass = castGuard(mass, nameof(mass));
            _electricCurrent = castGuard(electricCurrent, nameof(electricCurrent));
            _temperature = castGuard(temperature, nameof(temperature));
            _substance = castGuard(substance, nameof(substance));
            _luminousIntensity = castGuard(luminousIntensity, nameof(luminousIntensity));
        }

        [FieldOffset(0)]
        private readonly long _dimensions;
        [FieldOffset(0)]
        private readonly sbyte _time;
        [FieldOffset(1)]
        private readonly sbyte _length;
        [FieldOffset(2)]
        private readonly sbyte _mass;
        [FieldOffset(3)]
        private readonly sbyte _electricCurrent;
        [FieldOffset(4)]
        private readonly sbyte _temperature;
        [FieldOffset(5)]
        private readonly sbyte _substance;
        [FieldOffset(6)]
        private readonly sbyte _luminousIntensity;


        public static Measure operator *(Measure left, Measure right)
        {
            return new Measure(
                left._time + right._time,
                left._length + right._length,
                left._mass + right._mass,
                left._electricCurrent + right._electricCurrent,
                left._temperature + right._temperature,
                left._substance + right._substance,
                left._luminousIntensity + right._luminousIntensity);
        }

        public static Measure operator /(Measure left, Measure right)
        {
            return new Measure(
                left._time - right._time,
                left._length - right._length,
                left._mass - right._mass,
                left._electricCurrent - right._electricCurrent,
                left._temperature - right._temperature,
                left._substance - right._substance,
                left._luminousIntensity - right._luminousIntensity);
        }

        public static Measure operator ^(Measure measure, sbyte exponent)
        {
            if (exponent == 0) return new Measure();
            return new Measure(
                measure._time * exponent,
                measure._length * exponent,
                measure._mass * exponent,
                measure._electricCurrent * exponent,
                measure._temperature * exponent,
                measure._substance * exponent,
                measure._luminousIntensity * exponent);
        }

        public bool Equals(Measure other) => ReferenceEquals(this, other) || _dimensions == other._dimensions;
        public override bool Equals(object obj) => ReferenceEquals(this, obj) || (obj is Measure && Equals((Measure)obj));
        public override int GetHashCode()
        {
            int hash = 2267;
            hash = (hash * 13) + _dimensions.GetHashCode();
            return hash;
        }
        public static bool operator ==(Measure left, Measure right) => left.Equals(right);
        public static bool operator !=(Measure left, Measure right) => !(left == right);
    }
}
