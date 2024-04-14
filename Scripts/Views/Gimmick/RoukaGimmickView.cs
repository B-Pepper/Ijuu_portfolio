using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;

namespace MVP.Views
{
    /// <summary>
    /// テープギミックに対応して廊下の背景を変更するギミックのView
    /// </summary>
    public class RoukaGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private RoukaGimmickPresenter _presenter;

        /// <summary>
        /// 画像を変更する処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// 変更先の画像
        /// </summary>
        [SerializeField] private Image tapeSetImage;

        /// <summary>
        /// 変更する玄関画像のパス
        /// </summary>
        [SerializeField] private string changeImagePath;

        /// <summary>
        /// 画像を変更したかどうかのフラグ
        /// </summary>
        private bool isChange = false;
        
        void Awake()
        {
            _presenter = new RoukaGimmickPresenter();
            // テープギミックがUNLOCKされている場合、かつ画像変更フラグがfalseの場合
            if (_presenter.GetGimmickStatus(GimmickConstant.GIMMICK_ENTRANCE_TAPE_ID) == GimmickConstant.GIMMICK_UNLOCK
                && !isChange)
            {
                _changeImageView = new ChangeImageView();
                // 背景変更
                _changeImageView.ChangeImage(tapeSetImage, changeImagePath);
                // 一度のみの変更
                isChange = true;
            }
        }
    }
}