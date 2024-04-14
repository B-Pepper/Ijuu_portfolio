/// <summary>
/// アイテム関連情報の保持クラス
/// </summary>
public static class ItemConstant
{
    /// <summary>
    /// アイテムの初期ステータス
    /// </summary>
    public const int ITEM_DEFAULT = 0;
    /// <summary>
    /// アイテムを入手したフラグ
    /// </summary>
    public const int ITEM_GET = 1;
    /// <summary>
    /// アイテム使用不可のフラグ(アイテムボックスには残る)
    /// </summary>
    public const int ITEM_CANT_USE = 2;
    /// <summary>
    /// アイテム消費のフラグ(アイテムボックスから削除)
    /// </summary>
    public const int ITEM_CONSUME = 3;
    /// <summary>
    /// アイテムを手に持っているフラグ
    /// </summary>
    public const int ITEM_HAVE = 4;

    // 各アイテムID
    public const int ITEM_SCISSORS_ID                = 0;
    public const int ITEM_ASAHIMO1_ID                = 1;
    public const int ITEM_ASAHIMO2_ID                = 2;
    public const int ITEM_ASAHIMO3_ID                = 3;
    public const int ITEM_TAPE_ID                    = 4;
    public const int ITEM_DRIVER_ID                  = 5;
    public const int ITEM_TOILETPAPER_ID             = 6;
    public const int ITEM_ICEBLOCK_ID                = 7;
    public const int ITEM_KEYINICE_ID                = 8;
    public const int ITEM_MYSTERYPAPER_ID            = 9;
    public const int ITEM_DYNAMITE_ID                = 10;
    public const int ITEM_MEDICINE_ID                = 11;
    public const int ITEM_MYSTERYPAPERENTRANCE_ID    = 12;
    public const int ITEM_TESTDRUG_ID                = 13;
    public const int ITEM_LONGASAHIMO_ID             = 14;
    public const int ITEM_SABISCISSORS_ID            = 15;
    public const int ITEM_MYSTERYPAPERSOUKO_ID       = 16;
    public const int ITEM_MATERNITYHANDBOOK_ID       = 17;

    // 各アイテム名
    public const string ITEM_SCISSORS_NAME = "ハサミ";
    public const string ITEM_ASAHIMO1_NAME = "麻紐";
    public const string ITEM_ASAHIMO2_NAME = "麻紐";
    public const string ITEM_ASAHIMO3_NAME = "麻紐";
    public const string ITEM_TAPE_NAME     = "ビニールテープ";
    public const string ITEM_DRIVER_NAME   = "ドライバ";
    public const string ITEM_TOILETPAPER_NAME = "トイレットペーパー";
    public const string ITEM_ICEBLOCK_NAME    = "氷漬けの鍵";
    public const string ITEM_KEYINICE_NAME    = "解凍済みの鍵";
    public const string ITEM_MYSTERYPAPER_NAME = "謎の紙";
    public const string ITEM_DYNAMITE_NAME     = "爆薬";
    public const string ITEM_MEDICINE_NAME = "銀の弾丸";
    public const string ITEM_MYSTERYPAPERENTRANCE_NAME = "玄関の謎";
    public const string ITEM_TESTDRUG_NAME             = "試験薬";
    public const string ITEM_LONGASAHIMO_NAME          = "長い麻紐";
    public const string ITEM_SABISCISSORS_NAME         = "ボロボロのハサミ";
    public const string ITEM_MYSTERYPAPERSOUKO_NAME    = "倉庫の謎";
    public const string ITEM_MATERNITYHANDBOOK_NAME    = "母子手帳";

