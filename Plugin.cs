using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Core.Plugins;
using Rocket.API.Collections;
using AdminToolz.Helpers;

using Logger = Rocket.Core.Logging.Logger;
using Dir = System.IO.Directory;

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
            {"command_holding_help", "Invalid Parameter: /holding (player)"},
            {"no_held_item_self", "You are not holding a item!"},
            {"no_held_item_other", "Target player is not holding a item!"},
            {"holding_admin_msg", "{0} is holding: '{1}:{2}' {3}"},
            {"holding_self_msg", "you are holding: '{0}:{1}' {2}"},
            {"noplayer", "Could not find any players"}
        };
    }
}
