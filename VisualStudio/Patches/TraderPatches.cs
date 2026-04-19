using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2Cpp;
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

                Main.Logger.Log("Postfix calling", FlaggedLoggingLevel.Debug);

                var availableDays = Settings.Instance.traderAvailableDays * 24f;

                __result = GameManager.GetTimeOfDayComponent().GetHoursPlayedNotPaused() >= availableDays;
            }

        }

    }
}
