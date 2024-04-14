using UnityEngine;
using MVP.Presenters;

namespace MVP.Views
{
    /// <summary>
    /// シーン切り替えを行うためのView
    /// </summary>
    public class ChangeSceneView
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private ChangeScenePresenter _presenter;

        /// <summary>
        /// プレゼンタ初期化
        /// </summary>
        public ChangeSceneView()
        {
            _presenter = new ChangeScenePresenter();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="sceneNumber">シーン番号</param>
        public void OnClick(int sceneNumber)
        {
            // Unity全体のシーン番号に-1した数をConfigに格納する
            Config.SetCurrentSceneNum(sceneNumber-1);
            Debug.Log("現在のシーン番号: " + Config.GetCurrentSceneNum());

            if (Config.GetIsSetDynamite())
            {
                CountSteps();
            }
            _presenter.MoveScene(sceneNumber);
        }

        /// <summary>
        /// 残り移動回数をカウント
        /// </summary>
        private void CountSteps()
        {
            //RemainingStepsView.GetInstance().MoveCounter();
        }

    }
}