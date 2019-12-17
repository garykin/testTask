using System;
using test_task;
using Xunit;

namespace UnitTests
{
    public class UnitTest1 : IClassFixture<TestsFixture>
    {

        private readonly string _filePath;

        public UnitTest1(TestsFixture testsFixture)
        {
            _filePath = testsFixture.FilePath;
        }


        [Fact]
        public void ThrowsExceptionWhenFilePathIsNull()
        {
            //Arrange
            string filePath = String.Empty;

            Assert.Throws<ArgumentNullException>(() => FileParser.ParseFile(filePath));
        }

        [Fact]
        public void ThrowsExceptionWhenFileDoesNotExist()
        {
            //Arrange
            string filePath = "panda";

            Assert.Throws<ArgumentException>(() => FileParser.ParseFile(filePath));
        }

        [Fact]
        public void ResultNotNull()
        {
            var result = FileParser.ParseFile(_filePath);
            Assert.NotNull(result);
        }

        [Fact]
        public void ResultHasIncorrectRows()
        {
            var result = FileParser.ParseFile(_filePath);
            Assert.NotEmpty(result.IncorrectLinesNumbers);
        }

        [Fact]
        public void ResultHasAllIncorrectRows()
        {
            var result = FileParser.ParseFile(_filePath);

            Assert.Contains(2, result.IncorrectLinesNumbers);
            Assert.Contains(3, result.IncorrectLinesNumbers);
            Assert.Contains(4, result.IncorrectLinesNumbers);
        }

        [Fact]
        public void ResultHasCorrectMaxSumRowNumber()
        {
            var result = FileParser.ParseFile(_filePath);
            Assert.Equal(6, result.MaxSumLineNumber);
        }

        [Fact]
        public void ResultHasCorrectMaxSumValue()
        {
            var result = FileParser.ParseFile(_filePath);
            Assert.Equal(100, result.MaxSum);
        }
    }
}
