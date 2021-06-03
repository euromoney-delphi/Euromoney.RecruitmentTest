using Application.Interfaces;
using Domain.UnkindContentReport;

namespace Application.Report
{
    public class UnkindContentReporterService : IUnkindContentReporterService
    {
        private readonly IBannedWordRepository _bannedWordRepository;

        public UnkindContentReporterService(IBannedWordRepository bannedWordRepository)
        {
            _bannedWordRepository = bannedWordRepository;
        }
        public IUnkindContentReport ProduceReport(string content)
        {
            var bannedWordCount = 0;
            var bannedWords = _bannedWordRepository.Get();
            var words = content.Split(" ");
            foreach (var word in words)
            {
                if (bannedWords.Contains(word))
                {
                    ++bannedWordCount;
                }
            }

            //with more time I would factor this into a factory.
            return new UnkindContentReport(content, bannedWordCount);
        }
    }
}
