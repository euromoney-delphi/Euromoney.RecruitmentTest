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

            Console.WriteLine($"Please select your role: {Constants.ADMIN_ROLE} for admin, {Constants.CONTENT_CURATOR_ROLE} for content curator, {Constants.READER_ROLE} for reader role or {Constants.USER_ROLE} for user.");
            var role = Console.ReadLine();

            switch (role.ToUpper())
            {
                case Constants.ADMIN_ROLE:
                    {
                        ProgramHelper.RunAdminPath(_apiService, _processor);
                        break;
                    }
                case Constants.CONTENT_CURATOR_ROLE:
                    {
                        ProgramHelper.RunContentCuratorPath(_processor);
                        break;
                    }
                case Constants.READER_ROLE:
                    {
                        ProgramHelper.GetUserInputWithFilter(_processor);
                        break;
                    }
                case Constants.USER_ROLE:
                    {
                        ProgramHelper.GetUserInputWithoutFilter(_processor);
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"Incorrect value. Please enter valid value for your role. {Constants.ADMIN_ROLE} for admin, {Constants.CONTENT_CURATOR_ROLE} for content curator, {Constants.READER_ROLE} for reader role or {Constants.USER_ROLE} for user.");
                        break;
                    }
            }


        }
    }
}

