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

            ExchangeBox exchange = tradeBox.AddComponent<ExchangeBox>();

            ObjectAnim oa = tradeBox.AddComponent<ObjectAnim>();
            oa.Initialize(tradeBox);

            exchange.m_ObjectAnim = oa;
            exchange.m_Lock = tradeBox.gameObject.transform.GetChild(1).gameObject;
            exchange.m_Lock.SetActive(true);
            exchange.enabled = true;

            SceneUtilities.InstantiateObjectInScene(tradeBox, position, rotation);
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
