using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Sounds;
using HarapekoADV;

namespace MVP.Views
{
    /// <summary>
    /// 倉庫のボタンView
    /// </summary>
    public class SoukoDoorButtonView : MonoBehaviour
    {
        /// <summary>
        /// エンディング遷移用のシーン番号
        /// </summary>
        private int _advSceneNumber = 11;

        /// <summary>
        /// フェード用パネル
        /// </summary>
        [SerializeField] private GameObject _fadePanel;

        /// <summary>
        /// フェード時間
        /// </summary>
        [SerializeField] private float _duration = 0.5f;

        /// <summary>
        /// エンド遷移時の効果音
        /// </summary>
        [SerializeField] private SEType _seId = SEType.None;

        /// <summary>
        /// 起動するたびに数字と画像は初期化
        /// </summary>
        private void Awake()
        {
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="button">buttonの種類</param>
        public void OnClick()
        {
            if (Config.GetGimmickStatus(GimmickConstant.GIMMICK_SOUKO_DOOR_ID) == GimmickConstant.GIMMICK_UNLOCK)
            {
                SoundManageView.GetInstance().PlaySE((int)SEType.Gacha);
                _HandleEnd();
            }
            else
            {
                SoundManageView.GetInstance().PlaySE((int)SEType.GachaGacha);
            }
        }

        /// <summary>
        /// 倉庫からのエンド遷移
        /// </summary>
        private void _HandleEnd()
        {
            ADVConfig.SetScenarioName(EndTextType.NormalSoukoEndText);
            if (Config.GetItemStatus(ItemConstant.ITEM_MEDICINE_ID) > ItemConstant.ITEM_DEFAULT)
            {
                ADVConfig.SetScenarioName(EndTextType.TrueEndText);
            }
            FromGamePlaceView fromGamePlaceView = new FromGamePlaceView();
            fromGamePlaceView.OnClick(_advSceneNumber, _fadePanel, _seId, _duration);
            
        }
    }
}