namespace MVP.Presenters
{
    /// <summary>
    /// 氷塊のPresenter
    /// </summary>
    public class IceBlockPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.IceBlockModel _model;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IceBlockPresenter()
        {
            _model = new MVP.Models.IceBlockModel();
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