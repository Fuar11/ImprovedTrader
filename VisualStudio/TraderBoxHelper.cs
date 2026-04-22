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

            Main.Logger.Log("Creating new trader box in scene!", FlaggedLoggingLevel.Debug);

            position = new Vector3(797.69f, 36.97f, 32.98f);
            rotation = new Vector3(0f, 0f, 0f);

            GameObject tradeBox = AssetHelper.SafeInstantiateAssetAsync("Assets/ArtAssets/Env/Objects/OBJ_TradeBox/OBJ_TradeBoxA_Prefab.prefab").WaitForCompletion();
       
            if(tradeBox == null)
            {
                Main.Logger.Log("Trade box prefab is null", FlaggedLoggingLevel.Error);
                return;
            }

            tradeBox.SetActive(false);

            ExchangeBox exchange = tradeBox.AddComponent<ExchangeBox>();

            ObjectAnim oa = tradeBox.AddComponent<ObjectAnim>();
            oa.Initialize(tradeBox.gameObject.transform.GetChild(2).gameObject);

            exchange.m_ObjectAnim = oa;
            exchange.m_Lock = tradeBox.gameObject.transform.GetChild(1).gameObject;
            exchange.enabled = true;
            exchange.m_DefaultHoverText = new LocalizedString() { m_LocalizationID = "GAMEPLAY_ExchangeBox" };
            exchange.m_DefaultHoldText = new LocalizedString() { m_LocalizationID = "GAMEPLAY_OpeningProgress" };
            exchange.m_LockedPostFix = new LocalizedString() { m_LocalizationID = "GAMEPLAY_LockedPostfix" };
            exchange.m_DefaultHoldTime = 0.5f;

           /** WwiseObjectReference lockedEventRef = new WwiseObjectReference()
            {
                id = 1359875401,
                guid = "80CFEA83-388C-45FD-B898-8552EB3E798F"
            };      
            Il2CppAK.Wwise.Event lockedEvent = new Il2CppAK.Wwise.Event();
            lockedEvent.ObjectReference = lockedEventRef;

            exchange.m_BoxLockedEvent = lockedEvent; **/

            tradeBox.transform.position = position;
            tradeBox.transform.rotation = Quaternion.Euler(rotation);
            tradeBox.SetActive(true);

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
