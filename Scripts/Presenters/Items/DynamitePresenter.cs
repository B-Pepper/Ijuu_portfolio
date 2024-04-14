namespace MVP.Presenters
{
    /// <summary>
    /// ダイナマイトのPresenter
    /// </summary>
    public class DynamitePresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.DynamiteModel _model;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DynamitePresenter()
        {
            _model = new MVP.Models.DynamiteModel();
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