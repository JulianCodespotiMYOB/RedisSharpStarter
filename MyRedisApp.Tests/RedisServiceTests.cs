using Xunit;
using Moq;
using MyRedisApp.Interfaces;
using MyRedisApp.Services;
using MyRedisApp.Models;
using StackExchange.Redis;

namespace MyRedisApp.Tests
{
    public class RedisServiceTests
    {
        private readonly Mock<IDatabase> _dbMock;
        private readonly IDatabaseService _service;

        public RedisServiceTests()
        {
            _dbMock = new Mock<IDatabase>();
            var redisConnectionMock = new Mock<IRedisConnection>();
            redisConnectionMock.Setup(r => r.GetDatabase()).Returns(_dbMock.Object);

            _service = new RedisService(redisConnectionMock.Object);
        }

        [Fact]
        public void Set_ShouldReturnTrue_WhenValueIsSet()
        {
            // Arrange
            var model = new ValueModel { Key = "key1", Value = "value1" };
            _dbMock.Setup(db => db.StringSet(It.IsAny<RedisKey>(), It.IsAny<RedisValue>(), 
                    It.IsAny<TimeSpan?>(), It.IsAny<When>(), It.IsAny<CommandFlags>()))
                .Returns(true);

            // Act
            var result = _service.Set(model);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Get_ShouldReturnStoredValue_WhenKeyExists()
        {
            // Arrange
            var expectedValue = "value1";
            _dbMock.Setup(db => db.StringGet(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
                .Returns(expectedValue);

            // Act
            var actualValue = _service.Get("key1");

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenKeyExists()
        {
            // Arrange
            _dbMock.Setup(db => db.KeyDelete(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
                .Returns(true);

            // Act
            var result = _service.Delete("key1");

            // Assert
            Assert.True(result);
        }
    }
}