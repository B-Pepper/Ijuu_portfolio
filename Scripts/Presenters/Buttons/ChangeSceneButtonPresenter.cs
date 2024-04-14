using UnityEngine.SceneManagement;
using MVP.Models;

namespace MVP.Presenters
{
    /// <summary>
    /// シーン遷移のPresenter
    /// </summary>
    public class ChangeScenePresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private ChangeSceneModel _model;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ChangeScenePresenter()
        {
            _model = new ChangeSceneModel();
        }
        /// <summary>
        /// シーン遷移処理
        /// </summary>
        /// <param name="sceneNumber">シーン番号</param>
        public void MoveScene(int sceneNumber)
        {
            SceneManager.LoadScene(_model.GetSceneNumber(sceneNumber));
        }

        // 以下実装予定機能
        // シーン遷移時にSE
        // シーン遷移時に画面切り替え演出
    }
}