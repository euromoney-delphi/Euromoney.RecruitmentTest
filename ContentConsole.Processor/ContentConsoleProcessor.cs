using System;
using ContentConsole.Model;
using ContentConsole.Service;

namespace ContentConsole.Processor
{
    public class ContentConsoleProcessor : IContentConsoleProcessor
    {
        private readonly IUserInputProcessor _processor;
        private readonly INegativeWordsApiService _apiService;

        public ContentConsoleProcessor(IUserInputProcessor processor, INegativeWordsApiService apiService)
        {
            _processor = processor;
            _apiService = apiService;
        }


        public void Run()
        {

            Console.WriteLine($"Please select your role. Type A for Admin Role, C for Content Curator or U for user:");
            var role = Console.ReadLine();

            if (role == Constants.ADMIN_ROLE)
            {
                ProgramHelper.RunAdminPath(_apiService, _processor);
                return;
            }
            else if (role == Constants.CONTENT_CURATOR_ROLE)
            {
                ProgramHelper.RunContentCuratorPath(_processor);
                return;
            }

            ProgramHelper.GetUserInputWithFilter(_processor);
        }
    }
}

