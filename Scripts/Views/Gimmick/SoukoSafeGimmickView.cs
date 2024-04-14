using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// 倉庫金庫ギミックのView
    /// </summary>
    public class SoukoSafeGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private SoukoSafeGimmickPresenter _presenter;

        /// <summary>
        /// 画像を変更する処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        [SerializeField] private GameObject _medicineItem;

        /// <summary>
        /// 変更先の画像
        /// </summary>
        [SerializeField] private Image originalImage;

        /// <summary>
        /// 変更先の背景画像
        /// </summary>
        [SerializeField] private Image originalBackGroundImage;

        /// <summary>
        /// 変更する画像のパス
        /// </summary>
        [SerializeField] private string changeImagePath;
        
        /// <summary>
        /// 変更する背景画像のパス
        /// </summary>
        [SerializeField] private string changeBackGroundImagePath;


        void Awake()
        {
            _presenter = new SoukoSafeGimmickPresenter();
            _changeImageView = new ChangeImageView();
            if (_presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_UNLOCK)
            {
                _ChangeUnlockImage();
            }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // ビニールテープが選択状態であるか
            if (Config.GetItemStatus(ItemConstant.ITEM_KEYINICE_ID) == ItemConstant.ITEM_HAVE
            && _presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_LOCK)
            {
                // ギミックステータスのステータスを設定
                _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
                // 正解のSE
                SoundManageView.GetInstance().PlaySE((int)SEType.Lock);
                // 画像切り替え
                _ChangeUnlockImage();
                _medicineItem.SetActive(true);
            }
        }

        /// <summary>
        /// アンロック画像変更
        /// </summary>
        private void _ChangeUnlockImage()
        {
            // 扉が開く画像に変更
            _changeImageView.ChangeImage(originalImage, changeImagePath);

            // 扉が開いている状態の倉庫の背景画像に変更
            _changeImageView.ChangeImage(originalBackGroundImage, changeBackGroundImagePath);
        }
    }
}