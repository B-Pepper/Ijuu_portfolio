using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVP.Models
{
    /// <summary>
    /// タンスの開閉状態を変更する機能のModel
    /// </summary>
    public class ChangeChestStatusModel
    {
        public ChangeChestStatusModel()
        {

        }

        /// <summary>
        /// chestStatusのゲッター
        /// </summary>
        /// <returns>stoveStatus</returns>
        public bool GetStatus()
        {
            return Config.GetIsOpenBedRoomChest();
        }

        /// <summary>
        /// chestStatusのセッター
        /// </summary>
        /// <param name="setStatus">false:閉め true:開き</param>
        public void SetStatus(bool setStatus)
        {
            Config.SetIsOpenBedRoomChest(setStatus);
        }
    }
}