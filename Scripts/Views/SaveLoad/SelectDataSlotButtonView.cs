using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Presenters;
using MVP.Views;

namespace MVP.Views
{
    /// <summary>
    /// データスロットボタンクリック時処理
    /// </summary>
    public class SelectDataSlotButtonView : MonoBehaviour
    {
        public void OnClick(int slotNum)
        {
            // 押下されたスロット番号をセット
            Config.SetSelectDataSlotNum(slotNum);
        }
    }
}