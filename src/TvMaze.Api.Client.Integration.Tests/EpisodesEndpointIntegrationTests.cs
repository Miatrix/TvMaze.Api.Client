using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests
{
    public class EpisodesEndpointIntegrationTests
    {
        private readonly ITvMazeClient _tvMazeClient;

        public EpisodesEndpointIntegrationTests()
        {
            _tvMazeClient = new TvMazeClient();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(13961)]
        public async void GetEpisodeByIdAsync_ValidParameter_Success(int episodeId)
        {
            // act
            var response = await _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetEpisodeByIdAsync_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int episodeId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}