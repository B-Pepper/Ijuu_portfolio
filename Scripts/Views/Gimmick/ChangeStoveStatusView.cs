using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// コンロの着火・通常状態に変更する機能のView
    /// </summary>
    public class ChangeStoveStatusView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private ChangeStoveStatusPresenter _presenter;

        /// <summary>
        /// 画像を変更する処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// コンロの画像
        /// </summary>
        [SerializeField] private Image stoveImage;

        /// <summary>
        /// 通常状態の画像のパス
        /// </summary>
        [SerializeField] private string defaultImagePath;

        /// <summary>
        /// 点火状態の画像のパス
        /// </summary>
        [SerializeField] private string fireImagePath;

        void Awake()
        {
            _presenter = new ChangeStoveStatusPresenter();
            _changeImageView = new ChangeImageView();
        }

        /// <summary>
        /// stoveStatusのゲッター
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
                _changeImageView.ChangeImage(stoveImage, defaultImagePath);
                _presenter.SetStatus(false);
                SoundManageView.GetInstance().PlaySE((int)SEType.Lock);

            }
            else 
            {
                // 点火画像に変更
                _changeImageView.ChangeImage(stoveImage, fireImagePath);
                _presenter.SetStatus(true);
                SoundManageView.GetInstance().PlaySE((int)SEType.Crinkle);
            }
        }
    }
}