using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;

namespace MVP.Views
{
    /// <summary>
    /// タンスの開閉状態を変更する機能のView
    /// </summary>
    public class ChangeChestStatusView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private ChangeChestStatusPresenter _presenter;

        /// <summary>
        /// 画像を変更する処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// タンスの画像
        /// </summary>
        [SerializeField] private Image chestImage;

        /// <summary>
        /// 通常状態の画像のパス
        /// </summary>
        [SerializeField] private string defaultImagePath;

        /// <summary>
        /// 開いた状態の画像のパス
        /// </summary>
        [SerializeField] private string openImagePath;

        void Awake()
        {
            _presenter = new ChangeChestStatusPresenter();
            _changeImageView = new ChangeImageView();
        }

        /// <summary>
        /// chestStatusのゲッター
        /// </summary>
        /// <returns>stoveStatus</returns>
        public bool GetStatus()
        {
            return _presenter.GetStatus();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            if (GetStatus())
            {
                // 通常状態に変更
                _changeImageView.ChangeImage(chestImage, defaultImagePath);
                _presenter.SetStatus(false);
            }
            else
            {
                // 開いた状態の画像に変更
                _changeImageView.ChangeImage(chestImage, openImagePath);
                _presenter.SetStatus(true);
            }
        }
    }
}