using System;
using System.Collections.Generic;
using System.Linq;
using NegativeContentService.Data;
using NegativeContentService.Models;

namespace NegativeContentService
{
    public class DetectNegativeWordService : IDetectNegativeWordService
    {
        private readonly INegativeWordRepository _negativeWordRepository;

        public DetectNegativeWordService(INegativeWordRepository negativeWordRepository)
        {
            _negativeWordRepository = negativeWordRepository;
        }

        public ContentAnalysisResult GetNegativeContentAnalysis(string content)
        {
            var bannedWords = _negativeWordRepository.GetAllNegativeWords();

            var numberOfBadWords = bannedWords.Count(content.Contains);

            var sanitizedContent = SanitizeContent(content, bannedWords);

            return new ContentAnalysisResult { OriginalContent = content, NumberOfBadWords = numberOfBadWords, SanitizedContent = sanitizedContent };
        }

        private static string SanitizeContent(string content, IList<string> bannedWords)
        {
            var hashedBannedWords = bannedWords.ToDictionary(x => x, HashBannedWord);
            return hashedBannedWords.Aggregate(content, (current, item) => current.Replace(item.Key, item.Value));
        }

        private static string HashBannedWord(string word)
        {
            var hashedWord = new string(word.Select((x, i) => ReplaceCharWithHash(x, i, word.Length)).ToArray());
            return hashedWord;
        }

        private static char ReplaceCharWithHash(char letter, int index, int wordLength)
        {
            if (index == 0 || index == wordLength - 1)
                return letter;
            return '#';
        }
    }
}
