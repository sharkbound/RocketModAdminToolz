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

            if (!console && command.Length == 0) // Command is targeting the caller
            {
                target = (UnturnedPlayer)caller;
                iData = ItemHelper.GetItemStatsFromAsset(target.Player.equipment.asset);

                if (itemIsNull(true)) return;
                ChatHelper.SendTranslation(caller, Color.green, "holding_self_msg", iData.id, iData.itemName, iData.desc);
            }
            else if (command.Length == 1) // target is another player
            {
                if (!validateOtherPlayerAndItem(caller, command[0], out iData, out target))
                    return;

                ChatHelper.SendTranslation(caller, Color.green, "holding_admin_msg", target.DisplayName, iData.id.ToString(), iData.itemName, iData.desc);
                return;
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
                        ChatHelper.SendTranslation(caller, Color.red, "no_held_item_self");
                    else
                        ChatHelper.SendTranslation(caller, Color.red, "no_held_item_other");
                    return true;
                }
                return false;
            }
        }

        bool validateOtherPlayerAndItem(IRocketPlayer caller, string playername, out ItemStats i, out UnturnedPlayer p)
        {
            p = PlayerHelper.GetPlayer(playername);
            i = default(ItemStats);

            if (p == null)
            {
                ChatHelper.SendTranslation(caller, Color.red, "noplayer");
                return false;
            }

            i = ItemHelper.GetItemStatsFromAsset(p.Player.equipment.asset);
            if (i.itemName == "NULL")
            {
                ChatHelper.SendTranslation(caller, Color.red, "no_held_item_other");
                return false;
            }
            return true;
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
