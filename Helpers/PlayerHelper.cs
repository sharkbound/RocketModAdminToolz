using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminToolz.Helpers
{
    public class PlayerHelper
    {
        public static UnturnedPlayer GetPlayer(string searchStr)
        {
            UnturnedPlayer tempP;
            UnturnedPlayer player = null;
            ulong SteamID = 0;
            bool SteamIDMode = ulong.TryParse(searchStr, out SteamID);

            foreach (SteamPlayer sp in Provider.clients)
            {
                try
                {
                    tempP = UnturnedPlayer.FromSteamPlayer(sp);
                    if (SteamIDMode)
                    {
                        if (tempP.CSteamID.m_SteamID == SteamID)
                        {
                            player = tempP;
                            break;
                        }
                    }
                    else
                    {
                        if (tempP.DisplayName.ToLower().Contains(searchStr.ToLower()))
                        {
                            player = tempP;
                            break;
                        }
                        else if (tempP.SteamName.ToLower().Contains(searchStr.ToLower()))
                        {
                            player = tempP;
                            break;
                        }
                        else if (tempP.CharacterName.ToLower().Contains(searchStr.ToLower()))
                        {
                            player = tempP;
                            break;
                        }
                    }
                }
                catch { }
            }

            return player;
        }
    }
}
