using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// トイレギミックのView
    /// </summary>
    public class SyosaiGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private SyosaiGimmickPresenter _presenter;

        /// <summary>
        /// 画像を変更する処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// 背景の画像
        /// </summary>
        [SerializeField] private Image _backGroundImage;

        /// <summary>
        /// 背景用の画像パス
        /// </summary>
        [SerializeField] private string _changeBackGroundImagePath;

        /// <summary>
        /// ギミック制御対象アイテム
        /// </summary>
        [SerializeField] private GameObject _scissorsItem;

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
            _presenter = new SyosaiGimmickPresenter();
            _changeImageView = new ChangeImageView();
            // ギミック解除されているとき、画像を更新しておく
            if (_presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_UNLOCK)
            {
                _changeImageView.ChangeImage(_backGroundImage, _changeBackGroundImagePath);
                _scissorsItem.SetActive(true);
            }
            if (Config.GetItemStatus(ItemConstant.ITEM_SCISSORS_ID) > ItemConstant.ITEM_DEFAULT)
            {
                _scissorsItem.SetActive(false);
            }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // ドライバーが選択状態であるか
            if(Config.GetItemStatus(ItemConstant.ITEM_DRIVER_ID) == ItemConstant.ITEM_HAVE 
            && _presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_LOCK)
            {
                // ギミックステータスのステータスを設定
                _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
                // 正解のSE
                SoundManageView.GetInstance().PlaySE((int)_seId);
                // 倉庫全体の背景を変更する
                _changeImageView.ChangeImage(_backGroundImage, _changeBackGroundImagePath);
                _scissorsItem.SetActive(true);
            }
        }
    }
}