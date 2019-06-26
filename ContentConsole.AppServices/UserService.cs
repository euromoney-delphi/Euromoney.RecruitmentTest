using System;
using System.Linq;
using ContentConsole.AppInterfaces;

namespace ContentConsole.AppServices
{
    public class UserService : IUserService
    {
        private readonly INegativeWordStore _negativeWordStore;

        public UserService(INegativeWordStore negativeWordStore)
        {
            _negativeWordStore = negativeWordStore;
        }

        public int GetNegativeWordCount(string textInput)
        {
            var negativeWords = _negativeWordStore.GetAll();
            char[] separators = _negativeWordStore.GetSeparators();
            
            string[] wordsInTextInput = textInput.Split(separators);

            return negativeWords
                .Sum(negativeWord => wordsInTextInput
                    .Count(word => word.Equals(negativeWord, StringComparison.InvariantCulture)));
        }
    }
}