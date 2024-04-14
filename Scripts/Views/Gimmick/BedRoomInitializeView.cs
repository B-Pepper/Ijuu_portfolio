using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MVP.Views
{
    /// <summary>
    /// 寝室起動時に表示するパネルを選択
    /// </summary>
    public class BedRoomInitializeView : MonoBehaviour
    {
        /// <summary>
        /// ワイヤーあり、ダイナマイト設置
        /// </summary>
        [SerializeField] ChangePanelButtonView _dynamite;
        /// <summary>
        /// ワイヤーなし、ダイナマイト未設置
        /// </summary>
        [SerializeField] ChangePanelButtonView _wire;
        /// <summary>
        /// ワイヤーなし、ダイナマイト設置
        /// </summary>
        [SerializeField] ChangePanelButtonView _wireDynamite;
        /// <summary>
        /// 爆破後
        /// </summary>
        [SerializeField] ChangePanelButtonView _bomb;
        /// <summary>
        /// 金庫解除後
        /// </summary>
        [SerializeField] ChangePanelButtonView _safeUnlock;

        private void Awake()
        {
            Debug.Log("寝室のステータス：" + Config.GetBedroomStatus());

            switch (Config.GetBedroomStatus())
            {
                case 0:
                    // デフォルトは何もしない
                    break;
                case 1:
                    _dynamite.Onclick();
                    break;
                case 2:
                    _wire.Onclick();
                    break;
                case 3:
                    _wireDynamite.Onclick();
                    break;
                case 4:
                    _bomb.Onclick();
                    break;
                case 5:
                    _safeUnlock.Onclick();
                    break;
            }
        }
    }
}