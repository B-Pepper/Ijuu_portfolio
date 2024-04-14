using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// トイレギミックのView
    /// </summary>
    public class ToiletGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private ToiletGimmickPresenter _presenter;

        /// <summary>
        /// 画像を変更する処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// 変更先の画像
        /// </summary>
        [SerializeField] private Image toiletDoorImage;

        /// <summary>
        /// 背景の画像
        /// </summary>
        [SerializeField] private Image toiletBackGroundImage;
        
        /// <summary>
        /// 変更する画像のパス
        /// </summary>
        [SerializeField] private string changeImagePath;

        /// <summary>
        /// 背景用の画像パス
        /// </summary>
        [SerializeField] private string changeBackGroundImagePath;

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


        void Awake()
        {
            _presenter = new ToiletGimmickPresenter();
            _changeImageView = new ChangeImageView();
            if (_presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_UNLOCK)
            {
                _ChangeImages();
            }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick(int sceneNumber)
        {
            // ドライバーが選択状態であるか
            if(Config.GetItemStatus(ItemConstant.ITEM_DRIVER_ID) == ItemConstant.ITEM_HAVE 
            && _presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_LOCK)
            {
                // ギミックステータスのステータスを設定
                _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
                // 正解のSE
                SoundManageView.GetInstance().PlaySE((int)_seId);
                _ChangeImages();
                return;
            }

            // ギミック解除後、シーン遷移処理
            if (_presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_UNLOCK)
            {
                // シーン遷移処理
                FromGamePlaceView fromGamePlaceView = new FromGamePlaceView();
                fromGamePlaceView.OnClick(sceneNumber, _fadePanel, _seId, _duration);
            }
        }

        /// <summary>
        /// 各画像変更
        /// </summary>
        private void _ChangeImages()
        {
            // 倉庫への扉が開く処理
            _changeImageView.ChangeImage(toiletDoorImage, changeImagePath);
            // 倉庫全体の背景を変更する
            _changeImageView.ChangeImage(toiletBackGroundImage, changeBackGroundImagePath);
        }
    }
}