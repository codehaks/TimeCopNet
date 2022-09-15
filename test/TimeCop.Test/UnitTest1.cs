using TimeCop.TimeSheet.Domain;

namespace TimeCop.Test
{
    public class TimeLengthTests
    {
        [Fact]
        public void Negative_Values_Are_Invalid()
        {
            // Arrange     
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>new TimeLength(-5));
        }

        [Fact]
        public void Zero_Is_Valid()
        {
            var t = new TimeLength(0);

            Assert.Equal(0, t.Value);
        }

        [Fact]
        public void Get_Hours_From_Minutes()
        {
            var t = new TimeLength(110);

            Assert.Equal(1.83, t.GetHours());
        }
    }
}