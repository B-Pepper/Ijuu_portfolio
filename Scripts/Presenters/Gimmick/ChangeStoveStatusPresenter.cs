using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Models;

namespace MVP.Presenters
{
    /// <summary>
    /// コンロの着火・通常状態に変更する機能のPresenter
    /// </summary>
    public class ChangeStoveStatusPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private ChangeStoveStatusModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ChangeStoveStatusPresenter()
        {
            _model = new ChangeStoveStatusModel();
        }

        /// <summary>
        /// stoveStatusのゲッター
        /// </summary>
        /// <returns>stoveStatus</returns>
        public bool GetStatus()
        {
            return _model.GetStatus();
        }

        /// <summary>
        /// stoveStatusのセッター
        /// </summary>
        /// <param name="setStatus">false:通常 true:点火</param>
        public void SetStatus(bool setStatus)
        {
            _model.SetStatus(setStatus);
        }
    }
}