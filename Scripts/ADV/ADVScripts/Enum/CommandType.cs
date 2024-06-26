namespace HarapekoADV.Commands
{
    /// <summary>
    /// TEXT TEXTの表示、バックログへの追加(未実装)
    /// END ADV再生の終了
    /// ERR エラーの表示
    /// IMG_ADD 画像の登録
    /// IMG_DISPLAY 登録済みの画像の表示
    /// BG_ADD 背景画像の登録
    /// BG_CHANGE 背景画像の変更
    /// </summary>
    public enum CommandType
    {
        TEXT,
        END,
        ERR,
        CHARACTER_CHANGE,
        BG_CHANGE,
        SE_PLAY,
        SE_STOP,
        BGM_PLAY,
        BGM_CHANGE,
        BGM_STOP,
        NAME_CHANGE
    }
}