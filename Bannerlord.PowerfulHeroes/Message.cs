using TaleWorlds.Library;

namespace Bannerlord.PowerfulHeroes
{
    public static class Message
    {
        private static void ShowMessage(string message, Color messageColor)
        {
            InformationManager.DisplayMessage(new InformationMessage($"{Statics.DisplayName} : {message}", messageColor));
        }

        public static void Error(string message)
        {
            ShowMessage(message, Color.ConvertStringToColor("#FF000000"));
        }

        public static void Info(string message)
        {
            if (Settings.Instance!.Debug)
            {
                ShowMessage(message, Color.ConvertStringToColor("#42FF00FF"));
            }
        }

        public static void Debug(string message)
        {
            if (Settings.Instance!.Debug)
            {
                ShowMessage(message, Color.ConvertStringToColor("#E6FF00FF"));
            }
        }
    }
}
