using MVP.Models;

namespace MVP.Presenters
{
    /// <summary>
    /// 検査薬のPresenter
    /// </summary>
    public class TestDrugPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private TestDrugModel _model;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TestDrugPresenter()
        {
            _model = new TestDrugModel();
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