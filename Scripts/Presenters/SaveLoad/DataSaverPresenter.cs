using System.IO;
using UnityEngine;
using MVP.Models;
using MVP.Presenters;

namespace MVP.Presenters
{
    /// <summary>
    /// データの書き出し、読み込みクラスのModel
    /// </summary>
    public class DataSaverPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private DataSaverModel _dataSaverModel;

        public DataSaverPresenter()
        {
            _dataSaverModel = new DataSaverModel();
        }

        /// <summary>
        /// セーブ(ファイル出力)処理
        /// </summary>
        /// <param name="saveDataNum">スロット番号</param>
        public bool DataSave(int saveDataNum)
        {
            return _dataSaverModel.DataSave(saveDataNum);
        }

        /// <summary>
        /// jsonファイル読み込み
        /// </summary>
        /// <param name="path">セーブデータファイルのパス</param>
        public SaveData DataLoad(string path)
        {
            return _dataSaverModel.DataLoad(path);
        }
    }
}