     // 各アイテム説明
    public const string ITEM_SCISSORS_EXPLAIN = "はさみ。";
    public const string ITEM_ASAHIMO1_EXPLAIN = "ひも。";
    public const string ITEM_ASAHIMO2_EXPLAIN = "ひも。";
    public const string ITEM_ASAHIMO3_EXPLAIN = "ひも。";
    public const string ITEM_TAPE_EXPLAIN = "黒いビニールテープ。";
    public const string ITEM_DRIVER_EXPLAIN = "赤い持ち手のプラスドライバー。";
    public const string ITEM_TOILETPAPER_EXPLAIN = "";
    public const string ITEM_ICEBLOCK_EXPLAIN = "四角い氷の中に鍵があるみたい。";
    public const string ITEM_KEYINICE_EXPLAIN = "鍵。";
    public const string ITEM_MYSTERYPAPER_EXPLAIN = "";
    public const string ITEM_DYNAMITE_EXPLAIN = "着火すれば爆発するだろう。";
    public const string ITEM_MEDICINE_EXPLAIN = "多分飲むものだけど……。　　　　持っておこう。";
    public const string ITEM_MYSTERYPAPERENTRANCE_EXPLAIN = "玄関のテンキーに何か入力されて　いる。";
    public const string ITEM_TESTDRUG_EXPLAIN = "検査キットに見える。";
    public const string ITEM_LONGASAHIMO_EXPLAIN = "ひもが３本集まってかさばるので　１本にまとめた。";
    public const string ITEM_SABISCISSORS_EXPLAIN = "はさみ。もう使えない。";
    public const string ITEM_MYSTERYPAPERSOUKO_EXPLAIN = "何処の写真なんだろう。";
    public const string ITEM_MATERNITYHANDBOOK_EXPLAIN = "";

    // 各アイテム画像パス
    public const string ITEM_SCISSORS_IMAGENAME = "Images/Items/Scissors_1";
    public const string ITEM_ASAHIMO1_IMAGENAME = "Images/Items/Asahimo";
    public const string ITEM_ASAHIMO2_IMAGENAME = "Images/Items/Asahimo";
    public const string ITEM_ASAHIMO3_IMAGENAME = "Images/Items/Asahimo";
    public const string ITEM_TAPE_IMAGENAME     = "Images/Items/Tape";
    public const string ITEM_DRIVER_IMAGENAME   = "Images/Items/Driver";
    public const string ITEM_TOILETPAPER_IMAGENAME = "Images/Items/ToiletPaper";
    public const string ITEM_ICEBLOCK_IMAGENAME    = "Images/Items/IceBlock";
    public const string ITEM_KEYINICE_IMAGENAME    = "Images/Items/KeyInIce";
    public const string ITEM_MYSTERYPAPER_IMAGENAME = "Images/Items/MysteryPaper";
    public const string ITEM_DYNAMITE_IMAGENAME     = "Images/Items/Dynamite";
    public const string ITEM_MEDICINE_IMAGENAME = "Images/Items/Medicine";
    public const string ITEM_MYSTERYPAPERENTRANCE_IMAGENAME = "Images/Items/MysteryPaperEntrance";
    public const string ITEM_TESTDRUG_IMAGENAME             = "Images/Items/TestDrug";
    public const string ITEM_LONGASAHIMO_IMAGENAME          = "Images/Items/LongAsahimo";
    public const string ITEM_SABISCISSORS_IMAGENAME         = "Images/Items/Scissors_2";
    public const string ITEM_MYSTERYPAPERSOUKO_IMAGENAME    = "Images/Items/MysteryPaperSouko";
    public const string ITEM_MATERNITYHANDBOOK_IMAGENAME    = "Images/Items/MaternityBook";

    // マップ説明
    public const string MAP_GENKAN_EXPLAIN = "ここは玄関のようだ。　　　　　　　扉がある。";
    public const string MAP_SYOSAI_EXPLAIN = "ここは書斎のようだ。　　　　　　　たくさんの本がある。";
    public const string MAP_TOILET_EXPLAIN = "ここはトイレのようだ。　　　　　　どこか違和感を感じる。";
    public const string MAP_ROUKA_EXPLAIN = "ここは廊下のようだ。　　　　　　　奥に玄関の扉が見える。";
    public const string MAP_BEDROOM_EXPLAIN = "ここは寝室のようだ。　　　　　　　タンスは動かせそうにない。";
    public const string MAP_BATHROOM_EXPLAIN = "ここは浴室のようだ。　　　　　　　鏡がある。";
    public const string MAP_KITCHEN_EXPLAIN = "ここは台所のようだ。　　　　　　　ガスは通っているのだろうか。";
    public const string MAP_LIVING_EXPLAIN = "ここはリビングのようだ。　　　　　テレビに何か映っている。";
    public const string MAP_DINING_EXPLAIN = "ここはダイニングのようだ。　　　　机にあるレコードは動くようだ。";
    public const string MAP_SOUKO_EXPLAIN = "ここは倉庫のようだ。　　　　　　　外に繋がっている気がする。";
}