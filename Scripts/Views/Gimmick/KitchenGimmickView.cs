using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;

namespace MVP.Views
{
    /// <summary>
    /// キッチンギミックの管理
    /// </summary>
    public class KitchenGimmickView : MonoBehaviour
    {
        /// <summary>
        /// 凍結鍵のオブジェクト
        /// </summary>
        [SerializeField] private GameObject _iceBlock;

        /// <summary>
        /// /// 解凍された鍵のオブジェクト
        /// </summary>
        [SerializeField] private GameObject _keyInIce;
        

        void Awake()
        {
            // ICEBLOCKを所持・消費している時
            if (Config.GetItemStatus(ItemConstant.ITEM_ICEBLOCK_ID) > ItemConstant.ITEM_DEFAULT)
            {
                _iceBlock.SetActive(false);
            }
            // アイスギミックがUNLOCKの時、KEYINICE表示
            if (Config.GetGimmickStatus(GimmickConstant.GIMMICK_KITCHEN_ID) == GimmickConstant.GIMMICK_UNLOCK)
            {
                HandleViewKeyInIce(true);
            }
            // すでに持っていたら、KEYINICE非表示
            if (Config.GetItemStatus(ItemConstant.ITEM_KEYINICE_ID) > ItemConstant.ITEM_DEFAULT)
            {
                HandleViewKeyInIce(false);
            }
        }

        /// <summary>
        /// 鍵表示
        /// </summary>
        /// <param name="isVisible"></param>
        public void HandleViewKeyInIce(bool isVisible)
        {
            _keyInIce.SetActive(isVisible);
        }
    }
}