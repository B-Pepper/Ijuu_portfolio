using System;

public class Config
{
    /// <summary>
    /// プレイヤーの現在位置
    /// 0:玄関
    /// 1:書斎
    /// 2:トイレ
    /// 3:廊下
    /// 4:寝室
    /// 5:バスルーム
    /// 6:台所
    /// 7:リビング
    /// 8:ダイニング
    /// 9:倉庫
    /// </summary>
    private static int _currentSceneNum = 0;

    /// <summary>
    /// 選択したデータスロット番号
    /// </summary>
    private static int _selectDataSlotNum = 0;

    /// <summary>
    /// プレイ日時
    /// </summary>
    private static string _playTime = "0000年00月00日00:00:00";

    /// <summary>
    ///  アイテムステータス
    /// </summary>
    private static int[]    itemStatus      = new int[18];
    /// <summary>
    /// アイテム名
    /// </summary>
    private static string[] itemName        = new string[18];
    /// <summary>
    /// アイテム説明
    /// </summary>
    private static string[] itemExplain     = new string[18];
    /// <summary>
    /// アイテム画像名
    /// </summary>
    private static string[] itemImageName   = new string[18];
    /// <summary>
    /// ギミックステータス
    /// </summary>
    private static int[] gimmickStatus = new int[20];

    /// <summary>
    /// 寝室ステータス
    /// 0: 初期状態(ワイヤーあり、ダイナマイト未設置)
    /// 1: ワイヤーあり、ダイナマイト設置
    /// 2: ワイヤーなし、ダイナマイト未設置
    /// 3: ワイヤーなし、ダイナマイト設置
    /// 4: 爆破後
    /// 5: 金庫解除後
    /// </summary>
    private static int bedroomStatus = 0;

    /// <summary>
    /// コンフィグ画面を開いているか
    /// </summary>
    private static bool _isOpenSettingWindow = false;

    /// <summary>
    /// 寝室のタンスを開いているか
    /// false : 閉め, true  : 開き
    /// </summary>
    private static bool _isOpenBedRoomChest = false;

    /// <summary>
    /// 脱出ゲームプレイ中かどうか
    /// </summary>
    private static bool _isPlayingNow = false;

    /// <summary>
    /// ダイアログが表示されているか
    /// </summary>
    private static bool _isOpenDialog = false;

    /// <summary>
    /// ダイナマイト設置しているかどうか
    /// </summary>
    private static bool _isSetDynamite = false;

    /// <summary>
    /// 寝室爆破後の金庫のダイヤル番号
    /// </summary>
    private static string[] bedroomSafeDialNum = new string[3];

    /// <summary>
    ///導火線着火後の移動回数
    /// </summary>
    private static int _countStepNum = 0;

    /// <summary>
    /// ロゴアニメが終了状態
    /// </summary>
    private static bool _isDoneLogoAnime = false;

    /// <summary>
    /// 現在位置のゲッター
    /// </summary>
    /// <returns></returns>
    public static int GetCurrentSceneNum()
    {
        return _currentSceneNum;
    }

    /// <summary>
    /// 現在位置のセッター
    /// </summary>
    /// <returns></returns>
    public static void SetCurrentSceneNum(int sceneNum)
    {
        _currentSceneNum = sceneNum;
    }

    /// <summary>
    /// 選択したデータスロット番号のゲッター
    /// </summary>
    /// <returns>データスロット番号</returns>
    public static int GetSelectDataSlotNum()
    {
        return _selectDataSlotNum;
    }

    /// <summary>
    /// 選択したデータスロット番号のセッター
    /// </summary>
    /// <param name="slotNum">データスロット番号</param>
    public static void SetSelectDataSlotNum(int slotNum)
    {
        _selectDataSlotNum = slotNum;
    }

    /// <summary>
    /// プレイ時間のゲッター
    /// </summary>
    /// <returns>プレイ時間</returns>
    public static string GetPlayTime()
    {
        return _playTime;
    }

    /// <summary>
    /// プレイ時間のセッター
    /// </summary>
    /// <param name="time">プレイ時間</param>
    public static void SetPlayTime(string time)
    {
        _playTime = time;
    }

