namespace MVP.Presenters
{
    /// <summary>
    /// ハサミのPresenter
    /// </summary>
    public class ScissorsPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.ScissorsModel _model;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ScissorsPresenter()
        {
            _model = new MVP.Models.ScissorsModel();
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