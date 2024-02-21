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
            exception.Message.Should().StartWith("A triangle with");
            exception.ParamName.Should().Be("c");

        }

        [Fact]
        public void ConstructorZeroSideLengthTest()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new Triangle(1, 2, 0));
            exception.Message.Should().StartWith("Each side must");
            exception.ParamName.Should().Be("c");


        }

        [Fact]
        public void SetSideLenghtZeroTest()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.A = -1; 
            });
            exception.Message.Should().StartWith("Each side must");
            exception.ParamName.Should().Be("a");

            exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.B = -1;
            });
            exception.Message.Should().StartWith("Each side must");
            exception.ParamName.Should().Be("b");

            exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.C = -1;
            });
            exception.Message.Should().StartWith("Each side must"); 
            exception.ParamName.Should().Be("c");

        }

        [Fact]
        public void SetInvalidSideLengthTest()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.A = 5;
            });
            exception.Message.Should().StartWith("A triangle with");
            exception.ParamName.Should().Be("a");


            exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.B = 5;
            });
            exception.Message.Should().StartWith("A triangle with");
            exception.ParamName.Should().Be("b");


            exception = Assert.Throws<ArgumentException>(() =>
            {
                var triangle = new Triangle(1, 2, 2);
                triangle.C = 5;
            });
            exception.Message.Should().StartWith("A triangle with");
            exception.ParamName.Should().Be("c");
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(65, 72, 97)]
        public void RightTriangleTest(double firstSide, double secondSide, double thirdSide)
        {
            var triangle = new Triangle(firstSide, secondSide, thirdSide);
            triangle.IsRightTriangle().Should().BeTrue();
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
