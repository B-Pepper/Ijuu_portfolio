using UnityEngine;

namespace MVP.Models
{
    /// <summary>
    /// テストアイテムのModel
    /// </summary>
    public class FirstKeyItemModel : BaseItemModel
    {
        /// <summary>
        /// アイテムID
        /// </summary>
        private int _itemId = 0;
        
        /// <summary>
        /// アイテム名
        /// </summary>
        private string _itemName;
        
        /// <summary>
        /// アイテム説明
        /// </summary>
        private string _itemExplain;
        
        /// <summary>
        /// アイテム画像名
        /// </summary>
        private string _itemImageName;


        /// <summary>
        /// アイテム情報を初期化
        /// </summary>
        public override void InitItemInfo()
        {
            _itemName = Config.GetItemName(_itemId);
            _itemExplain = Config.GetItemExplain(_itemId);
            _itemImageName = Config.GetItemImageName(_itemId);
            Debug.Log("itemName: "+ _itemName + ",itemExplain: "+ _itemExplain + ",itemImageName: "+ _itemImageName);
        }
        
        /// <summary>
        /// アイテムIDのゲッター
        /// </summary>
        public override int GetItemID()
        {
            Debug.Log("GetItemID() => START");
            return _itemId;
        }

        /// <summary>
        /// 全アイテムステータスのゲッター
        /// </summary>
        public override int[] GetAllItemStatus()
        {
            return Config.GetAllItemStatus();
        }

        /// <summary>
        /// アイテムステータスのゲッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        public override int GetItemStatus(int itemId)
        {
            return Config.GetItemStatus(itemId);
        }

        /// <summary>
        /// アイテムステータスのセッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        /// <param name="status">ステータス</param>
        public override void SetItemStatus(int itemId, int status)
        {
            Config.SetItemStatus(itemId, status);
            Debug.Log("SetItemStatus(itemId, status) => START");
        }

        /// <summary>
        /// アイテム名のゲッター
        /// </summary>
        public override string GetItemName(int itemId)
        {   
            return Config.GetItemName(itemId);
        }

        /// <summary>
        /// アイテム説明のゲッター
        /// </summary>
        public override string GetItemExplain(int itemId)
        {
            return Config.GetItemExplain(itemId);
        }

        /// <summary>
        /// アイテム画像名のゲッター
        /// </summary>
        public override string GetItemImageName(int itemId)
        {        
            return Config.GetItemImageName(itemId);
        }
        
    }
}