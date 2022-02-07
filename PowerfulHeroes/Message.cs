using TaleWorlds.Core;
using TaleWorlds.Library;

namespace PowerfulHeroes
{
    public static class Message
    {
        public static bool ShowDebug = false;

        private static void ShowMessage(string message, Color messageColor)
        {
            InformationManager.DisplayMessage(new InformationMessage($"{Statics.DisplayName} : {message}", messageColor));
        }

        public static void Info(string message)
        {
            ShowMessage(message, Color.ConvertStringToColor("#42FF00FF"));
        }

        public static void Error(string message)
        {
            ShowMessage(message, Color.ConvertStringToColor("#FF000000"));
        }

        public static void DisplayModLoadedMessage()
        {
            if (ShowDebug)
            {
                Info("Loaded");
            }
        }

        public static void Debug(string message)
        {
            if (ShowDebug)
            {
                ShowMessage(message, Color.ConvertStringToColor("#E6FF00FF"));
            }
        }
    }
}
