using Rocket.API;
using Rocket.Unturned.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Logger = Rocket.Core.Logging.Logger;
using Color = UnityEngine.Color;

namespace AdminToolz.Helpers
{
    public class ChatHelper
    {
        public static string Translate(string key, params object[] parameters)
        {
            string translationResult = Plugin.Instance.Translate(key, parameters);
            return translationResult == key ? $"Translation '{key}' not found!" : translationResult;
        }

        public static void SendTranslation(IRocketPlayer caller, Color color, string TranslationKey, params object[] parameters)
        {
            SendMessage(caller, Translate(TranslationKey, parameters), color);
        }

        public static void SendMessage(IRocketPlayer caller, string msg, Color? color = null)
        {
            if (caller is Console)
                Logger.LogWarning(msg);
            else
                UnturnedChat.Say(caller, msg, color ?? Color.green);
        }
    }
}
