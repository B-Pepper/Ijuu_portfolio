using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MVP.Presenters;
using MVP.Views;

namespace MVP.Views
{
    /// <summary>
    /// 選択されたデータスロットに情報を表示する機能View
    /// </summary>
    public class SelectDataSlotView : MonoBehaviour
    {
        // Awake時に3つのファイルをロード
        // セーブされている、currentSceneNum と 日付　を取得
        // currentSceneNumから場所の画像を取得して表示
        // 日付を表示

        /// <summary>
        /// データセーブ処理インスタンス
        /// </summary>
        private DataSaverPresenter _dataSaverPresenter = new DataSaverPresenter();

        /// <summary>
        /// 現在シーンの画像
        /// </summary>
        [SerializeField] private Image[] _currentSceneImage;

        /// <summary>
        /// 日付
        /// </summary>
        [SerializeField] private TMP_Text[] _date;

        /// <summary>
        /// 各シーン画像
        /// 0:玄関
        /// 1:書斎
        /// 2:トイレ
        /// 3:廊下
        /// 4:寝室
        /// 5:バスルーム
        /// 6:台所
        /// 7:リビング
        /// 8:ダイニング
        /// 9:倉庫
        /// 10:爆破後寝室
        /// </summary>
        [SerializeField] private Image[] _sceneImages;

        /// <summary>
        /// データが無い時に表示するテキスト
        /// </summary>
        [SerializeField] private string _noData = "NO DATA";

        /// <summary>
        /// データファイル番号の最大値
        /// </summary>
        private const int DATAFILE_MAXNUM = 3;

        /// <summary>
        /// 爆破後の寝室シーン番号
        /// </summary>
        private const int SCENE_IMAGE_BEDROOM_BOMB = 10;

        /// <summary>
        /// セーブデータを取得するインスタンス
        /// </summary>
        private SaveData[] saveDatas = new SaveData[DATAFILE_MAXNUM];

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void OnEnable()
        {
            UpdSaveSlotInfo();
        }

        /// <summary>
        /// データスロットの情報を更新
        /// </summary>
        public void UpdSaveSlotInfo()
        {
            string loadFilePath = null;
            for (int i = 0; i < DATAFILE_MAXNUM; i++)
            {
                // ファイルパス取得処理
                #if UNITY_EDITOR
                    loadFilePath = Application.dataPath + "/Resources/SaveFiles/SaveData" + i + ".ijuu";
                #elif UNITY_STANDALONE_WIN
                    //EXEを実行したカレントディレクトリ
                    loadFilePath = Application.dataPath + "/SaveData" + i + ".ijuu";
                #elif UNITY_STANDALONE_OSX
                    //EXEを実行したカレントディレクトリ
                    loadFilePath = Application.dataPath + "/SaveData" + i + ".ijuu";
                #endif

                // データをロード
                if (_dataSaverPresenter.DataLoad(loadFilePath) != null)
                {
                    saveDatas[i] = _dataSaverPresenter.DataLoad(loadFilePath);
                    Debug.Log("ファイル"+ i +": ロード完了");
                }
                
                if (saveDatas[i] != null)
                {
                    SetSceneImage(i, saveDatas[i].currentSceneNum, saveDatas[i].bedroomStatus);
                    Debug.Log("寝室のステータス: "+saveDatas[i].bedroomStatus);
                    SetText(i, saveDatas[i].playTime);
                }
                else
                {
                    _currentSceneImage[i].sprite = null;
                    // データが無い時に表示
                    _date[i].text = _noData;
                }
            }
        }

        /// <summary>
        /// セーブスロットのシーン画像をセット
        /// </summary>
        /// <param name="num">配列の要素番号</param>
        /// <param name="sceneNum">シーン番号</param>
        /// <param name="bedroomStatus">寝室のステータス</param>
        private void SetSceneImage(int num,int sceneNum, int bedroomStatus)
        {
            // 寝室が爆破されている時
            if (bedroomStatus >= GimmickConstant.BEDROOM_STATUS_BOMB)
            {
                _currentSceneImage[num].sprite = _sceneImages[SCENE_IMAGE_BEDROOM_BOMB].sprite;
                Debug.Log("爆破画像セット");
            }
            else
            {
                _currentSceneImage[num].sprite = _sceneImages[sceneNum].sprite;
            }
        }

        /// <summary>
        /// セーブスロットの日付をセット
        /// </summary>
        /// <param name="num">配列の要素番号</param>
        /// <param name="date">日付</param>
        private void SetText(int num, string date)
        {
            _date[num].text = date;
        }
    }
}