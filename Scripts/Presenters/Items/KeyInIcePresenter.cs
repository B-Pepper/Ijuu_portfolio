namespace MVP.Presenters
{
    /// <summary>
    /// 解凍した鍵のPresenter
    /// </summary>
    public class KeyInIcePresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.KeyInIceModel _model;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public KeyInIcePresenter()
        {
            _model = new MVP.Models.KeyInIceModel();
            // アイテム情報のセットアップ
            _model.InitItemInfo();
        }

        /// <summary>
        /// アイテムIDのゲッター
        /// </summary>
        /// <returns>アイテムID</returns>
        public int GetItemID()
        {
            return _model.GetItemID();
        }

        /// <summary>
        /// アイテムステータスのセッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        /// <param name="status">ステータス</param>
        public void SetItemStatus(int itemId, int status)
        {
            _model.SetItemStatus(itemId, status);
        }
    }
}