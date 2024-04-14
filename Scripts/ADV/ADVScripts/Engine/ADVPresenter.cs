using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HarapekoADV.Scenarios;
using HarapekoADV.Commands;
using HarapekoADV.Images;
using HarapekoADV.Sounds;
using UniRx;

namespace HarapekoADV
{
    /// <summary>
    /// ADVのPresenter
    /// </summary>
    public class ADVPresenter
    {
        /// <summary>
        /// Presenterのインスタンス
        /// </summary>
        private static ADVPresenter instance;
        
        /// <summary>
        /// Modelのインスタンス
        /// </summary>
        private ADVModel _model;

        private ADVView _view;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ADVPresenter(ADVView view)
        {
            _model = new ADVModel();
            _view = view;
            // モデルから通知を受け取って検知したら実行
            _model.FinishObservable.Subscribe(_ => OnFinishCalled());
        }

        /// <summary>
        /// ADVパート再生部の初期化
        /// </summary>
        public void InitADV()
        {
            _model.InitADV();
        }

        /// <summary>
        /// インスタンスのゲッター
        /// </summary>
        /// <returns>Presenterのインスタンス</returns>
        public static ADVPresenter GetInstance()
        {
            if (instance == null)
            {
                Debugger.Log("ADVPresenter instance not found");
            }
            return instance;
        }

        /// <summary>
        /// 文字列、コマンドを取得する
        /// </summary>
        /// <returns>次の文字列、コマンド</returns>
        public Commands.Command GetCommand()
        {
            return _model.GetCommand();
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
            _model.ExecCommand(text, charaName, characterImage, backgroundImage);
        }

        /// <summary>
        /// ADV終了
        /// </summary>
        public void OnFinishCalled()
        {
            _view.NotifyADVFinish();
        }

        /// <summary>
        /// テキストのセッター
        /// </summary>
        /// <param name="text">テキスト</param>
        public void SetText(TMP_Text mainText,string text)
        {
            _model.SetText(mainText, text);
        }

        /// <summary>
        /// 背景のセッター
        /// </summary>
        /// <param name="backgroundImage">変更先</param>
        /// <param name="bg">変更画像</param>
        public void SetBackGround(Image backgroundImage, Image bg)
        {
            _model.SetBackGround(backgroundImage, bg);
        }
    }

}