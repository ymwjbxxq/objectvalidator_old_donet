using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectValidator.Tests.Fakes;
using System.Linq;

namespace ObjectValidator.Tests
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void GIVEN_Pluto_name_WHEN_validate_THEN_validation_will_no_pass_AND_will_return_error()
        {
            // Arrange
            var myObject = new Person
            {
                Name = "Pluto",
                Surname = "Something"
            };

            // Act
            var result = myObject.Validate();

            // Arrange
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.Errors.Count());
        }

        [TestMethod]
        public void GIVEN_Pluto_name_AND_Pippo_as_Surname_WHEN_validate_THEN_validation_will_no_pass_AND_will_return_error()
        {
            // Arrange
            var myObject = new Person
            {
                Name = "Pluto",
                Surname = "Pippo"
            };

            // Act
            var result = myObject.Validate();

            // Arrange
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(2, result.Errors.Count());
        }

        [TestMethod]
        public void GIVEN_a_no_Pluto_name_AND_a_no_Pippo_as_Surname_WHEN_validate_THEN_validation_will_pass_AND_no_errors()
        {
            {
                // Arrange
                var myObject = new Person
                {
                    Name = "Name",
                    Surname = "Surname"
                };

                // Act
                var result = myObject.Validate();

                // Arrange
                Assert.IsTrue(result.IsValid);
                Assert.AreEqual(0, result.Errors.Count());
            }
        }
    }
}