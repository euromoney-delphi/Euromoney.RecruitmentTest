namespace ContentConsole.Models
{
    public interface IPhrasePart
    {
        string Part { get; }
        bool IsWord { get; }
        void AddChar(char newChar);
        string ToString();
    }
}