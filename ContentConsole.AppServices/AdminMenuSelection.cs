using System;
using System.Text;
using ContentConsole.AppInterfaces;

namespace ContentConsole.AppServices
{
    public class AdminMenuSelection : IAdminMenuSelection
    {
        private readonly INegativeWordStore _negativeWordStore;
        private readonly IAdminInteraction _adminInteraction;

        public AdminMenuSelection(INegativeWordStore negativeWordStore, IAdminInteraction adminInteraction)
        {
            _negativeWordStore = negativeWordStore;
            _adminInteraction = adminInteraction;
        }

        public void Execute()
        {
            var newWord = _adminInteraction.GetNewNegativeWord(_negativeWordStore.GetAll());

            _negativeWordStore.Add(newWord);

            var stringBuilder = new StringBuilder()
                .AppendLine("\nUpdated List:")
                .AppendLine(string.Join(",", _negativeWordStore.GetAll()))
                .AppendLine("-----------------------------------------------");

            Console.Write(stringBuilder.ToString());

            Console.WriteLine("\nPress ANY key to exit.");
            Console.ReadKey();
        }
    }
}