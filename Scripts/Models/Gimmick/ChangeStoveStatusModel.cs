using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Models
{
    /// <summary>
    /// コンロの着火・通常状態に変更する機能のModel
    /// </summary>
    public class ChangeStoveStatusModel
    {
        /// <summary>
        /// 点火状態であるか false:通常 true:点火
        /// </summary>
        private bool stoveStatus;

        public ChangeStoveStatusModel()
        {
            stoveStatus = false;
        }

        /// <summary>
        /// isFireのゲッター
        /// </summary>
        /// <returns>stoveStatus</returns>
        public bool GetStatus()
        {
            return stoveStatus;
        }

        /// <summary>
        /// isFireのセッター
        /// </summary>
        /// <param name="setStatus">false:通常 true:点火</param>
        public void SetStatus(bool setStatus)
        {
            stoveStatus = setStatus;
        }
    }
}