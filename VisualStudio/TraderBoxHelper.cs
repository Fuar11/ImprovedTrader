using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Trader;

namespace ImprovedTrader
{
    internal class TraderBoxHelper
    {

        public static void InstantiateTraderBox(Vector3 position, Vector3 rotation)
        {

            Main.Logger.Log($"Creating new trader box in scene at {position.ToString()}!", FlaggedLoggingLevel.Debug);

            GameObject tradeBoxParent = new GameObject("FUAR_TradeBox");
            tradeBoxParent.layer = vp_Layer.InteractiveProp;
            tradeBoxParent.SetActive(false);

            GameObject tradeBox = AssetHelper.SafeInstantiateAssetAsync("Assets/ArtAssets/Env/Objects/OBJ_TradeBox/OBJ_TradeBoxA_Prefab.prefab").WaitForCompletion();

            if(tradeBox == null)
            {
                Main.Logger.Log("Trade box prefab is null", FlaggedLoggingLevel.Error);
                return;
            }

            tradeBox.transform.SetParent(tradeBoxParent.transform);
            tradeBox.SetActive(false);

            ExchangeBox exchange = tradeBox.AddComponent<ExchangeBox>();

            ObjectAnim oa = tradeBoxParent.AddComponent<ObjectAnim>();
            oa.Initialize(tradeBox.gameObject.transform.GetChild(2).gameObject);

            exchange.m_ObjectAnim = oa;
            exchange.m_Lock = tradeBox.gameObject.transform.GetChild(1).gameObject;
            exchange.m_DefaultHoverText = new LocalizedString() { m_LocalizationID = "GAMEPLAY_ExchangeBox" };
            exchange.m_DefaultHoldText = new LocalizedString() { m_LocalizationID = "GAMEPLAY_OpeningProgress" };
            exchange.m_LockedPostFix = new LocalizedString() { m_LocalizationID = "GAMEPLAY_LockedPostfix" };
            exchange.m_DefaultHoldTime = 0.5f;

            exchange.m_BoxLockedEvent = new() { WwiseObjectReference = new() { id = 1359875401, guid = "80CFEA83-388C-45FD-B898-8552EB3E798F", objectName = "play_Trader_Interaction_ExchangeBox_Locked" } };
            exchange.m_BoxOpenEvent = new() { WwiseObjectReference = new() { id = 1041331915, guid = "19EA54D7-E211-48C7-9D17-E39C26C6BDB0", objectName = "play_Trader_Interaction_ExchangeBox_Open" } };
            exchange.m_BoxCloseEvent = new() { WwiseObjectReference = new() { id = 4238822553, guid = "4293A7A6-54A9-4CB0-8816-3850ED5E8752", objectName = "play_Trader_Interaction_ExchangeBox_Close" } };

            Main.Logger.Log("Instantiating water supply items", FlaggedLoggingLevel.Debug);

            GearItem potableWater = GearItem.LoadGearItemPrefab("GEAR_WaterSupplyPotable");
            GearItem nonPotableWater = GearItem.LoadGearItemPrefab("GEAR_WaterSupplyNotPotable");

            if (potableWater == null || nonPotableWater == null)
            {
                Main.Logger.Log("Error getting water gear item data", FlaggedLoggingLevel.Error);
                return;
            }

            exchange.m_PotableWaterSupply = potableWater.m_GearItemData;
            exchange.m_NonPotableWaterSupply = nonPotableWater.m_GearItemData;

            Main.Logger.Log("Set water supply fields", FlaggedLoggingLevel.Debug);

            exchange.SetLocked(false); 

            exchange.enabled = true;

            tradeBoxParent.transform.position = position;
            tradeBoxParent.transform.rotation = Quaternion.Euler(rotation);
            tradeBox.SetActive(true);
            tradeBoxParent.SetActive(true);

            var tm = GameManager.m_TraderManager;
            var trade = tm.GetActiveTrade();

            if (trade != null)
            {
                Main.Logger.Log("Adding trade to custom box", FlaggedLoggingLevel.Debug);
                exchange.SetActiveTrade(trade);
            }
            else
            {
                Main.Logger.Log("No active trade found", FlaggedLoggingLevel.Error);
            }

            //SceneUtilities.InstantiateObjectInScene(tradeBox, position, rotation);
        }

        private void LoadAndPutItemsInBox()
        {

            

        }

        public static ExchangeBox GetTraderBox()
        {

            return null;

        }

    

    }
}