    /// <summary>
    /// すべてのアイテムステータスのゲッター
    /// </summary>
    /// <returns></returns>
    public static int[] GetAllItemStatus()
    {
        return itemStatus;
    }

    /// <summary>
    /// アイテムステータスのゲッター
    /// </summary>
    /// <param name="itemId">アイテム番号</param>
    /// <returns></returns>
    public static int GetItemStatus(int itemId)
    {
        return itemStatus[itemId];
    }

    /// <summary>
    /// アイテムステータスのセッター
    /// </summary>
    /// <param name="itemId">アイテム番号</param>
    /// <param name="status">ステータス</param>
    public static void SetItemStatus(int itemId, int status)
    {
        itemStatus[itemId] = status;
    }


    /// <summary>
    /// アイテム名のゲッター
    /// </summary>
    /// <param name="itemId">アイテム番号</param>
    /// <returns></returns>
    public static string GetItemName(int itemId)
    {
        return itemName[itemId];
    }

    /// <summary>
    /// アイテム名のセッター
    /// </summary>
    /// <param name="itemId">アイテム番号</param>
    /// <param name="name">アイテム名</param>
    /// <returns></returns>
    public static void SetItemName(int itemId, string name)
    {
        itemName[itemId] = name;
    }

    /// <summary>
    /// アイテム説明のゲッター
    /// </summary>
    /// <param name="itemId">アイテム番号</param>
    /// <returns></returns>
    public static string GetItemExplain(int itemId)
    {
        return itemExplain[itemId];
    }

    /// <summary>
    /// アイテム説明のセッター
    /// </summary>
    /// <param name="itemId">アイテム番号</param>
    /// <param name="explain">アイテムの説明</param>
    /// <returns></returns>
    public static void SetItemExplain(int itemId, string explain)
    {
        itemExplain[itemId] = explain;
    }


    /// <summary>
    /// アイテム画像名のゲッター
    /// </summary>
    /// <returns></returns>
    public static string GetItemImageName(int itemId)
    {
        return itemImageName[itemId];
    }
    
    /// <summary>
    /// アイテム画像名のセッター
    /// </summary>
    /// <param name="itemId">アイテム番号</param>
    /// /// <param name="imageName">アイテム画像パス</param>
    /// <returns></returns>
    public static void SetItemImageName(int itemId, string imageName)
    {
        itemImageName[itemId] = imageName;
    }

    /// <summary>
    /// すべてのギミックステータスのゲッター
    /// </summary>
    /// <returns></returns>
    public static int[] GetAllGimmickStatus()
    {
        return gimmickStatus;
    }

    /// <summary>
    /// ギミックステータスのゲッター
    /// </summary>
    /// <param name="gimmickId">ギミック番号</param>
    /// <returns></returns>
    public static int GetGimmickStatus(int gimmickId)
    {
        return gimmickStatus[gimmickId];
    }

    /// <summary>
    /// ギミックステータスのセッター
    /// </summary>
    /// <param name="gimmickId">ギミック番号</param>
    /// <param name="status">ステータス</param>
    /// <returns></returns>
    public static void SetGimmickStatus(int gimmickId, int status)
    {
        gimmickStatus[gimmickId] = status;
    }

    /// <summary>
    /// 寝室ステータスのゲッター
    /// </summary>
    /// <returns></returns>
    public static int GetBedroomStatus()
    {
        return bedroomStatus;
    }

    /// <summary>
    /// 寝室ステータスのセッター
    /// </summary>
    /// <param name="status">ステータス</param>
    public static void SetBedroomStatus(int status)
    {
        bedroomStatus = status;
    }

    /// <summary>
    /// 設定ウィンドウを開いているかのフラグ取得
    /// </summary>
    /// <returns>フラグ値</returns>
    public static bool GetIsOpenSettingWindow()
    {
        return _isOpenSettingWindow;
    }

