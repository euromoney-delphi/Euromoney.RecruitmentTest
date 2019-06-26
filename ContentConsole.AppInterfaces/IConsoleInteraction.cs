namespace ContentConsole.AppInterfaces
{
    public interface IConsoleInteraction
    {
        void ClearScreen();
        char GetMenuSelection();
        void ShowRoleMenu();
        void Print(string outputText);
        bool Quit { get; set; }
    }
}