namespace MVP.Presenters
{
    /// <summary>
    /// 治療薬のPresenter
    /// </summary>
    public class MedicinePresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.MedicineModel _model;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MedicinePresenter()
        {
            _model = new MVP.Models.MedicineModel();
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