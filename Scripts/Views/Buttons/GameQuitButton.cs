using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Sounds;
using MVP.Presenters;

namespace MVP.Views
{
    /// <summary>
    /// ゲーム終了時の挙動
    /// </summary>
    public class GameQuitButton : MonoBehaviour
    {
        /// <summary>
        /// ボタン押下時のSE
        /// </summary>
        [SerializeField] private SEType _seId = SEType.GachaLight;
        

        /// <summary>
        /// ゲーム終了
        /// </summary>
        public void OnClick()
        {
            StartCoroutine(Quit());
        }

        /// <summary>
        /// 終了コルーチン
        /// </summary>
        /// <returns>コルーチン</returns>
        private IEnumerator Quit()
        {
            // ゲーム全体データのロード
            GameDataSaverPresenter gameDataSaverPresenter = new GameDataSaverPresenter();
            if (gameDataSaverPresenter.GameDataSave())
            {
                Debug.Log("ゲーム全体の情報のセーブができました");
            }
            SoundManageView.GetInstance().PlaySE((int)_seId);
            yield return new WaitForSeconds(1f);
            Application.Quit();
        }
    }
}
