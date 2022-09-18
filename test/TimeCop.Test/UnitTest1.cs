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

        [Fact]
        public void TimeLength_with_same_data_are_equal()
        {
            var t1 = new TimeLength(10);
            var t2 = new TimeLength(11);
            if (t1!=t2)
            {
                Console.WriteLine("true");
            }

            Assert.NotEqual(t1, t2);
        }



        [Fact]
        public void TimeLength_can_be_combined()
        {
            var t1 = new TimeLength(10);
            var t2 = new TimeLength(15);
            var t3 = t1 - t2; // 25

            Assert.Equal(t3.Value,Math.Abs(t1.Value - t2.Value));
        }


    }
}