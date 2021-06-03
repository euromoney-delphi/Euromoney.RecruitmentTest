namespace Application.Interfaces
{
    public interface IConsoleIOManager
    {
        public void OutputTextToConsole(string textToOutput);
        public string ReadConsoleTextEntry();
    }
}
