using System.Collections;
using System.Linq;
using Xunit;

namespace Reckonr.Tests
{
    public class MeasureTests
    {
        [Fact]
        public void Equality()
        {
            Assert.Equal(Measure.Time, Measure.Time);
            Assert.True(Measure.Speed != Measure.Time);
        }

        [Fact]
        public void Operator_Multiply()
        {
            var volume = Measure.Length * Measure.Length * Measure.Length;
            Assert.Single(volume.GetDimensions());
            Assert.Equal(3, volume.GetDimensions().Single().Power);
            Assert.Equal(Measure.Length, Measure.Speed * Measure.Time);
        }

        [Fact]
        public void Operator_Divide()
        {
            var area = Measure.Volume / Measure.Length;
            Assert.Single(area.GetDimensions());
            Assert.Equal(2, area.GetDimensions().Single().Power);
            Assert.Equal(Measure.Density, Measure.Mass / Measure.Volume);
        }

        [Fact]
        public void Operator_Power()
        {
            var area = Measure.Length ^ 2;
            Assert.Single(area.GetDimensions());
            Assert.Equal(2, area.GetDimensions().Single().Power);

            var volume = Measure.Length ^ 3;
            Assert.Single(volume.GetDimensions());
            Assert.Equal(3, volume.GetDimensions().Single().Power);

            var tesseract = area ^ 2;
            Assert.Single(tesseract.GetDimensions());
            Assert.Equal(4, tesseract.GetDimensions().Single().Power);
        }
    }
}
