using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;

namespace MVP.Views
{
    /// <summary>
    /// ゲーム内情報初期化、ロード処理のView
    /// </summary>
    public class InitializeGameInfoView : MonoBehaviour
    {
        /// <summary>
        /// ゲーム開始ボタンを押下時
        /// </summary>
        public void OnNewGameClick()
        {
            // 初期化処理
            InitGameInfo();
        }

        /// <summary>
        /// ゲーム内情報の初期化
        /// </summary>
        private void InitGameInfo()
        {
            for(int i = 0; i < Config.GetAllItemStatus().Length; i++)
            {
                // アイテムの初期ステータスをセット
                Config.SetItemStatus(i, ItemConstant.ITEM_DEFAULT);
                // ギミックの初期ステータスをセット
                Config.SetGimmickStatus(i, GimmickConstant.GIMMICK_LOCK);
            }

            // アイテム名をセット
            Config.SetItemName(0, ItemConstant.ITEM_SCISSORS_NAME);
            Config.SetItemName(1, ItemConstant.ITEM_ASAHIMO1_NAME);
            Config.SetItemName(2, ItemConstant.ITEM_ASAHIMO2_NAME);
            Config.SetItemName(3, ItemConstant.ITEM_ASAHIMO3_NAME);
            Config.SetItemName(4, ItemConstant.ITEM_TAPE_NAME);
            Config.SetItemName(5, ItemConstant.ITEM_DRIVER_NAME);
            Config.SetItemName(6, ItemConstant.ITEM_TOILETPAPER_NAME);
            Config.SetItemName(7, ItemConstant.ITEM_ICEBLOCK_NAME);
            Config.SetItemName(8, ItemConstant.ITEM_KEYINICE_NAME);
            Config.SetItemName(9, ItemConstant.ITEM_MYSTERYPAPER_NAME);
            Config.SetItemName(10, ItemConstant.ITEM_DYNAMITE_NAME);
            Config.SetItemName(11, ItemConstant.ITEM_MEDICINE_NAME);
            Config.SetItemName(12, ItemConstant.ITEM_MYSTERYPAPERENTRANCE_NAME);
            Config.SetItemName(13, ItemConstant.ITEM_TESTDRUG_NAME);
            Config.SetItemName(14, ItemConstant.ITEM_LONGASAHIMO_NAME);
            Config.SetItemName(15, ItemConstant.ITEM_SABISCISSORS_NAME);
            Config.SetItemName(16, ItemConstant.ITEM_MYSTERYPAPERSOUKO_NAME);
            Config.SetItemName(17, ItemConstant.ITEM_MATERNITYHANDBOOK_NAME);

            // アイテム説明をセット
            Config.SetItemExplain(0, ItemConstant.ITEM_SCISSORS_EXPLAIN);
            Config.SetItemExplain(1, ItemConstant.ITEM_ASAHIMO1_EXPLAIN);
            Config.SetItemExplain(2, ItemConstant.ITEM_ASAHIMO2_EXPLAIN);
            Config.SetItemExplain(3, ItemConstant.ITEM_ASAHIMO3_EXPLAIN);
            Config.SetItemExplain(4, ItemConstant.ITEM_TAPE_EXPLAIN);
            Config.SetItemExplain(5, ItemConstant.ITEM_DRIVER_EXPLAIN);
            Config.SetItemExplain(6, ItemConstant.ITEM_TOILETPAPER_EXPLAIN);
            Config.SetItemExplain(7, ItemConstant.ITEM_ICEBLOCK_EXPLAIN);
            Config.SetItemExplain(8, ItemConstant.ITEM_KEYINICE_EXPLAIN);
            Config.SetItemExplain(9, ItemConstant.ITEM_MYSTERYPAPER_EXPLAIN);
            Config.SetItemExplain(10, ItemConstant.ITEM_DYNAMITE_EXPLAIN);
            Config.SetItemExplain(11, ItemConstant.ITEM_MEDICINE_EXPLAIN);
            Config.SetItemExplain(12, ItemConstant.ITEM_MYSTERYPAPERENTRANCE_EXPLAIN);
            Config.SetItemExplain(13, ItemConstant.ITEM_TESTDRUG_EXPLAIN);
            Config.SetItemExplain(14, ItemConstant.ITEM_LONGASAHIMO_EXPLAIN);
            Config.SetItemExplain(15, ItemConstant.ITEM_SABISCISSORS_EXPLAIN);
            Config.SetItemExplain(16, ItemConstant.ITEM_MYSTERYPAPERSOUKO_EXPLAIN);
            Config.SetItemExplain(17, ItemConstant.ITEM_MATERNITYHANDBOOK_EXPLAIN);

            // 各種フラグの初期化
            Config.SetIsOpenSettingWindow(false);
            Config.SetIsOpenBedRoomChest(false);
            Config.SetIsOpenDialog(false);
            Config.SetIsSetDynamite(false);
            Config.SetBedroomStatus(GimmickConstant.BEDROOM_STATUS_DEFAULT);
            Config.SetCurrentSceneNum(GimmickConstant.SCENE_GENKAN);
            Config.SetPlayTime(GimmickConstant.PLAY_TIME_DEFAULT);
            Config.ResetCountStepNum();

            // ゲーム全体データのロード
            GameDataSaverPresenter gameDataSaverPresenter = new GameDataSaverPresenter();
            if (gameDataSaverPresenter.GameDataLoad())
            {
                Debug.Log("ゲーム全体の情報のロードができました");
            }

            Debug.Log("初期化完了");
        }

