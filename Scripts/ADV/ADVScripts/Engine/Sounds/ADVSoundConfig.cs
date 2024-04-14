using System.Collections.Generic;
using HarapekoADV.Scenarios;
using HarapekoADV.Commands;

namespace HarapekoADV.Sounds {
    /// <summary>
    /// サウンド管理モジュール用の変数管理クラス
    /// </summary>
    public static class ADVSoundConfig {
        /// <summary>
        /// BGM音量
        /// </summary>
        private static float VOLUME_BGM = 0.2f;
        /// <summary>
        /// SE音量
        /// </summary>
        private static float VOLUME_SE = 0.2f;
        /// <summary>
        /// BGMループ設定
        /// </summary>
        private static bool IS_BGM_LOOP = true;


        /// <summary>
        /// ADVのBGM音量を設定
        /// </summary>
        /// <param name="volume"></param>
        public static void SetVolumeBGM(float volume)
        {
            VOLUME_BGM = volume;
        }
        
        /// <summary>
        /// ADVのSE音量を設定
        /// </summary>
        /// <param name="volume"></param>
        public static void SetVolumeSE(float volume)
        {
            VOLUME_SE = volume;
        }

        /// <summary>
        /// BGMをループさせるかフラグ設定
        /// </summary>
        /// <param name="isBGMLoop">ループさせる:true,させない:false</param>
        public static void SetIsBGMLoop(bool isBGMLoop)
        {
            IS_BGM_LOOP = isBGMLoop;
        }

        /// <summary>
        /// BGM音量の取得
        /// </summary>
        /// <returns>BGM音量</returns>
        public static float GetVolumeBGM()
        {
            return VOLUME_BGM;
        }

        /// <summary>
        /// SE音量の取得
        /// </summary>
        /// <returns>BGM音量</returns>
        public static float GetVolumeSE()
        {
            return VOLUME_SE;
        }

        /// <summary>
        /// BGMループが有効か取得する
        /// </summary>
        /// <returns>BGMループ設定</returns>
        public static bool GetIsBGMLoop()
        {
            return IS_BGM_LOOP;
        }
    }
}