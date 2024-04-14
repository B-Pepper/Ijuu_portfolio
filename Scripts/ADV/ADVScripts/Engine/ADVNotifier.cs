using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HarapekoADV
{
    /// <summary>
    /// 変更通知用インターフェース
    /// </summary>
    public interface ADVNotifier
    {
        /// <summary>
        /// ADV開始時の状態
        /// </summary>
        void NotifyADVStart();
        /// <summary>
        /// ADV終了時の状態
        /// </summary>
        void NotifyADVFinish();
    }
}

