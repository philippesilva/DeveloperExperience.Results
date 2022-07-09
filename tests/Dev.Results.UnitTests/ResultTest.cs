using NUnit.Framework;
using System.Collections.Generic;

namespace Dev.Results.UnitTests
{
    public class ResultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StatusWithSuccessTest()
        {
            var result = Result<string>.Success("Value");

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Data);
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void StatusWithErrorTest()
        {
            var result = Result<string>.Error("Error");

            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.IsFalse(result.IsSuccess);
        }

        [Test]
        public void StatusWithListErrorsTest()
        {
            var result = Result<string>.Error(new List<string> { "Error 1", "Error 2" });

            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.IsFalse(result.IsSuccess);
        }

        [Test]
        public void StatusWithInvalidTest()
        {
            var result = Result<string>.Invalid(new ValidationError("identifier", "error message"));

            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.IsFalse(result.IsSuccess);
        }

        [Test]
        public void StatusWithListInvalidsTest()
        {
            var result = Result<string>.Invalid(new List<ValidationError> { new("identifier", "error message") });

            Assert.IsNotNull(result);
            Assert.IsNull(result.Data);
            Assert.IsFalse(result.IsSuccess);
        }
    }
}