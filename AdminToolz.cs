using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Core.Plugins;

using Logger = Rocket.Core.Logging.Logger;

namespace AdminToolz
{
    public class AdminToolz : RocketPlugin<Config>
    {
        protected override void Load()
        {
            Logger.Log("AdminToolz has Loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("AdminToolz has Unloaded!");
        }
    }
}
