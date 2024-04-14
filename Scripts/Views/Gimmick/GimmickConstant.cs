/// <summary>
/// ギミック関連情報の保持クラス
/// </summary>
public static class GimmickConstant
{
    /// <summary>
    /// ギミックの初期フラグ
    /// </summary>
    public const int GIMMICK_LOCK = 0;
    
    /// <summary>
    /// ギミックの解除したフラグ
    /// </summary>
    public const int GIMMICK_UNLOCK = 1;

    // 各ギミックID
    public const int GIMMICK_ENTRANCE_ID = 1;
    public const int GIMMICK_ENTRANCE_TAPE_ID = 2;
    public const int GIMMICK_SYOSAI_DRIVER_ID = 3;
    public const int GIMMICK_SYOSAI_SCISSORS_ID = 4;
    public const int GIMMICK_TOILET_ID = 5;
    public const int GIMMICK_BEDROOM_SCISSORS_ID = 6;
    public const int GIMMICK_BEDROOM_DYNAMITE_ID = 7;
    public const int GIMMICK_KITCHEN_ID = 8;
    public const int GIMMICK_DINING_SAFE_ID = 9;
    public const int GIMMICK_DINING_RECORD_ID = 10;
    public const int GIMMICK_SOUKO_SAFE_ID = 11;
    public const int GIMMICK_SOUKO_DOOR_ID = 12;
    public const int GIMMICK_BEDROOM_SAFE_ID = 13;
    public const int GIMMICK_BEDROOM_IGNITION_ID = 14;
    public const int GIMMICK_SYOSAI_SCISSORS2_ID = 15;
    public const int GIMMICK_SYOSAI_SCISSORS3_ID = 16;

    /// <summary>
    /// ダイナマイト設置時の残り移動回数
    /// </summary>
    public const int REMAIN_STEPS_NUM = 3;

    /// <summary>
    /// プレイ日時の初期値
    /// </summary>
    public const string PLAY_TIME_DEFAULT = "0000年00月00日00:00:00";

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
    public const int SCENE_GENKAN = 0;
    public const int SCENE_SYOSAI = 1;
    public const int SCENE_TOILET = 2;
    public const int SCENE_ROUKA = 3;
    public const int SCENE_BEDROOM = 4;
    public const int SCENE_BATHROOM = 5;
    public const int SCENE_KITCHEN = 6;
    public const int SCENE_LIVING = 7;
    public const int SCENE_DINING = 8;
    public const int SCENE_SOUKO = 9;

    /// <summary>
    /// 寝室ステータス
    /// 0: 初期状態(ワイヤーあり、ダイナマイト未設置)
    /// 1: ワイヤーあり、ダイナマイト設置
    /// 2: ワイヤーなし、ダイナマイト未設置
    /// 3: ワイヤーなし、ダイナマイト設置
    /// 4: 爆破後
    /// 5: 金庫解除後
    /// </summary>
    public const int BEDROOM_STATUS_DEFAULT = 0;
    public const int BEDROOM_STATUS_DYNAMITE = 1;
    public const int BEDROOM_STATUS_WIRE = 2;
    public const int BEDROOM_STATUS_WIREDYNAMITE = 3;
    public const int BEDROOM_STATUS_BOMB = 4;
    public const int BEDROOM_STATUS_SAFE_UNLOCK = 5;
}
