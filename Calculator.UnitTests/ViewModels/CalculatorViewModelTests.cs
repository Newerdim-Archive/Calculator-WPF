using Calculator.ViewModels;
using FluentAssertions;
using System;
using Xunit;

namespace Calculator.UnitTests.ViewModels
{
    public class CalculatorViewModelTests
    {
        private readonly CalculatorViewModel _sut;

        public CalculatorViewModelTests()
        {
            _sut = new CalculatorViewModel(12);
        }

        #region AddNumberCommand

        [Fact]
        public void AddNumberCommand_ParameterIsNotNull_AddsValueToCurrentValue()
        {
            // Arrange
            _sut.CurrentValue = "14";

            // Act
            _sut.AddNumberCommand.Execute("1");

            // Assert
            _sut.CurrentValue.Should().Be("141");
        }

        [Fact]
        public void AddNumberCommand_CurrentValueIsEqual0_Replace0WithValue()
        {
            // Arrange
            const string value = "1";

            _sut.CurrentValue = "0";

            // Act
            _sut.AddNumberCommand.Execute(value);

            // Assert
            _sut.CurrentValue.Should().Be(value);
        }

        [Fact]
        public void AddNumberCommand_ParameterIsNull_ThrowsArgumentNullException()
        {
            // Arrange

            // Act
            Action act = () => _sut.AddNumberCommand.Execute(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddNumberCommand_CurrentValueHasMaximumLength_CurrentValueNotChanged()
        {
            // Arrange
            const string expectedValue = "5";

            _sut.MaxScreenLenght = 1;
            _sut.CurrentValue = expectedValue;

            // Act
            _sut.AddNumberCommand.Execute("1");

            // Assert
            _sut.CurrentValue.Should().Be(expectedValue);
        }

        [Fact]
        public void AddNumberCommand_ParameterIsNotOfTypeString_ThrowsArgumentException()
        {
            // Arrange
            
            // Act
            Action act = () => _sut.AddNumberCommand.Execute(true);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}
