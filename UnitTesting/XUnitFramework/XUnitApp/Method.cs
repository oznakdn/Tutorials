namespace XUnitApp
{
    public class Method
    {

        #region Equal and NotEqual
        public int Sum(int a, int b)
        {
            return a + b;
        }
        #endregion
        #region Contains and DoesNotContain
        public string WriteName(string fullName)
        {
            return fullName;
        }

        public string[] GetNamesArray(params string[] names)
        {
            return names;
        }

        public List<string> GetDaysList(List<string> days)
        {
            return days;
        }

        #endregion
        #region True and False
        public int GetNumber(int number)
        {
            return number;
        }
        #endregion
        #region Matches and DoesNotMatch
        public string StartWord(string word)
        {
            return word;
        }
        #endregion
        #region StartsWith and EndsWith
        public string GetSentence(string sentence)
        {
            return sentence;
        }
        #endregion
        #region Empty and NotEmpty
        public string IsEmpty(string value)
        {
            return value;
        }
        #endregion
        #region InRange and NotInRange
        public int GetWordLength(string word)
        {
            return word.Length;
        }
        #endregion
        #region Single
        public char[] GetCharArray(params char[] letters)
        {
            return letters;
        }
        #endregion
        #region IsType and IsNotType
        public int GetParameterType(int number)
        {
            return number;
        }
        #endregion
        #region IsAssignableFrom
        public List<string> GetAnimals(List<string> animals)
        {
            return animals;
        }
        #endregion
        #region Null and NotNull
        public List<string> GetVehicles(List<string> vehicles)
        {
            return vehicles;
        }
        #endregion
    }
}