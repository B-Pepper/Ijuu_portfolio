using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Models
{
    /// <summary>
    /// 本ギミックのModel
    /// </summary>
    public class BookGimmick2Model : BaseGimmickModel
    {
            /// <summary>
            /// ギミック番号
            /// </summary>
            private int _gimmickId = 15;

            /// <summary>
            /// ギミック情報を初期化
            /// </summary>
            public override void InitGimmickInfo()
            {
                _gimmickId = GimmickConstant.GIMMICK_SYOSAI_SCISSORS2_ID;
                Debug.Log("gimmickId: "+ _gimmickId);
            }

            /// <summary>
            /// ギミック番号のゲッター
            /// </summary>
            /// <returns></returns>
            public override int GetGimmickID()
            {
                return _gimmickId;
            }

            /// <summary>
            /// 全ギミックステータスのゲッター
            /// </summary>
            /// <returns></returns>
            public override int[] GetAllGimmickStatus()
            {
                return Config.GetAllGimmickStatus();
            }

            /// <summary>
            /// ギミックステータスのゲッター
            /// </summary>
            /// <param name="gimmickId">ギミック番号</param>
            /// <returns></returns>
            public override int GetGimmickStatus(int gimmickId)
            {
                return Config.GetGimmickStatus(gimmickId);
            }

            /// <summary>
            /// ギミックステータスのセッター
            /// </summary>
            /// <param name="gimmickId">ギミック番号</param>
            /// <param name="status">ステータス</param>
            public override void SetGimmickStatus(int gimmickId, int status)
            {
                Config.SetGimmickStatus(gimmickId, status);
            }
    }
}