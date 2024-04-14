using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Presenters;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// 台所のレコードのView
    /// </summary>
    public class DiningRecordGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private DiningRecordGimmickPresenter _presenter;

        /// <summary>
        /// 音楽ファイルのid
        /// </summary>
        [SerializeField] private int _bgmId;
        
        /// <summary>
        /// ボタン効果音のid
        /// </summary>
        [SerializeField] private SEType _seId;

        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new DiningRecordGimmickPresenter();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            SoundManageView soundManageView = SoundManageView.GetInstance();
            Debug.Log($"再生、停止切り替え");
            // BGMが停止している場合
            if (!SoundConfig.GetIsPlayBGM())
            {
                soundManageView.PlayBGM(_bgmId, true);
                SoundConfig.SetIsPlayBGM(true);
            }
            // BGMが再生している場合
            else
            {
                soundManageView.PauseBGM();
                SoundConfig.SetIsPlayBGM(false);
            }
            // ボタン音
            soundManageView.PlaySE((int)_seId);
            
        }
    }
}