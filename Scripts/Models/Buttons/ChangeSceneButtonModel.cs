using System;

namespace MVP.Models
{
    /// <summary>
    /// シーン遷移ボタンのmodel
    /// </summary>
    public class ChangeSceneModel: BaseButtonModel
    {
        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public override void OnClick(){}
        
        /// <summary>
        /// シーンの番号を取得する
        /// </summary>
        /// <param name="sceneNumber">シーン番号</param>
        /// <returns></returns>
        public String GetSceneNumber(int sceneNumber)
        {
            switch(sceneNumber)
            {
                case 0:
                    // タイトル
                    return "0_Title";
                case 1:
                    // 玄関
                    return "1_Genkan";
                case 2:
                    // 書斎
                    return "2_Syosai";
                case 3:
                    // トイレ
                    return "3_Toilet";
                case 4:
                    // 廊下
                    return "4_Rouka";
                case 5:
                    // 寝室
                    return "5_BedRoom";
                case 6:
                    // お風呂
                    return "6_BathRoom";
                case 7:
                    // 台所
                    return "7_Kitchen";
                case 8:
                    // リビング
                    return "8_Living";
                case 9:
                    // ダイニング
                    return "9_Dining";
                case 10:
                    // 倉庫
                    return "10_Souko";
                case 11:
                    // ADV
                    return "ADV";
                case 12:
                    // エンディング
                    return "12_Ending";
                default:
                    return "";
            }
        }
    }
}