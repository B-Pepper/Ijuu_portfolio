namespace MVP.Models
{
    /// <summary>
    /// 基本的なアイテムのModel
    /// </summary>
    public abstract class BaseItemModel
    {

        /// <summary>
        /// アイテム情報を初期化
        /// </summary>
        public abstract void InitItemInfo();

        /// <summary>
        /// アイテムIDのゲッター
        /// </summary>
        public abstract int GetItemID();

        /// <summary>
        /// すべてのアイテムステータスのゲッター
        /// </summary>
        public abstract int[] GetAllItemStatus();

        /// <summary>
        /// アイテムステータスのゲッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        public abstract int GetItemStatus(int itemId);

        /// <summary>
        /// アイテムステータスのセッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        /// <param name="status">ステータス</param>
        public abstract void SetItemStatus(int itemId, int status);

        /// <summary>
        /// 君は完璧でアイテム名のゲッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        public abstract string GetItemName(int itemId);

        /// <summary>
        /// アイテム説明のゲッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        public abstract string GetItemExplain(int itemId);

        /// <summary>
        /// アイテム画像名のゲッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        public abstract string GetItemImageName(int itemId);

    }
}