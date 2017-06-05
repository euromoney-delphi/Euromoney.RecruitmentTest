using System;
using Domain;

namespace ContentConsole.Words
{
    public class WordsService: IWordsService
    {
        private readonly IRepository<Word> _wordsRepository;
        private readonly IWordsFactory _wordsFactory;
        private readonly IUserProfile _userProfile;

        public WordsService(IRepository<Word> wordsRepository,IWordsFactory wordsFactory,IUserProfile userProfile)
        {
            _wordsRepository = wordsRepository;
            _wordsFactory = wordsFactory;
            _userProfile = userProfile;
        }

        public void AddWord(string wordName)
        {
            if (wordName == null) throw new ArgumentNullException(nameof(wordName));

            if (!_userProfile.IsAdministrator()) throw new NotAllowedException();

            var word = new Word() {Name = wordName};
            _wordsRepository.Add(word);
        }

        public WordResponse Analyse(string phrase)
        {
            _wordsFactory.Init(phrase);

            var words = _wordsRepository.FindAll();
            
            foreach (var word in words)
            {
                if (phrase.Contains(word.Name))
                {
                    _wordsFactory.WithWordFound(word.Name);
                }
            }

            if (_userProfile.IsReader() && !_userProfile.IsContentCurator())
            {
                _wordsFactory.WithPretify('#');
            }

            return _wordsFactory.Create();
        }

     

    }
}
