#region System Directives
global using System;
global using System.Text;
global using System.Text.RegularExpressions;
#endregion
#region Il2Cpp Directives
global using Il2CppInterop.Runtime;
global using Il2CppTLD.Gear;
global using AssetHelper = Il2CppTLD.AddressableAssets.AssetHelper;
#endregion
#region Unity Directives
global using UnityEngine.AddressableAssets;
#endregion
#region Mod Directives
global using ImprovedTrader.Utilities;
global using ImprovedTrader.Utilities.Enums;
global using ImprovedTrader.Utilities.Exceptions;
global using ImprovedTrader.Utilities.JSON;
global using ComplexLogger;
#endregion

namespace ImprovedTrader
{

    /// <inheritdoc/>
	public class Main : MelonMod
	{
        /// <summary>
        /// 
        /// </summary>
        public static ComplexLogger<Main> Logger = new();

        /// <inheritdoc/>
        public override void OnInitializeMelon()
        {
            Logger.Log("Improved Trader is online.", FlaggedLoggingLevel.Always);
            Settings.OnLoad();
        }

        // used to do things when a scene is Initialized. This is what you want to use under normal circumstances
        /// <inheritdoc/>
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
          

            switch (sceneName)
            {
                case "RavineTransitionZone":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(-826.08f, 133.77f, -113.76f), Vector3.zero); //train derailment
                    break;
                case "RuralRegion":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(1444.60f, 87.42f, 2674.24f), Vector3.zero); //derelict cabins
                    break;
                case "LongRailTransitionZone":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(96.91f, 0.99f, 594.28f), Vector3.zero); //train cars
                    break;
                case "MarshRegion":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(397.38f, -132.04f, 846.84f), Vector3.zero); //side of tracks
                    break;
                case "CanneryRegion":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(54.49f, 82.14f, -922.86f), Vector3.zero); //lighthouse
                    break;
                case "CanyonRoadTransitionZone":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(316.75f, 71.31f, 385.94f), Vector3.zero); //scenic view
                    break;
            }
        }

        // Triggered when the scene has finished loading
        /// <inheritdoc/>
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {

          
        }

        // triggered when scenes are unloaded
        /// <inheritdoc/>
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasUnloaded(buildIndex, sceneName);
        }

        // Use this to do things on update instead of patching GameManger.Update();
        /// <inheritdoc/>
        public override void OnLateUpdate()
        {
            base.OnLateUpdate();
        }
    }
}
