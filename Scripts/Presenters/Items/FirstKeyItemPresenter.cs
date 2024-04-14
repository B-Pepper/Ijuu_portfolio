namespace MVP.Presenters
{
    /// <summary>
    /// テストアイテムのPresenter
    /// </summary>
    public class FirstKeyItemPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.FirstKeyItemModel _model;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FirstKeyItemPresenter()
        {
            _model = new MVP.Models.FirstKeyItemModel();
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