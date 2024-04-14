namespace MVP.Sounds
{
    /// <summary>
    /// 音量調節モデル
    /// </summary>
    class SoundSliderModel
    {
        /// <summary>
        /// サウンド種別
        /// </summary>
        private SoundType _soundType;

        /// <summary>
        /// コンストラクタ
        /// サウンド種別を初期化
        /// </summary>
        /// <param name="soundType">サウンド種別</param>
        public SoundSliderModel(SoundType soundType)
        {
            _soundType = soundType;
        }

        /// <summary>
        /// フィールドを参照して音量設定
        /// </summary>
        /// <param name="volume">音量</param>
        public void SetVolume(float volume)
        {
            switch (_soundType)
            {
                case SoundType.BGM:
                    SoundConfig.SetVolumeBGM(volume);
                break;
                
                case SoundType.SE:
                    SoundConfig.SetVolumeSE(volume);
                break;
            }
        }

        /// <summary>
        /// フィールドを参照して音量設定
        /// </summary>
        /// <returns>音量</returns>
        public float GetVolume()
        {
            switch (_soundType)
            {
                case SoundType.BGM:
                    return SoundConfig.GetVolumeBGM();
                
                case SoundType.SE:
                    return SoundConfig.GetVolumeSE();
            }
            // おまじない
            return SoundConfig.GetVolumeBGM();
        }
    }
}