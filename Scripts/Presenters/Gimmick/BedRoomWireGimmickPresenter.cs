using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVP.Presenters
{
    /// <summary>
    /// 寝室タンスワイヤーギミックのPresenter
    /// </summary>
    public class BedRoomWireGimmickPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.BedRoomWireGimmickModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BedRoomWireGimmickPresenter()
        {
            _model = new MVP.Models.BedRoomWireGimmickModel();
            // アイテム情報のセットアップ
            _model.InitGimmickInfo();
        }

        /// <summary>
        /// ギミックIDのゲッター
        /// </summary>
        /// <returns></returns>
        public int GetGimmickID()
        {
            return _model.GetGimmickID();
        }

        /// <summary>
        /// ギミックステータスのセッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <param name="status">ステータス</param>
        public void SetGimmickStatus(int gimmickId, int status)
        {
            _model.SetGimmickStatus(gimmickId, status);
        }
    }
}