        /// <summary>
        /// ゲーム内情報をロード
        /// </summary>
        /// <param name="loadData">ロードデータ</param>
        public void LoadGameInfo(SaveData loadData)
        {
            for(int i = 0; i < loadData.itemStatus.Length; i++)
            {
                // アイテムの初期ステータスをセット
                Config.SetItemStatus(i, loadData.itemStatus[i]);
                // ギミックの初期ステータスをセット
                Config.SetGimmickStatus(i, loadData.gimmickStatus[i]);
            }

            // アイテム説明をセット
            Config.SetItemExplain(0, ItemConstant.ITEM_SCISSORS_EXPLAIN);
            Config.SetItemExplain(1, ItemConstant.ITEM_ASAHIMO1_EXPLAIN);
            Config.SetItemExplain(2, ItemConstant.ITEM_ASAHIMO2_EXPLAIN);
            Config.SetItemExplain(3, ItemConstant.ITEM_ASAHIMO3_EXPLAIN);
            Config.SetItemExplain(4, ItemConstant.ITEM_TAPE_EXPLAIN);
            Config.SetItemExplain(5, ItemConstant.ITEM_DRIVER_EXPLAIN);
            Config.SetItemExplain(6, ItemConstant.ITEM_TOILETPAPER_EXPLAIN);
            Config.SetItemExplain(7, ItemConstant.ITEM_ICEBLOCK_EXPLAIN);
            Config.SetItemExplain(8, ItemConstant.ITEM_KEYINICE_EXPLAIN);
            Config.SetItemExplain(9, ItemConstant.ITEM_MYSTERYPAPER_EXPLAIN);
            Config.SetItemExplain(10, ItemConstant.ITEM_DYNAMITE_EXPLAIN);
            Config.SetItemExplain(11, ItemConstant.ITEM_MEDICINE_EXPLAIN);
            Config.SetItemExplain(12, ItemConstant.ITEM_MYSTERYPAPERENTRANCE_EXPLAIN);
            Config.SetItemExplain(13, ItemConstant.ITEM_TESTDRUG_EXPLAIN);
            Config.SetItemExplain(14, ItemConstant.ITEM_LONGASAHIMO_EXPLAIN);
            Config.SetItemExplain(15, ItemConstant.ITEM_SABISCISSORS_EXPLAIN);
            Config.SetItemExplain(16, ItemConstant.ITEM_MYSTERYPAPERSOUKO_EXPLAIN);
            Config.SetItemExplain(17, ItemConstant.ITEM_MATERNITYHANDBOOK_EXPLAIN);

            // 各種フラグの初期化
            Config.SetIsOpenSettingWindow(loadData.isOpenSettingWindow);
            Config.SetIsOpenBedRoomChest(loadData.isOpenBedRoomChest);
            Config.SetIsOpenDialog(loadData.isOpenDialog);
            Config.SetIsSetDynamite(loadData.isSetDynamite);
            Config.SetBedroomStatus(loadData.bedroomStatus);
            Config.SetCurrentSceneNum(loadData.currentSceneNum);
            Config.SetPlayTime(loadData.playTime);
            Config.SetCountStepNum(loadData.countStepNum);
        }
    }
}