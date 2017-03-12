using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.Unturned.Player;

using Logger = Rocket.Core.Logging.Logger;
using AdminToolz.Helpers;
using UnityEngine;
using SDG.Unturned;
using AdminToolz.DataStorage;

namespace AdminToolz.Commands
{
    class CommandHolding : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "holding";

        public string Help => "Gets info on a players held item";

        public string Syntax => "(player)";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            bool console = caller is ConsolePlayer;
            UnturnedPlayer target;
            ItemStats iData;

            // Command was called from console
            if (console)
            {
                if (command.Length != 1)
                {
                    ChatHelper.SendTranslation(caller, Color.red, "command_holding_help");
                    return;
                }

                return;
            }

            if (command.Length == 0) // Command in targeting the caller
            {
                target = (UnturnedPlayer)caller;
                iData = ItemHelper.GetItemStatsFromItem(target.Player.equipment.asset);

                if (itemIsNull(true)) return;
            }
            else if (command.Length == 1) // target is another player
            {

            }
            else // Invalid parameters, send help msg
            {
                ChatHelper.SendTranslation(caller, Color.red, "command_holding_help");
            }

            // locale function to simplify things
            bool itemIsNull(bool self)
            {
                if (iData.itemName == "NULL")
                {
                    if (self)
                    {
                        ChatHelper.SendTranslation(caller, Color.red, "no_held_item_self");
                    }
                    else
                    {
                        ChatHelper.SendTranslation(caller, Color.red, "no_held_item_other");
                    }
                    return true;
                }
                return false;
            }
        }

        //void itemIsNull(ItemStats iData, IRocketPlayer caller)
        //{
        //    if (iData.itemName == "NULL")
        //    {
        //        ChatHelper.SendTranslation(caller, Color.red, "");
        //        return;
        //    }
        //}
    }
}
