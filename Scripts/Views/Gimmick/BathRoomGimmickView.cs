using UnityEngine;
using MVP.Sounds;
using HarapekoADV;

namespace MVP.Views
{
    /// <summary>
    /// 風呂場ギミックのView
    /// </summary>
    public class BathRoomGimmickView : MonoBehaviour
    {
        /// <summary>
        /// フェード対象パネル
        /// </summary>
        [SerializeField] private GameObject _fadePanel;

        /// <summary>
        /// 効果音の種類
        /// </summary>
        [SerializeField] private SEType _seId = SEType.None;

        /// <summary>
        /// エフェクト時間
        /// </summary>
        [SerializeField] private float _duration = 0.5f;


        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick(int sceneNumber)
        {
            // ドライバーが選択状態であるか
            if (Config.GetItemStatus(ItemConstant.ITEM_TESTDRUG_ID) == ItemConstant.ITEM_HAVE)
            {
                // シーン遷移処理
                ADVConfig.SetScenarioName(EndTextType.SuicideEndText);
                FromGamePlaceView fromGamePlaceView = new FromGamePlaceView();
                fromGamePlaceView.OnClick(sceneNumber, _fadePanel, _seId, _duration);
            }
        }
    }

}