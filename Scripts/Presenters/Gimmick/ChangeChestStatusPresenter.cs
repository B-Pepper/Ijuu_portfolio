using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Models;

namespace MVP.Presenters
{
    /// <summary>
    /// タンスの開閉状態を変更する機能のPresenter
    /// </summary>
    public class ChangeChestStatusPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private ChangeChestStatusModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ChangeChestStatusPresenter()
        {
            _model = new ChangeChestStatusModel();
        }

        /// <summary>
        /// chestStatusのゲッター
        /// </summary>
        /// <returns>chestStatus</returns>
        public bool GetStatus()
        {
            return _model.GetStatus();
        }

        /// <summary>
        /// chestStatusのセッター
        /// </summary>
        /// <param name="setStatus">false:閉め true:開き</param>
        public void SetStatus(bool setStatus)
        {
            _model.SetStatus(setStatus);
        }
    }
}