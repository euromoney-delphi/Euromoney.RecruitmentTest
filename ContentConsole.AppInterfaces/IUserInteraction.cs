namespace ContentConsole.AppInterfaces
{
    public interface IUserInteraction
    {
        string GetTextInput();

        void OutputScannedText(string textInput);

        void OutputTotalNegativeWordsToScreen(int negativeWordCount);

        void PressAnyKeyToExit();
    }
}