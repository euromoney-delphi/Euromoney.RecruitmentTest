using ContentConsole.AppInterfaces;

namespace ContentConsole.AppServices
{
    public class UserMenuSelection : IUserMenuSelection
    {
        private readonly IUserService _userService;
        private readonly IUserInteraction _userInteraction;

        public UserMenuSelection(IUserService userService, IUserInteraction userInteraction)
        {
            _userService = userService;
            _userInteraction = userInteraction;
        }

        public void Execute()
        {
            string textInput = _userInteraction.GetTextInput();

            int count = _userService.GetNegativeWordCount(textInput);

            _userInteraction.OutputScannedText(textInput);
            _userInteraction.OutputTotalNegativeWordsToScreen(count);
            _userInteraction.PressAnyKeyToExit();
        }
    }
}