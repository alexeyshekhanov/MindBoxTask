using Figures;
using FluentAssertions;

namespace FiguresTests
{
    public class CircleTests
    {
        [Fact]
        public void ConstructorExceptionTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new Circle(-1.0));
            exception.Message.Should().StartWith("The radius");
            exception.ParamName.Should().Be("r");
        }

        [Fact]
        public void RadiusSetExeptionTest() 
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var circle = new Circle(1.0);
                circle.Radius = -1.0;
            });
            exception.Message.Should().StartWith("The radius");
            exception.ParamName.Should().Be("r");
        }

        [Fact]
        public void SquareTest() 
        {
            var circle = new Circle(2.0);
            Assert.Equal(2.0, circle.Radius);
            
            var square = circle.GetSquare();
            Assert.Equal(12.56637, Math.Round(square, 5));
            
            circle.Radius = 1 / Math.Sqrt(Math.PI);
            square = circle.GetSquare();
            Assert.Equal(1, Math.Round(square, 5));

        }
    }
}