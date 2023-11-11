using Figures;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FiguresTests
{
    public class TriangleTests
    {
        [Fact]
        public void ConstructorTriangleDoesNotExistTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new Triangle(1, 2, 3));
            Assert.Equal("A triangle with these sides doesn't exist", exception.Message);
        }

        [Fact]
        public void ConstructorZeroSideLengthTest()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new Triangle(1, 2, 0));
            Assert.Equal("Each side must be above 0", exception.Message);
        }

        [Fact]
        public void SetSideLenghtZeroTest()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.A = -1; 
            });
            Assert.Equal("Each side must be above 0", exception.Message);

            exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.B = -1;
            });
            Assert.Equal("Each side must be above 0", exception.Message);

            exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.C = -1;
            });
            Assert.Equal("Each side must be above 0", exception.Message);
        }

        [Fact]
        public void SetInvalidSideLengthTest()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.A = 5;
            });
            Assert.Equal("A triangle with these sides doesn't exist", exception.Message);

            exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.B = 5;
            });
            Assert.Equal("A triangle with these sides doesn't exist", exception.Message);

            exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.C = 5;
            });
            Assert.Equal("A triangle with these sides doesn't exist", exception.Message);
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(65, 72, 97)]
        public void RightTriangleTest(double firstSide, double secondSide, double thirdSide)
        {
            var triangle = new Triangle(firstSide, secondSide, thirdSide);
            triangle.isRightTriangle().Should().BeTrue();
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(6, 5, 5, 12)]
        [InlineData(17, 15, 8, 60)]
        public void SquareTest(double firstSide, double secondSide, double thirdSide, double expectedSquare)
        {
            var triangle = new Triangle(firstSide, secondSide, thirdSide);
            var actualSquare = triangle.GetSquare();
            Assert.Equal(expectedSquare, actualSquare);
        }
    }
}
