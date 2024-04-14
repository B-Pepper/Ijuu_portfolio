[System.Serializable]
/// <summary>
/// セーブデータに必要な変数を宣言するクラス
/// インスタンスを作成し、変数に値を格納することでJsonに変換可能となる
/// </summary>
public class SaveData
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
    public int currentSceneNum = 0;

    /// <summary>
    /// プレイ時間
    /// </summary>
    public string playTime = "0000年00月00日00:00:00";

    /// <summary>
    ///  アイテムステータス
    /// </summary>
    public int[]    itemStatus      = new int[18];
    /// <summary>
    /// アイテム名
    /// </summary>
    public string[] itemName        = new string[18];
    /// <summary>
    /// アイテム説明
    /// </summary>
    public string[] itemExplain     = new string[18];
    /// <summary>
    /// アイテム画像名
    /// </summary>
    public string[] itemImageName   = new string[18];
    /// <summary>
    /// ギミックステータス
    /// </summary>
    public int[] gimmickStatus = new int[20];

    /// <summary>
    /// 寝室ステータス
    /// 0: 初期状態(ワイヤーあり、ダイナマイト未設置)
    /// 1: ワイヤーあり、ダイナマイト設置
    /// 2: ワイヤーなし、ダイナマイト未設置
    /// 3: ワイヤーなし、ダイナマイト設置
    /// 4: 爆破後
    /// </summary>
    public int bedroomStatus = 0;

    /// <summary>
    /// コンフィグ画面を開いているか
    /// </summary>
    public bool isOpenSettingWindow = false;

    /// <summary>
    /// 寝室のタンスを開いているか
    /// false : 閉め, true  : 開き
    /// </summary>
    public bool isOpenBedRoomChest = false;

    /// <summary>
    /// ダイアログが表示されているか
    /// </summary>
    public bool isOpenDialog = false;

    /// <summary>
    /// ダイナマイト設置しているかどうか
    /// </summary>
    public bool isSetDynamite = false;

    /// <summary>
    ///導火線着火後の移動回数
    /// </summary>
    public int countStepNum = 0;

    /// <summary>
    /// BGMを再生しているかどうか
    /// </summary>
    public bool isPlayBGM = true;
}

[System.Serializable]
/// <summary>
/// ゲーム全体に必要な変数を宣言するクラス
/// インスタンスを作成し、変数に値を格納することでJsonに変換可能となる
/// </summary>
public class GameData
{
    /// <summary>
    /// BGM音量
    /// </summary>
    public float VOLUME_BGM;
    /// <summary>
    /// SE音量
    /// </summary>
    public float VOLUME_SE;
    /// <summary>
    /// クリアしたENDを格納
    /// </summary>
    public string[] goalScenarios;
}