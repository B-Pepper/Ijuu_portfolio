namespace MVP.Sounds
{
    /// <summary>
    /// SEの番号対応表
    /// </summary>
    public enum SEType
    {
        /// <summary>
        /// 効果音なし
        /// </summary>
        None = -1,
        /// <summary>
        /// ガチャ(軽め)
        /// </summary>
        GachaLight = 0,
        /// <summary>
        /// ガチャ
        /// </summary>
        Gacha = 1,
        /// <summary>
        /// ガチャガチャ
        /// </summary>
        GachaGacha = 2,
        /// <summary>
        /// 歩く
        /// </summary>
        StepNormal = 3,
        /// <summary>
        /// 走る
        /// </summary>
        StepFast = 4,
        /// <summary>
        /// 歩く(長い)
        /// </summary>
        StepLong = 5,
        /// <summary>
        /// タップ
        /// </summary>
        Tap = 6,
        /// <summary>
        /// タップ(移動時)
        /// </summary>
        TapMove = 7,
        /// <summary>
        /// エラー
        /// </summary>
        Error = 8,
        /// <summary>
        /// クローゼット開け
        /// </summary>
        OpenCloset = 9,
        /// <summary>
        /// クローゼット閉め
        /// </summary>
        CloseCloset = 10,
        /// <summary>
        /// 冷蔵庫開け
        /// </summary>
        OpenFreezer = 11,
        /// <summary>
        /// 冷蔵庫閉め
        /// </summary>
        CloseFreezer = 12,
        /// <summary>
        /// お風呂ドア
        /// </summary>
        OpenBathRoom = 13,
        /// <summary>
        /// ロック
        /// </summary>
        Lock = 14,
        /// <summary>
        /// 爆発音(直撃)
        /// </summary>
        BoomDirect = 15,
        /// <summary>
        /// 爆発音(倉庫)
        /// </summary>
        BoomStockRoom = 16,
        /// <summary>
        /// チッチッチッ
        /// </summary>
        TikTikTik = 17,
        /// <summary>
        /// 排水音
        /// </summary>
        DrainWater = 18,
        /// <summary>
        /// 空腹音(ぐ〜)
        /// </summary>
        Hungry = 19,
        /// <summary>
        /// サイレン
        /// </summary>
        Siren = 20,
        /// <summary>
        /// 火(ボウっ)
        /// </summary>
        Crinkle = 21,
        /// <summary>
        /// 戻る
        /// </summary>
        Back = 22,
        /// <summary>
        /// 銃声
        /// </summary>
        Gun = 23,
        /// <summary>
        /// 銃乱射
        /// </summary>
        GunBurst = 24,
        /// <summary>
        /// UI操作音
        /// </summary>
        HandleUI = 25,
        /// <summary>
        /// チェーンカット
        /// </summary>
        CutChain = 26,
        /// <summary>
        /// ハサミカット
        /// </summary>
        ScissorsCutting = 27,
        /// <summary>
        /// テープ
        /// </summary>
        Tape = 28,
        /// <summary>
        /// チャリン
        /// </summary>
        Charin = 28
    }
}