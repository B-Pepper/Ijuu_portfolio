using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Presenters
{
    /// <summary>
    /// テープギミックに対応して廊下の背景を変更するギミックのPresenter
    /// </summary>
    public class RoukaGimmickPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.RoukaGimmickModel _model;

        public RoukaGimmickPresenter()
        {
            _model = new MVP.Models.RoukaGimmickModel();
        }

        /// <summary>
        /// ギミックステータスのゲッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <returns></returns>
        public int GetGimmickStatus(int gimmickId)
        {
            return _model.GetGimmickStatus(gimmickId);
        }
    }
}