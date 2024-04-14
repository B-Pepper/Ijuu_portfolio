using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVP.Presenters
{
    /// <summary>
    /// ダイナマイトを設置するギミックのPresenter
    /// </summary>
    public class BedRoomDynamiteGimmickPresenter : MonoBehaviour
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.BedRoomDynamiteGimmickModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BedRoomDynamiteGimmickPresenter()
        {
            _model = new MVP.Models.BedRoomDynamiteGimmickModel();
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
        /// ギミックステータスのゲッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <returns></returns>
        public int GetGimmickStatus(int gimmickId)
        {
            return _model.GetGimmickStatus(gimmickId);
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