using UnityEngine;

namespace HarapekoADV
{
    /// <summary>
    /// ログを表示するクラス
    /// </summary>
    public class Debugger
    {
        /// <summary>
        /// ログ出力
        /// </summary>
        ///<param name="msg">メッセージ</param>
        public static void Log(string msg)
        {
            Debug.Log("ADV: " + msg);
        }

        /// <summary>
        /// エラー出力
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public static void Err(string msg)
        {
            Debug.LogError("[ADV_ERROR] : " + msg);
        }

    }
}