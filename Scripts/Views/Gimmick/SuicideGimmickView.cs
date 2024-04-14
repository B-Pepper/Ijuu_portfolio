using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Views;
using HarapekoADV;

namespace MVP.Views
{
    /// <summary>
    /// ダイナマイトを着火して自殺エンド遷移ギミックのView
    /// </summary>
    public class SuicideGimmickView : MonoBehaviour
    {
        /// <summary>
        /// コンロの状態を取得するためのインスタンス
        /// </summary>
        [SerializeField] private ChangeStoveStatusView _changeStoveStatusView;

        /// <summary>
        /// シーン遷移用
        /// </summary>
        private FromGamePlaceView _fromGamePlaceView;

        /// <summary>
        /// フェードパネル
        /// </summary>
        [SerializeField] private GameObject _fadePanel;

        private const int _advSceneNum = 11;

        // Start is called before the first frame update
        void Awake()
        {
            _fromGamePlaceView = new FromGamePlaceView();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // ダイナマイトが選択状態であるか
            // コンロが着火状態であるか
            if (Config.GetItemStatus(ItemConstant.ITEM_DYNAMITE_ID) == ItemConstant.ITEM_HAVE
            && _changeStoveStatusView.GetStatus())
            {
                // ダイナマイト消費
                Config.SetItemStatus(ItemConstant.ITEM_DYNAMITE_ID, ItemConstant.ITEM_CONSUME);
                // エンド遷移
                ADVConfig.SetScenarioName(EndTextType.BombKitchenEndText);
                // TODO: エンドシーンフラグ更新
                _fromGamePlaceView.OnClick(_advSceneNum, _fadePanel, Sounds.SEType.None, 2.0f);

            }
        }
    }
}