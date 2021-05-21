using System;
using ContentConsole.Model;
using ContentConsole.Processor;
using ContentConsole.Service;

namespace ContentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Content content;
            var apiService = new NegativeWordsApiService();
            var userInputProcessor = new UserInputProcessor(apiService);

            Console.WriteLine($"Please select your role. Type A for Admin Role, C for Content Curator or U for user:");

            var role = Console.ReadLine();
            if (role == Constants.ADMIN_ROLE)
            {
                ProgramHelper.RunAdminPath(apiService, userInputProcessor);
                return;
            }
            else if (role == Constants.CONTENT_CURATOR_ROLE)
            {
                ProgramHelper.RunContentCuratorPath(apiService, userInputProcessor);
                return;
            }

            ProgramHelper.GetUserInputWithFilter(userInputProcessor);
        }

    }
}

