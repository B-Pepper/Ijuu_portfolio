using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Views;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// 玄関ギミックを実行可能にするギミックのView
    /// </summary>
    public class TapeGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private TapeGimmickPresenter _presenter;

        /// <summary>
        /// 画像を変更する処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// 変更先の画像
        /// </summary>
        [SerializeField] private Image _defaultImage;

        /// <summary>
        /// 変更する玄関画像のパス
        /// </summary>
        [SerializeField] private string _defaultImagePath;
        
        /// <summary>
        /// 変更先の拡大画像
        /// </summary>
        [SerializeField] private Image _zoomImage;

        /// <summary>
        /// 変更する拡大画像のパス
        /// </summary>
        [SerializeField] private string _zoomImagePath;

        /// <summary>
        /// Solve時にSE再生するためのID
        /// </summary>
        [SerializeField] private SEType _seId = SEType.None;


        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new TapeGimmickPresenter();
            _changeImageView = new ChangeImageView();

            if(Config.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_UNLOCK)
            {
                ChangeImages();
            }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // ビニールテープが選択状態であるか
            if(Config.GetItemStatus(ItemConstant.ITEM_TAPE_ID) == ItemConstant.ITEM_HAVE &&
            Config.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_LOCK)
            {
                HandleSolve();
            }
        }

        /// <summary>
        /// 玄関背景・拡大状態の背景変更
        /// </summary>
        public void ChangeImages()
        {
            _changeImageView.ChangeImage(_defaultImage, _defaultImagePath);
            _changeImageView.ChangeImage(_zoomImage, _zoomImagePath);
        }

        /// <summary>
        /// ギミック解決時の動作
        /// </summary>
        public void HandleSolve()
        {
            _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
            SoundManageView.GetInstance().PlaySE((int)_seId);
            ChangeImages();
        }
    }
}
