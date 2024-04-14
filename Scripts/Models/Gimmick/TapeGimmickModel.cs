using UnityEngine;

namespace MVP.Models
{
    /// <summary>
    /// 玄関ギミックを実行可能にするギミックのModel
    /// </summary>
    public class TapeGimmickModel : BaseGimmickModel
    {
        /// <summary>
        /// ギミック番号
        /// </summary>
        private int _gimmickId = 2;

        /// <summary>
        /// ギミック情報を初期化
        /// </summary>
        public override void InitGimmickInfo()
        {
            _gimmickId = GimmickConstant.GIMMICK_ENTRANCE_TAPE_ID;
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