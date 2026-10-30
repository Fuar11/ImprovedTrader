using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Interactions;
using Il2CppTLD.Trader;

namespace ImprovedTrader.Patches
{
    internal class TraderPatches
    {

        [HarmonyPatch(typeof(TraderManager), nameof(TraderManager.IsTraderAvailable))]

        public class TraderAvailabilityOverride()
        {

            public static void Postfix(ref bool __result)
            {
                var availableDays = Settings.Instance.traderAvailableDays * 24f;

                __result = GameManager.GetTimeOfDayComponent().GetHoursPlayedNotPaused() >= availableDays;
            }

        }

        [HarmonyPatch(typeof(TraderManager), nameof(TraderManager.InitiateTrade))]

        public class DeserializeTest
        {

            public static void Prefix(ref List<TradeExchangeData> exchanges, ref string exchangeBoxScene)
            {

                string currentScene = GameManager.m_ActiveScene;

                switch (currentScene)
                {
                    case "CampOffice": 
                        exchangeBoxScene = "RavineTransitionZone";
                        break;
                    case "CommunityHallA": 
                        exchangeBoxScene = "RuralRegion";
                        break;
                    case "CanneryTrailerA":
                        exchangeBoxScene = "CanneryRegion";
                        break;
                    case "AirfieldRegion":
                        exchangeBoxScene = "LongRailTransitionZone";
                        break;
                    case "HubRegion":
                        exchangeBoxScene = "LongRailTransitionZone";
                        break;
                    case "MiningRegion":
                        exchangeBoxScene = "LongRailTransitionZone";
                        break;
                    case "TracksRegion":
                        exchangeBoxScene = "MarshRegion";
                        break;
                    case "PostOfficeA":
                        exchangeBoxScene = "MountainTownRegion";
                        break;
                    case "BlackrockPrisonSurvivalZone":
                        exchangeBoxScene = "BlackrockRegion";
                        break;
                }
            }
        }
    }
}
