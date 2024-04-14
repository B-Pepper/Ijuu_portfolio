namespace MVP.Models
{

    public abstract class BaseGimmickModel
    {
        /// <summary>
        /// ギミック情報を初期化
        /// </summary>
        public abstract void InitGimmickInfo();

        /// <summary>
        /// ギミックIDのゲッター
        /// </summary>
        public abstract int GetGimmickID();

        /// <summary>
        /// すべてのギミックステータスのゲッター
        /// </summary>
        public abstract int[] GetAllGimmickStatus();

        /// <summary>
        /// ギミックステータスのゲッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        public abstract int GetGimmickStatus(int gimmickId);

        /// <summary>
        /// ギミックステータスのセッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <param name="status">ステータス</param>
        public abstract void SetGimmickStatus(int gimmickId, int status);
    }
}