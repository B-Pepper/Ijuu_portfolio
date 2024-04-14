using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //DateTimeを使用する為追加。

/// <summary>
/// プレイヤーの情報を取得するクラス
/// </summary>
public class Player
{
    /// <summary>
    /// プレイ日時
    /// </summary>
    private string _playTime = "0000年00月00日00:00:00";

    /// <summary>
    /// プレイ日時の初期化
    /// </summary>
    public void InitPlayTime()
    {
        _playTime = "0000年00月00日00:00:00";
        Config.SetPlayTime(_playTime);
    }

    /// <summary>
    /// 現時点のプレイ時間をセーブ
    /// </summary>
    public void SaveTime()
    {
        // 現在の日時を取得
        DateTime TodayNow = DateTime.Now;
        // 年、月、日を取得
        int year = TodayNow.Year;
        int month = TodayNow.Month;
        int day = TodayNow.Day;

        string _playTime = year.ToString() + "年 " + month.ToString() + "月" + day.ToString() + "日" + DateTime.Now.ToLongTimeString();
        Config.SetPlayTime(_playTime);
        Debug.Log("プレイ日時："+_playTime);
    }
}
