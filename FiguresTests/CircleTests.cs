using Figures;

namespace FiguresTests
{
    public class CircleTests
    {
        [Fact]
        public void ConstructorExceptionTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                new Circle(-1.0));
            Assert.Equal("The radius is invalid", exception.Message);
        }

        [Fact]
        public void RadiusSetExeptionTest() 
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var circle = new Circle(1.0);
                circle.Radius = -1.0;
            });
            Assert.Equal("The radius is invalid", exception.Message);
        }

        [Fact]
        public void SquareTest() 
        {
            var circle = new Circle(3.0);
            Assert.Equal(3.0, circle.Radius);
            circle.Radius = 2.0;
            Assert.Equal(2.0, circle.Radius);
            var square = circle.GetSquare();
            Assert.Equal(12.566370614359172, square);
        }
    }
}