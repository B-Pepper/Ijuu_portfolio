using System;
using System.IO;
using UnityEngine;
using MVP.Presenters;
using MVP.Views;

namespace MVP.Views
{
    /// <summary>
    /// データの書き出し、読み込みクラスのModel
    /// </summary>
    public class DataSaverView : MonoBehaviour
    {
        /// <summary>
        /// Presenterのインスタンス
        /// </summary>
        private DataSaverPresenter _dataSaverPresenter;

        /// <summary>
        /// データスロット更新用のインスタンス
        /// </summary>
        [SerializeField] private SelectDataSlotView _selectDataSlotView;

        /// <summary>
        /// 初期化処理のインスタンス
        /// </summary>
        [SerializeField] private InitializeGameInfoView _initializeGameInfoView;

        /// <summary>
        /// シーン遷移処理のインスタンス
        /// </summary>
        [SerializeField] private FromGamePlaceButtonView _fromGamePlaceButtonView;

        /// <summary>
        /// セーブ後のパネル遷移処理のインスタンス
        /// </summary>
        [SerializeField] private ChangePanelButtonView _changePanelButtonView;

        private void Awake() {
            _dataSaverPresenter = new DataSaverPresenter();
        }

        /// <summary>
        /// セーブボタン押下時
        /// </summary>
        public void OnSaveClick()
        {
            // 選択されたデータスロット番号を格納
            int saveDataNum = Config.GetSelectDataSlotNum();
            if (DataSave(saveDataNum))
            {
                // データスロットを更新
                _selectDataSlotView.UpdSaveSlotInfo();
                // セーブ確認画面非表示、セーブ完了画面を表示
                _changePanelButtonView.Onclick();
            }
        }

        /// <summary>
        /// ロードボタン押下時
        /// </summary>
        public void OnLoadClick()
        {
            // 選択されたデータスロット番号を格納
            int loadDataNum = Config.GetSelectDataSlotNum();
            string loadFilePath = null;

            // 読み込み処理
            #if UNITY_EDITOR
                loadFilePath = Application.dataPath + "/Resources/SaveFiles/SaveData" + loadDataNum + ".ijuu";
            #elif UNITY_STANDALONE_WIN
                //EXEを実行したカレントディレクトリ
                loadFilePath = Application.dataPath + "/SaveData" + loadDataNum + ".ijuu";
            #elif UNITY_STANDALONE_OSX
                //EXEを実行したカレントディレクトリ
                loadFilePath = Application.dataPath + "/SaveData" + loadDataNum + ".ijuu";
            #endif
                Debug.Log("ロードしたファイルパス"+loadFilePath);
            SaveData loadData = DataLoad(loadFilePath);

            // データが存在する時
            if (loadData != null)
            {
                _initializeGameInfoView.LoadGameInfo(loadData);
                // Unity全体のシーン番号に-1した数をConfigに格納しているため、+1する
                _fromGamePlaceButtonView.OnClick(Config.GetCurrentSceneNum()+1);
            }
            else
            {
                // ロード確認画面非表示、ロード失敗画面を表示
                _changePanelButtonView.Onclick();
            }
        }

        /// <summary>
        /// セーブ(ファイル出力)処理
        /// </summary>
        /// <param name="saveDataNum">スロット番号</param>
        public bool DataSave(int saveDataNum)
        {
            return _dataSaverPresenter.DataSave(saveDataNum);
        }

        /// <summary>
        /// ファイル読み込み
        /// </summary>
        /// <param name="path">セーブデータファイルのパス</param>
        public SaveData DataLoad(string path)
        {
            return _dataSaverPresenter.DataLoad(path);
        }
    }
}