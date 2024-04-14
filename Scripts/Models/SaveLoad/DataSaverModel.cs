using System;
using System.IO;
using UnityEngine;
using MVP.Sounds;
using HarapekoADV;
using System.Runtime.Serialization.Formatters.Binary;

namespace MVP.Models
{
    /// <summary>
    /// データの書き出し、読み込みクラスのModel
    /// </summary>
    public class DataSaverModel
    {
        /// <summary>
        /// json変換するデータのクラス
        /// </summary>
        private SaveData _data;
        /// <summary>
        /// 現在の状態のデータ
        /// </summary>
        private SaveData _currentData;
        /// <summary>
        /// jsonファイルのパス
        /// </summary>
        private string _filepath;
        /// <summary>
        /// jsonファイル名
        /// </summary>
        private string _fileName = "SaveData.json";

        /// <summary>
        /// セーブ(ファイル出力)処理
        /// </summary>
        /// <param name="saveDataNum">スロット番号</param>
        public bool DataSave(int saveDataNum)
        {
            // jsonファイル名
            _fileName = "SaveData" + saveDataNum + ".ijuu";
            
            /* STEAM対応必須箇所 */
            // 読み込み処理
            #if UNITY_EDITOR
                _filepath = Application.dataPath + "/Resources/SaveFiles/SaveData" + saveDataNum + ".ijuu";
            #elif UNITY_STANDALONE_WIN
                //EXEを実行したカレントディレクトリ
                _filepath = Application.dataPath + "/SaveData" + saveDataNum + ".ijuu";
            #elif UNITY_STANDALONE_OSX
                //EXEを実行したカレントディレクトリ
                _filepath = Application.dataPath + "/SaveData" + saveDataNum + ".ijuu";
            #endif
                Debug.Log("セーブデータファイルパス: "+ _filepath);

            /* STEAM対応必須箇所 */

            if (_filepath == null)
            {
                Debug.Log("セーブデータファイルパスが取得できませんでした");
                return false;
            }
            
            Debug.Log("セーブデータファイルパス 生成完了");
            
            // セーブデータクラスのインスタンス生成
            SaveData setData = new SaveData();
            
            // 現在のデータを取得
            _currentData = SetConfigDataToSaveData(setData);

            if (_currentData == null)
            {
                Debug.Log("データが取得できませんでした");
                return false;
            }

            Debug.Log("データ 取得完了");

            // ファイルが存在しない場合、ファイル作成
            FileStream fileStream = new FileStream(_filepath, FileMode.Create);
            Debug.Log("ファイル 生成完了");

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStream, _currentData);
            Debug.Log("ファイル 書き込み完了");

            fileStream.Close();
            Debug.Log("セーブ完了");

            return true;
        }

        /// <summary>
        /// jsonファイル読み込み
        /// </summary>
        /// <param name="path">セーブデータファイルのパス</param>
        public SaveData DataLoad(string path)
        {
            Debug.Log("ファイルパス取得: "+path);
            if (File.Exists(path))
            {
                Debug.Log("ファイル検索完了");
                FileStream fileStream = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                SaveData data = (SaveData)bf.Deserialize(fileStream);
                Debug.Log("ファイルロード中");

                fileStream.Close();
                Debug.Log("ロード完了");
                return data;
            }
            else
            {
                Debug.Log("セーブファイルがありません");
                return null;
            }
        }

        /// <summary>
        /// Config系に保存されている値をSaveDataクラスのに格納
        /// </summary>
        /// <returns></returns>
        public SaveData SetConfigDataToSaveData(SaveData setData)
        {
            for(int i = 0; i < Config.GetAllItemStatus().Length; i++)
            {
                // アイテムのステータスをセット
                setData.itemStatus[i] = Config.GetItemStatus(i);
                // ギミックのステータスをセット
                setData.gimmickStatus[i] = Config.GetGimmickStatus(i);
                // アイテム名をセット
                setData.itemName[i] = Config.GetItemName(i);
                // アイテム説明をセット
                setData.itemExplain[i] = Config.GetItemExplain(i);
            }
            // 各種フラグのセット
            setData.isOpenSettingWindow = Config.GetIsOpenSettingWindow();
            setData.isOpenBedRoomChest = Config.GetIsOpenBedRoomChest();
            setData.isOpenDialog = Config.GetIsOpenDialog();
            setData.isSetDynamite = Config.GetIsSetDynamite();
            setData.isPlayBGM = SoundConfig.GetIsPlayBGM();
            setData.bedroomStatus = Config.GetBedroomStatus();

            // 現在のシーン
            setData.currentSceneNum = Config.GetCurrentSceneNum();

            // 現在のプレイ日時をセット
            Player player = new Player();
            player.SaveTime();
            setData.playTime = Config.GetPlayTime();

            // 移動回数
            setData.countStepNum = Config.GetCountStepNum();

            return setData;
        }
    }
}