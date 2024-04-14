using MVP.Presenters;
using HarapekoADV;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Views
{
    /// <summary>
    /// シーン切り替えを行うためのView
    /// </summary>
    public class DebugButtonView:MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private ChangeScenePresenter _presenter;

        [SerializeField] private EndTextType _toEndType;

        /// <summary>
        /// プレゼンタ初期化
        /// </summary>
        public DebugButtonView()
        {
            _presenter = new ChangeScenePresenter();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="sceneNumber">シーン番号</param>
        public void OnClick()
        {
            ADVConfig.SetScenarioName(_toEndType);
            _presenter.MoveScene(11);
        }

    }
}