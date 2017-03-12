using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Core.Plugins;

using Logger = Rocket.Core.Logging.Logger;
using Rocket.API.Collections;

namespace AdminToolz
{
    public class Plugin : RocketPlugin<Config>
    {
        public static Plugin Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("AdminToolz has Loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("AdminToolz has Unloaded!");
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            {"command_holding_help", "Invalid Parameter: /holding (player)"}
        };
    }
}
