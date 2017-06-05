namespace ContentConsole.Words
{
    public interface IWordsService
    {

        void AddWord(string word);

        WordResponse Analyse(string phrase);

    }
}