    /// <summary>
    /// 設定ウィンドウを開いているかのフラグ設定
    /// </summary>
    /// <param name="isOpen">フラグ値設定</param>
    public static void SetIsOpenSettingWindow(bool isOpen)
    {
        _isOpenSettingWindow = isOpen;
    }

    /// <summary>
    /// 寝室のタンスを開いているかのフラグ取得
    /// </summary>
    /// <returns>フラグ値</returns>
    public static bool GetIsOpenBedRoomChest()
    {
        return _isOpenBedRoomChest;
    }

    /// <summary>
    /// 寝室のタンスを開いているかのフラグ設定
    /// false : 閉め, true  : 開き
    /// </summary>
    /// <param name="isOpen">フラグ値設定</param>
    public static void SetIsOpenBedRoomChest(bool isOpen)
    {
        _isOpenBedRoomChest = isOpen;
    }

    /// <summary>
    /// 今プレイ中かどうかを取得
    /// </summary>
    /// <returns>プレイ中:true,プレイしていないタイトルなど:false</returns>
    public static bool GetIsPlayingNow()
    {
        return _isPlayingNow;
    }

    /// <summary>
    /// プレイ状況の更新
    /// </summary>
    /// <param name="isPlay">プレイ中かどうか</param>
    public static void SetIsPlayingNow(bool isPlay)
    {
        _isPlayingNow = isPlay;
    }

    /// <summary>
    /// ダイアログを開いているかのフラグを取得
    /// </summary>
    /// <returns>ダイアログの状況</returns>
    public static bool GetIsOpenDialog()
    {
        return _isOpenDialog;
    }

    /// <summary>
    /// ダイアログを開いているかのフラグを更新
    /// </summary>
    /// <param name="isOpen">フラグ値設定</param>
    public static void SetIsOpenDialog(bool isOpen)
    {
        _isOpenDialog = isOpen;
    }
  
    /// ダイナマイトを設置しているかどうか
    /// </summary>
    /// <returns>設置済み: true, 未設置: false</returns>
    public static bool GetIsSetDynamite()
    {
        return _isSetDynamite;
    }

    /// <summary>
    /// ダイナマイト設置状況の更新
    /// </summary>
    /// <param name="isSet">設置状況</param>
    public static void SetIsSetDynamite(bool isSet)
    {
        _isSetDynamite = isSet;
    } 

    /// <summary>
    /// 寝室爆破後金庫のダイヤル番号のゲッター
    /// </summary>
    /// <returns></returns>
    public static string[] GetBedroomSafeDialNum()
    {
        return bedroomSafeDialNum;
    }

    /// <summary>
    /// 寝室爆破後金庫のダイヤル番号のセッター
    /// </summary>
    /// <returns></returns>
    public static void SetBedroomSafeDialNum(string[] num)
    {
        bedroomSafeDialNum = num;
    }

    /// <summary>
    /// 着火後の移動回数取得
    /// </summary>
    /// <returns>移動回数</returns>
    public static int GetCountStepNum()
    {
        return _countStepNum;
    }

    /// <summary>
    /// 着火後の移動回数設定
    /// </summary>
    /// <param name="currentStepNum">現在の移動回数</param>
    public static void SetCountStepNum(int currentStepNum)
    {
        _countStepNum = currentStepNum;
    }

    /// <summary>
    /// 着火後の移動回数初期化
    /// </summary>
    public static void ResetCountStepNum() 
    {
        _countStepNum = 0;
    }

    /// <summary>
    /// 着火後移動回数のカウント
    /// </summary>
    public static void IncreamentCountStepNum()
    {
        _countStepNum++;
    }

    /// <summary>
    /// ロゴアニメが終了状態か設定
    /// </summary>
    /// <param name="isDone">ロゴアニメ終了状態<</param>
    public static void SetIsDoneLogoAnime(bool isDone)
    {
        _isDoneLogoAnime = isDone;
    }
    
    /// <summary>
    /// ロゴアニメが終了状態か取得
    /// </summary>
    /// <returns>ロゴアニメ終了状態</returns>
    public static bool GetIsDoneLogoAnime()
    {
        return _isDoneLogoAnime;
    }
}
