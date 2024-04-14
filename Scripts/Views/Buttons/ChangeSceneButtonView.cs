using System;
using UnityEngine;
using MVP.Presenters;
namespace MVP.Views
{
    /// <summary>
    /// シーン遷移ボタンのView
    /// </summary>
    public class ChangeSceneButtonView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private ChangeSceneView _changeSceneView;

        // Start is called before the first frame update
        void Awake()
        {
            _changeSceneView = new ChangeSceneView();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="sceneNumber">シーン番号</param>
        public void OnClick(int sceneNumber)
        {
            _changeSceneView.OnClick(sceneNumber);
        }
    }
}