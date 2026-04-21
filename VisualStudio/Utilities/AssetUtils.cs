using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedTrader.Utilities
{
    internal class AssetUtils
    {

        static Dictionary<string, GameObject> cachedPrefabs = new Dictionary<string, GameObject>();

        public static GameObject GetPrefab(string prefabName)
        {
            if (!cachedPrefabs.ContainsKey(prefabName))
            {
                GeneratePrefab(prefabName);
            }
            else if (cachedPrefabs.ContainsKey(prefabName) && cachedPrefabs[prefabName] == null)
            {
                cachedPrefabs.Remove(prefabName);
                GeneratePrefab(prefabName);
            }
            return GameObject.Instantiate(cachedPrefabs[prefabName]);
        }

        private static void GeneratePrefab(string prefabName)
        {
            GameObject go = new GameObject();
            go.name = prefabName;

            MeshFilter mf = go.AddComponent<MeshFilter>();
            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            MeshCollider mc = go.AddComponent<MeshCollider>();

            switch (prefabName)
            {
                case "OBJ_TradeBoxA_Prefab":
                    mf.sharedMesh = Addressables.LoadAssetAsync<Mesh>("Assets/ArtAssets/Env/Objects/OBJ_TradeBox/OBJ_Trader_Box_LOD0.glb").WaitForCompletion();
                    mr.sharedMaterial = Addressables.LoadAssetAsync<Material>("Assets/ArtAssets/Textures/Unique/OBJ_TraderBoxA.mat").WaitForCompletion();
                    mc.sharedMesh = mf.sharedMesh;
                    break;
            }

            cachedPrefabs.Add(prefabName, go);
        }

    }
}
