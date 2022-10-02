using XUnitApp;

namespace XUnitTest
{
    public class XUnitTestMethodWithoutParameter
    {

        // Without paramter test methods

        #region Assert.Equal - Assert.NotEqual
        [Fact]
        public void EqualTest()
        {
            // Arrange
            var methodSum = new Method();

            // Act
            var result = methodSum.Sum(5, 5);

            // Assert
            Assert.Equal<int>(result, 10);
        }

        [Fact]
        public void NotEqualTest()
        {
            // Arrange
            var methodSum = new Method();

            // Act
            var result = methodSum.Sum(5, 5);

            // Assert
            Assert.NotEqual<int>(result, 20);
        }
        #endregion

        #region Assert.Contains - Assert.DoesNotContain
        [Fact]
        public void NameContainTest()
        {
            // Arrange
            var methodWriteName = new Method();

            // Act
            var result = methodWriteName.WriteName("Ozan Akaydin");

            // Assert
            Assert.Contains("Ozan", result);
        }


        [Fact]
        public void ArrayContainTest()
        {
            // Arrange
            var methodGetNamesArray = new Method();

            // Act
            var result = methodGetNamesArray.GetNamesArray("Ali", "Veli", "Mehmet");

            // Assert
            Assert.Contains<string>("Ali", result);
        }

        [Fact]
        public void ListContainTest()
        {
            // Arrange
            var methodGetDaysList = new Method();

            // Act
            var result = methodGetDaysList.GetDaysList(new List<string> { "Monday", "Thusdat", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });

            // Assert
            Assert.Contains<string>(result, d => d == "Saturday");
        }
        [Fact]
        public void NameDoesNotContainTest()
        {
            // Arrange
            var methodWriteName = new Method();

            // Act
            var result = methodWriteName.WriteName("Ozan Akaydin");

            // Assert
            Assert.DoesNotContain("ozan", result);
        }





        #endregion

        #region Assert.True - Assert.False
        [Fact]
        public void GetNumberTrueTest()
        {
            // Arrange
            var methodGetNumber = new Method();

            // Act
            var result = methodGetNumber.GetNumber(6);

            // Assert
            Assert.True(result > 5);
        }

        [Fact]
        public void GetNumberFalseTest()
        {
            // Arrange
            var methodGetNumber = new Method();

            // Act
            var result = methodGetNumber.GetNumber(6);

            // Assert
            Assert.False(result < 5);
        }
        #endregion

        #region Assert.Matches - Assert.DoesNotMatch

        [Fact]
        public void StartWordMatchesTest()
        {
            // Arrange
            var methodStartWord = new Method();

            // Act
            var result = methodStartWord.StartWord("^dog");

            // Assert
            Assert.Matches(result, "dog is an animal");
        }
        [Fact]
        public void StartWordDoesNotMatchTest()
        {
            // Arrange
            var methodStartWord = new Method();

            // Act
            var regEx = methodStartWord.StartWord("^dog");

            // Assert
            Assert.DoesNotMatch(regEx, "is a dog an animal");
        }

        #endregion

        #region Assert.StartsWith - Assert.EndsWith
        [Fact]
        public void StartsWithTest()
        {
            // Arrange
            var methodGetSentence = new Method();

            // Act
            var sentence = methodGetSentence.GetSentence("Today is sunny.");
            string[] word = sentence.Split(" ");
            var result = word[0];

            // Assert
            Assert.StartsWith(result, "Today");
        }

        [Fact]
        public void EndsWithTest()
        {
            // Arrange
            var methodGetSentence = new Method();

            // Act
            var sentence = methodGetSentence.GetSentence("Today is sunny.");
            string[] word = sentence.Split(" ");
            var result = word[2];

            // Assert
            Assert.EndsWith(result, "sunny.");
        }
        #endregion

        #region Assert.Empty - Assert.NotEmpty
        [Fact]
        public void EmptyTest()
        {
            // Arrange
            var methodIsEmpty = new Method();

            // Act
            var result = methodIsEmpty.IsEmpty(string.Empty);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void NotEmptyTest()
        {
            // Arrange
            var methodIsEmpty = new Method();

            // Act
            var result = methodIsEmpty.IsEmpty("Hello world");

            // Assert
            Assert.NotEmpty(result);
        }
        #endregion

        #region Assert.InRange - Assert.NotInRange
        [Fact]
        public void InRangeTest()
        {
            // Arrange
            var methodGetWordLength = new Method();

            // Act
            var result = methodGetWordLength.GetWordLength("Hello word");

            // Assert
            Assert.InRange<int>(result, 3, 10);
        }

        [Fact]
        public void NotInRangeTest()
        {
            // Arrange
            var methodGetWordLength = new Method();

            // Act
            var result = methodGetWordLength.GetWordLength("Hello word");

            // Assert
            Assert.NotInRange<int>(result, 3, 9);
        }
        #endregion

        #region Assert.Single
        [Fact]
        public void SingleTest()
        {
            // Arrange
            var methodGetCharArray = new Method();

            // Act
            var result = methodGetCharArray.GetCharArray('a');

            // Assert
            Assert.Single(result);
        }
        #endregion

        #region Assert.IsType - Assert.IsNotType
        [Fact]
        public void IsTypeTest()
        {
            // Arrange
            var methodGetParameterType = new Method();

            // Act
            var result = methodGetParameterType.GetParameterType(1);

            // Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public void IsNotTypeTest()
        {
            // Arrange
            var methodGetParameterType = new Method();

            // Act
            var result = methodGetParameterType.GetParameterType(1);

            // Assert
            Assert.IsNotType<string>(result);
        }
        #endregion

        #region Assert.IsAssignableFrom
        [Fact]
        public void IsAssignableFromTest()
        {
            // Arrange
            var methodGetAnimals = new Method();

            // Act
            var result = methodGetAnimals.GetAnimals(new List<string> { "Dog", "Cat", "Cow", "Sheep" });

            // Assert
            Assert.IsAssignableFrom<IEnumerable<string>>(result);

            // Assert
            Assert.IsAssignableFrom<Object>("Hello world");
        }
        #endregion

        #region Assert.Null - Assert.NotNull
        [Fact]
        public void NullTest()
        {
            // Arrange
            var methodGetAnimals = new Method();

            // Act
            var vehicles  = methodGetAnimals.GetVehicles(new List<string>());
            vehicles = null;

            // Assert
            Assert.Null(vehicles);

        }

        [Fact]
        public void NotNullTest()
        {
            // Arrange
            var methodGetVehicles = new Method();

            // Act
            var result = methodGetVehicles.GetVehicles(new List<string> { "Car", "Plane", "Bike" });

            // Assert
            Assert.NotNull(result);

        }
        #endregion

    }
}