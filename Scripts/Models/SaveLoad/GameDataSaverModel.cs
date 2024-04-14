using System;
using System.IO;
using UnityEngine;
using MVP.Sounds;
using HarapekoADV;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;

namespace MVP.Models
{
    /// <summary>
    /// ゲーム全体データのセーブロードModel
    /// </summary>
    public class GameDataSaverModel
    {
        /// <summary>
        /// 変換するデータのクラス
        /// </summary>
        private GameData _data;
        /// <summary>
        /// 現在の状態のデータ
        /// </summary>
        private GameData _currentData;
        /// <summary>
        /// ファイルのパス
        /// </summary>
        private string _filepath;
        /// <summary>
        /// ファイル名
        /// </summary>
        private string _fileName = "GameData.ijuu";

        /// <summary>
        /// ゲーム全体のデータのセーブ
        /// </summary>
        /// <returns></returns>
        public bool GameDataSave()
        {
            // ファイル名
            _fileName = "GameData.ijuu";
            
            // 読み込み処理
            #if UNITY_EDITOR
                _filepath = Application.dataPath + "/Resources/SaveFiles/GameData.ijuu";
            #elif UNITY_STANDALONE_WIN
                //EXEを実行したカレントディレクトリ
                _filepath = Application.dataPath + "/GameData.ijuu";
            #elif UNITY_STANDALONE_OSX
                //EXEを実行したカレントディレクトリ
                _filepath = Application.dataPath + "/GameData.ijuu";
            #endif

            // パスチェック
            if (_filepath == null)
            {
                Debug.Log("データファイルパスが取得できませんでした");
                return false;
            }
            
            // ゲームデータクラスのインスタンス生成
            GameData setData = new GameData();
            
            // 現在のデータを取得
            _currentData = SetConfigDataToGameData(setData);

            // データチェック
            if (_currentData == null)
            {
                Debug.Log("データが取得できませんでした");
                return false;
            }

            // ファイルが存在しない場合、ファイル作成
            FileStream fileStream = new FileStream(_filepath, FileMode.Create);

            // ファイルシリアライズ
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStream, _currentData);

            // 終了
            fileStream.Close();
            Debug.Log("セーブ完了");

            return true;
        }

        /// <summary>
        /// ゲーム全体のデータのロード
        /// </summary>
        /// <returns></returns>
        public bool GameDataLoad()
        {
            string loadFilePath = null;
            // 読み込み処理
            #if UNITY_EDITOR
                loadFilePath = Application.dataPath + "/Resources/SaveFiles/GameData.ijuu";
            #elif UNITY_STANDALONE_WIN
                //EXEを実行したカレントディレクトリ
                loadFilePath = Application.dataPath + "/GameData.ijuu";
            #elif UNITY_STANDALONE_OSX
                //EXEを実行したカレントディレクトリ
                loadFilePath = Application.dataPath + "/GameData.ijuu";
            #endif

            if (loadFilePath == null)
            {
                Debug.Log("データファイルパスが取得できませんでした");
                return false;
            }

            // ロード
            GameData loadGameData = new GameData();

            try 
            {
                // ファイルの存在チェック
                if (File.Exists(loadFilePath))
                {
                    FileStream fileStream = new FileStream(loadFilePath, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    GameData data = (GameData)bf.Deserialize(fileStream);

                    fileStream.Close();
                    loadGameData = data;
                }
                else
                {
                    Debug.Log("セーブファイルがありません");
                    loadGameData = null;
                    return false;
                }
            }
            catch (SerializationException e)
            {
                Debug.Log("ロードできませんでした");
                return false;
            } 
            finally
            {
                Debug.Log("ゲーム全体のロード処理を終了します");
            }

            // ロードしたデータを反映
            SetGameDataInfo(loadGameData);

            return true;
        }


        /// <summary>
        /// Config系に保存されている値をGameDataクラスに格納
        /// </summary>
        /// <returns></returns>
        public GameData SetConfigDataToGameData(GameData setData)
        {
            // クリアエンドをセット
            setData.goalScenarios = ADVConfig.GetGoalScenario();
            // 音量系をセット
            setData.VOLUME_BGM = SoundConfig.GetVolumeBGM();
            setData.VOLUME_SE = SoundConfig.GetVolumeSE();

            return setData;
        }

        /// <summary>
        /// ロードしたゲーム情報をセット
        /// </summary>
        /// <param name="loadData">ロードデータ</param>
        public void SetGameDataInfo(GameData loadData)
        {
            // 各種フラグのロード
            foreach (string end in loadData.goalScenarios)
            {
                ADVConfig.SetGoalScenario(end);
                Debug.Log("保存されたEND:"+end);
            }
            SoundConfig.SetVolumeBGM(loadData.VOLUME_BGM);
            SoundConfig.SetVolumeSE(loadData.VOLUME_SE);
        }
    }
}