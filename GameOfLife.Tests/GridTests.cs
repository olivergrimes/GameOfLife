using Xunit;
using FluentAssertions;

namespace GameOfLife.Tests
{
    public class GridTests
    {
        [Fact]
        public void Grid_retains_initial_state_bounds()
        {
            var initialState = new[,] 
            {
                { false, false },
                { false, false }
            };

            var sut = new Grid(initialState);

            sut.Tick();
            var state = sut.CurrentState();

            Assert.Equal(state.GetUpperBound(0), initialState.GetUpperBound(0));
            Assert.Equal(state.GetUpperBound(1), initialState.GetUpperBound(1));
        }

        [Fact]
        public void Given_horizontal_triplet_then_vertical_triplet_on_next_tick()
        {
            var horizontalState = new[,]
            {
                { false, false, false, false, false },
                { false, false, false, false, false },
                { false, true, true, true, false },
                { false, false, false, false, false },
                { false, false, false, false, false },
            };

            var verticalState = new[,]
            {
                { false, false, false, false, false },
                { false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, false, false, false },
            };

            var sut = new Grid(horizontalState);

            sut.Tick();

            var gen1 = sut.CurrentState();

            sut.Tick();

            var gen2 = sut.CurrentState();

            gen1.Should().BeEquivalentTo(verticalState);
            gen2.Should().BeEquivalentTo(horizontalState);
        }
    }
}
