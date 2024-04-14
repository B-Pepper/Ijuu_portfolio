using UnityEngine;

namespace MVP.Models
{    
    /// <summary>
    /// テープギミックに対応して廊下の背景を変更するギミックのModel
    /// </summary>
    public class RoukaGimmickModel
    {
        /// <summary>
        /// ギミックステータスのゲッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <returns></returns>
        public int GetGimmickStatus(int gimmickId)
        {
            return Config.GetGimmickStatus(gimmickId);
        }
    }
}