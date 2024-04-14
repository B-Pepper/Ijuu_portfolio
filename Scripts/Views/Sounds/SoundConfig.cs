
namespace MVP.Sounds {
    /// <summary>
    /// サウンド管理モジュール用の変数管理クラス
    /// </summary>
    public static class SoundConfig {
        /// <summary>
        /// BGM音量
        /// </summary>
        private static float VOLUME_BGM = 0.5f;
        /// <summary>
        /// SE音量
        /// </summary>
        private static float VOLUME_SE = 0.5f;
        /// <summary>
        /// ゲームに使うBGM音量
        /// </summary>
        private static float VOLUME_USE_BGM = 1.0f;
        /// <summary>
        /// ゲームに使うSE音量
        /// </summary>
        private static float VOLUME_USE_SE = 1.0f;
        /// <summary>
        /// ゲームに使うSE音量
        /// </summary>
        private static float VOLUME_RATE = 1.0f;

        /// <summary>
        /// BGMを再生しているかどうか
        /// </summary>
        private static bool _isPlayBGM = true;

        /// <summary>
        /// コンフィグ内BGM音量を設定
        /// </summary>
        /// <param name="volume">コンフィグ設定用音量</param>
        public static void SetVolumeBGM(float volume)
        {
            VOLUME_BGM = volume;
        }

        /// <summary>
        /// コンフィグ内SE音量を設定
        /// </summary>
        /// <param name="volume">コンフィグ設定用音量</param>
        public static void SetVolumeSE(float volume)
        {
            VOLUME_SE = volume;
        }

        /// <summary>
        /// ゲームに反映するBGM音量を設定
        /// </summary>
        /// <param name="volume">ゲーム内反映用音量</param>
        public static void SetVolumeUseBGM(float volume)
        {
            VOLUME_USE_BGM = volume;
        }

        /// <summary>
        /// ゲームに反映するSE音量を設定
        /// </summary>
        /// <param name="volume">ゲーム内反映用音量</param>
        public static void SetVolumeUseSE(float volume)
        {
            VOLUME_USE_SE = volume;
        }

        /// <summary>
        /// ゲーム音量率の設定
        /// </summary>
        public static void SetVolumeRate(float volumeRate)
        {
            VOLUME_RATE = volumeRate;
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
        /// <returns>SE音量</returns>
        public static float GetVolumeSE()
        {
            return VOLUME_SE;
        }

        /// <summary>
        /// BGM音量の取得
        /// </summary>
        /// <returns>BGM音量</returns>
        public static float GetUseVolumeBGM()
        {
            return VOLUME_USE_BGM;
        }

        /// <summary>
        /// SE音量の取得
        /// </summary>
        /// <returns>SE音量</returns>
        public static float GetUseVolumeSE()
        {
            return VOLUME_USE_SE;
        }

        /// <summary>
        /// ゲーム音量率の取得
        /// </summary>
        /// <returns>ゲーム音量率</returns>
        public static float GetVolumeRate()
        {
            return VOLUME_RATE;
        }

        /// <summary>
        /// BGM再生中のフラグを取得
        /// </summary>
        /// <returns>再生中かのフラグ値</returns>
        public static bool GetIsPlayBGM()
        {
            return _isPlayBGM;
        }

        /// <summary>
        /// BGM再生中のフラグを設定
        /// </summary>
        /// <param name="isPlay">フラグ値</param>
        public static void SetIsPlayBGM(bool isPlay)
        {
            _isPlayBGM = isPlay;
        }
    }
}