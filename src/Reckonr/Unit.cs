using Reckonr.Bitwise;
using System;
using System.Collections.Generic;

namespace Reckonr
{
    /// <summary>
    /// A standard unit used to express the size, amount, or degree of something.
    /// </summary>
    public readonly struct Unit : IUnit
    {
        public string Name { get; }
        public string Symbol { get; }
        public Measure Dimensions { get; }
        //public decimal RatioToBase { get; }

        public Unit(string name, string symbol, Measure dimensions)
        {
            Name = name;
            Symbol = symbol;
            Dimensions = dimensions;
        }

        //public static class Length
        //{
        //    public static Unit Meter = new Unit(nameof(Meter), "m", Dimension.Length);
        //}

        //public static class Time
        //{
        //    public static Unit Second = new Unit(nameof(Second), "s", Dimension.Time);
        //}

        //public static class Mass
        //{
        //    public static Unit Kilogram = new Unit(nameof(Kilogram), "kg", Dimension.Mass);
        //}

        //public static class ElectricCurrent
        //{
        //    public static Unit Ampere = new Unit(nameof(Ampere), "A", Dimension.ElectricCurrent);
        //}

        //public static class Temperature
        //{
        //    public static Unit Kelvin = new Unit(nameof(Kelvin), "K", Dimension.Temperature);
        //}

        //public static class AmountOfSubstance
        //{
        //    public static Unit Mole = new Unit(nameof(Mole), "mol", Dimension.AmountOfSubstance);
        //}

        //public static class LuminousIntensity
        //{
        //    public static Unit Candela = new Unit(nameof(Candela), "cd", Dimension.LuminousIntensity);
        //}
    }




    public interface IUnit
    {
        string Name { get; }
        string Symbol { get; }
        Measure Dimensions { get; }
        //public decimal RatioToBase { get; }
    }



    public readonly struct Measurement<U> where U : IUnit
    {

        // value
        // unit
    }








}
