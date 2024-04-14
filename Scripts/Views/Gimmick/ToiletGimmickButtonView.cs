using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// トイレギミックのボタンアタッチ用View
    /// </summary>
    public class ToiletGimmickButtonView : MonoBehaviour
    {
        /// <summary>
        /// Gimmick操作用のシリアライズ
        /// </summary>
        [SerializeField] private ToiletGimmickView _toiletGimmickView;

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick(int sceneNumber)
        {
            _toiletGimmickView.OnClick(sceneNumber);
        }
    }
}