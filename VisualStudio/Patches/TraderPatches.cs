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

                exchangeBoxScene = "LakeRegion"; //this is just for testing
               
            }
        }
    }
}
