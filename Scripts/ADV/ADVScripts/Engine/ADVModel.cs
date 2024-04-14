using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HarapekoADV.Scenarios;
using HarapekoADV.Commands;
using UniRx;
using System;

namespace HarapekoADV
{
    /// <summary>
    /// ADVのModel
    /// </summary>
    public class ADVModel
    {
        /// <summary>
        /// シナリオクラスのインスタンス
        /// </summary>
        private Scenario _scenario;

        /// <summary>
        /// UniRX Observe
        /// </summary>
        /// <typeparam name="Unit">変更通知用のオブザーバーSubject</typeparam>
        /// <returns></returns>
        private Subject<Unit> finishSubject = new Subject<Unit>();

        /// <summary>
        /// Observer通知用関数
        /// </summary>
        public IObservable<Unit> FinishObservable => finishSubject;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ADVModel()
        {
            InitADV();
        }

        /// <summary>
        /// ADVパート再生部の初期化
        /// </summary>
        public void InitADV()
        {
            ADVStart();
        }

        /// <summary>
        /// ADV開始時の処理
        /// </summary>
        public async void ADVStart()
        {
            ADVConfig.SetLoadStatus(LoadStatus.Loading);
            ScenarioAnalyser analyser = new ScenarioAnalyser();
            var asyncEnumerator = analyser.TextFileLoad(ADVConfig.GetScenarioName());
            TextAsset asset = null;
            while(await asyncEnumerator.MoveNextAsync())
            {
                // ここでなにかおきる
                asset = asyncEnumerator.Current;
            }
            ADVConfig.SetLoadStatus(LoadStatus.End);
            Debug.Log("ファイルの中身: " + asset);
            _scenario = analyser.Create();
        }
        
        /// <summary>
        /// ADV終了時の処理
        /// </summary>
        public void ADVFinish()
        {
            // ADV終了を通知
            finishSubject.OnNext(Unit.Default);
        }

        /// <summary>
        /// 文字列、コマンドを取得する
        /// </summary>
        /// <returns>次の文字列、コマンド</returns>
        public Command GetCommand()
        {
            return _scenario.GetNext();
        }

        /// <summary>
        /// 次の行のコマンドを実行
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="backgroundImage">背景画像</param>
        public void ExecCommand(TMP_Text text, TMP_Text charaName, Image characterImage, Image backgroundImage)
        {
            Command command = GetCommand();
            if (command == null)
            {
                Debugger.Err("Command is Null");
            }
            // ストラテジ毎の処理を実行
            command.Act(text, charaName, characterImage, backgroundImage);

            while (command.CommandType != CommandType.TEXT && command.CommandType != CommandType.END)
            {
                command = GetCommand();
                command.Act(text, charaName, characterImage, backgroundImage);
            }

            if (command.CommandType == CommandType.END)
            {
                ADVFinish();
            }
        }

        /// <summary>
        /// テキストのセッター
        /// </summary>
        /// <param name="text">テキスト</param>
        public void SetText(TMP_Text mainText, string text)
        {
            mainText.text = text;
        }

        /// <summary>
        /// 背景のセッター
        /// </summary>
        /// <param name="backgroundImage">変更先</param>
        /// <param name="bg">変更画像</param>
        public void SetBackGround(Image backgroundImage, Image bg)
        {
            backgroundImage.sprite = bg.sprite;
        }
    }

}
