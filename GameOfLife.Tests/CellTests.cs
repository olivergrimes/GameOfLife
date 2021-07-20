using Moq;
using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTests
    {
        [Fact]
        public void Cell_requires_neighbour_state()
        {
            Assert.Throws<ArgumentNullException>(() => new Cell(true, null));
        }

        [Theory]
        [InlineData(true, 2, true)]
        [InlineData(true, 3, true)]
        [InlineData(false, 3, true)]
        [InlineData(true, 0, false)]
        [InlineData(true, 1, false)]
        [InlineData(true, 4, false)]
        [InlineData(true, 5, false)]
        [InlineData(true, 6, false)]
        [InlineData(true, 7, false)]
        [InlineData(true, 8, false)]
        [InlineData(false, 0, false)]
        [InlineData(false, 1, false)]
        [InlineData(false, 2, false)]
        [InlineData(false, 4, false)]
        [InlineData(false, 5, false)]
        [InlineData(false, 6, false)]
        [InlineData(false, 7, false)]
        [InlineData(false, 8, false)]
        [InlineData(false, -8, false)]
        [InlineData(false, 9, false)]
        [InlineData(true, -1, false)]
        [InlineData(true, 100, false)]
        public void Next_state_calculated_correctly(bool initialState, int neighboursAlive, bool expectedNextState)
        {
            var neighbourState = new Mock<INeighbourState>();

            neighbourState
                .Setup(n => n.AliveNeighbours())
                .Returns(neighboursAlive);

            var sut = new Cell(initialState, neighbourState.Object);

            var nextState = sut.GetNextState();

            Assert.Equal(nextState, expectedNextState);
        }
    }
}
