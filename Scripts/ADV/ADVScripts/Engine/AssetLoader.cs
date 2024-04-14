using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;
using System;

namespace HarapekoADV
{
    /// <summary>
    /// 指定されたデータをロードして取得するクラス
    /// </summary>
    public class AssetLoader
    {
        /// <summary>
        /// ResourcesからGameObjectをロードする
        /// </summary>
        /// <param name="adress">パス</param>
        /// <returns>GameObject</returns>
        public static GameObject Load(string adress)
        {
            GameObject obj = Resources.Load<GameObject>(adress);
            return obj;
        }
        
        /// <summary>
        /// Resourcesから特定クラスのGameObjectをロードする
        /// </summary>
        /// <param name="adress">パス</param>
        /// <typeparam name="T">ジェネリクス</typeparam>
        /// <returns>GameObject</returns>
        public static T Load<T>(string adress)
        {
            GameObject obj = Resources.Load<GameObject>(adress);
            T component = obj.GetComponent<T>();
            return component;
        }

        /// <summary>
        /// 事前にセットしたパスのデータをロードする
        /// </summary>
        /// <typeparam name="T">ジェネリクス</typeparam>
        /// <param name="address">パス</param>
        /// <returns>GameObject</returns>
        public static async Task<T> LoadAsync<T>(string address)
        {
            var asyncOperationHandle = Addressables.LoadAssetAsync<T>(address);
            await asyncOperationHandle.Task;
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                return asyncOperationHandle.Result;
            }
            else
            {
                // エラー処理などが必要な場合はここに記述
                throw new Exception($"Failed to load asset: {address}");
            }
        }
    }
}
