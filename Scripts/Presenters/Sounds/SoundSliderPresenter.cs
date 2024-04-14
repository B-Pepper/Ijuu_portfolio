namespace MVP.Sounds
{
    /// <summary>
    /// 音量調節プレゼンタ
    /// </summary>
    class SoundSliderPresenter
    {
        /// <summary>
        /// model
        /// </summary>
        private SoundSliderModel _model;

        public SoundSliderPresenter(SoundType soundType)
        {
            _model = new SoundSliderModel(soundType);
        }

        /// <summary>
        /// MODELサウンド種別フィールド考慮し、
        /// 音量を取得
        /// </summary>
        /// <returns>音量</returns>
        public float GetVolume()
        {
            return _model.GetVolume();
        }

        /// <summary>
        /// MODELサウンド種別フィールド考慮し、
        /// 音量を設定
        /// </summary>
        /// <param name="volume">設定する音量</param>
        public void SetVolume(float volume)
        {
            _model.SetVolume(volume);
        }
    }
}