using ContentConsole.AppInterfaces;

namespace ContentConsole
{
    public class ContentConsole
    {
        private readonly IUserMenuSelection _userMenuSelection;
        private readonly IConsoleInteraction _consoleInteraction;
        private readonly IAdminMenuSelection _adminMenuSelection;

        public ContentConsole(
            IUserMenuSelection userMenuSelection,
            IConsoleInteraction consoleInteraction, 
            IAdminMenuSelection adminMenuSelection
        )
        {
            _userMenuSelection = userMenuSelection;
            _consoleInteraction = consoleInteraction;
            _adminMenuSelection = adminMenuSelection;
        }

        public void Start()
        {
            while (_consoleInteraction.Quit == false)
            {
                _consoleInteraction.ShowRoleMenu();

                var menuSelection = _consoleInteraction.GetMenuSelection();

                _consoleInteraction.ClearScreen();

                switch (menuSelection)
                {
                    case '1':
                        _userMenuSelection.Execute();
                        break;
                    case '2':
                        _adminMenuSelection.Execute();
                        break;
                    default:
                        _consoleInteraction.Quit = true;
                        break;
                }

                _consoleInteraction.ClearScreen();
            }
        }
    }
}