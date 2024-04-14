using UnityEngine;

namespace MVP.Models
{
    public class ItemBoxModel
    {
        /// <summary>
        /// 選択アイテムステータス情報の初期化
        /// </summary>
        public void InitSelectItem()
        {
            int[] allItemStatus = Config.GetAllItemStatus();
            for (int i = 0; i < allItemStatus.Length; i++)
            {
                // 選択しているアイテムを所持状態に変更
                if (allItemStatus[i] == ItemConstant.ITEM_HAVE)
                {
                    allItemStatus[i] = ItemConstant.ITEM_GET;
                }
            }
        }

        /// <summary>
        /// アイテム所持しており、使用可能であるかの判定
        /// </summary>
        /// <param name="itemNum">アイテム番号</param>
        public bool IsExistItemBox(int itemNum)
        {
            int[] allItemStatus = Config.GetAllItemStatus();
            if (allItemStatus[itemNum] == ItemConstant.ITEM_GET)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// アイテムを所持しており、利用不可能であるかの判定
        /// </summary>
        /// <param name="itemNum"></param>
        /// <returns></returns>
        public bool IsExistCannotUseItem(int itemNum)
        {
            int[] allItemStatus = Config.GetAllItemStatus();
            if (allItemStatus[itemNum] == ItemConstant.ITEM_CANT_USE)
            {
                return true;
            }
            return false;
        }
    }
}