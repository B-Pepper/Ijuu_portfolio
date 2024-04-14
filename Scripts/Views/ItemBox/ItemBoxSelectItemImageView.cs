using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// 選択アイテム画像の更新処理
    /// </summary>
    public class ItemBoxSelectItemImageView : MonoBehaviour
    {
        /// <summary>
        /// 選択アイテム画像
        /// </summary>
        [SerializeField] Image _selectItemImage;

        /// <summary>
        /// アイテムボックス内に表示するGameObject
        /// </summary>
        [SerializeField] GameObject[] _itemsInItemBox;

        /// <summary>
        /// デフォルト画像
        /// </summary>
        [SerializeField] Sprite _defaultImage;
        
        /// <summary>
        /// 起動時に実行
        /// </summary>
        private void OnEnable()
        {
            UpdateSelectItemImage();
        }

        /// <summary>
        /// アイテムボックスを更新
        /// </summary>
        public void UpdateSelectItemImage()
        {
            int[] allItemStatus = Config.GetAllItemStatus();
            for (int i = 0; i < allItemStatus.Length; i++)
            {
                if (allItemStatus[i] == ItemConstant.ITEM_HAVE)
                {
                    _selectItemImage.sprite = _itemsInItemBox[i].GetComponent<Image>().sprite;
                    break;
                }
                else
                {
                    _selectItemImage.sprite = _defaultImage;
                }
            }
            Debug.Log("選択アイテム画像更新完了");
        }
    }
}