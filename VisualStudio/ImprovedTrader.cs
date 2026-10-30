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
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(-615.77f, 133.84f, -87.91f), Vector3.zero); //train derailment
                    break;
                case "RuralRegion":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(1820.45f, 92.62f, 2746.90f), new Vector3(0f, 120f, 0f)); //near end of the road
                    break;
                case "LongRailTransitionZone":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(96.91f, 0.99f, 594.28f), new Vector3(0f, 178f, 0f)); //train cars
                    break;
                case "MarshRegion":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(434.9f, -133.25f, 861.03f), new Vector3(0f, 260f, 0f)); //side of tracks
                    break;
                case "MountainTownRegion":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(969.44f, 303.97f, 1236.08f), new Vector3(0f, 150f, 0f)); //side of tracks
                    break;
                case "CanneryRegion":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(54.49f, 82.14f, -922.86f), new Vector3(0f, 180f, 0f)); //lighthouse
                    break;
                case "BlackrockRegion":
                    TraderBoxHelper.InstantiateTraderBox(new Vector3(-309.76f, 128.20f, -794.32f), new Vector3(0f, 50.71f, 0f)); //bridge truck
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
