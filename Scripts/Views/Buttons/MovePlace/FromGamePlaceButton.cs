using MVP.Sounds;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using DG.Tweening;

namespace MVP.Views
{
    /// <summary>
    /// フェードインし、効果音を再生後、シーン切り替えする機能のボタンアタッチ用
    /// </summary>
    public class FromGamePlaceButtonView: MonoBehaviour
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
        /// ロード時遷移はfalse(初期true)
        /// </summary>
        [SerializeField] private bool _isNotLoad = true;


        /// <summary>
        /// クリック時に移動
        /// </summary>
        /// <param name="sceneNumber">遷移シーン番号</param>
        public void OnClick(int sceneNumber)
        {
            FromGamePlaceView fromGamePlaceView = new FromGamePlaceView();
            fromGamePlaceView.OnClick(sceneNumber, _fadePanel, _seId, _duration, _isNotLoad);
        }
    }
}