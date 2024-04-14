using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HarapekoADV.Scenarios;
using MVP.Presenters;
using MVP.Views;
using MVP.Sounds;

namespace HarapekoADV
{
    /// <summary>
    /// ADVのView
    /// </summary>
    public class ADVView : MonoBehaviour, ADVNotifier
    {
        /// <summary>
        /// ADVのPresenterのインスタンス
        /// </summary>
        private static ADVPresenter _presenter;

        /// <summary>
        /// メインテキスト
        /// </summary>
        [SerializeField] private TMP_Text _mainText;

        /// <summary>
        /// キャラクターの名前
        /// </summary>
        [SerializeField] private TMP_Text _charaName;

        /// <summary>
        /// 立ち絵画像
        /// </summary>
        [SerializeField] private Image _characterImage;
        
        /// <summary>
        /// 背景画像
        /// </summary>
        [SerializeField] private Image _backgroundImage;

        /// <summary>
        /// フェードパネル
        /// </summary>
        [SerializeField] private GameObject _fadePanel;

        /// <summary>
        /// シーン遷移用
        /// </summary>
        private FromGamePlaceView _fromGamePlaceView;

        /// <summary>
        /// タイトルシーン番号
        /// </summary>
        private int _titleSceneNum = 0;

        /// <summary>
        /// ADVシーン遷移時の初回ロード
        /// false : 未ロード true : ロード済
        /// </summary>
        private bool _firstLoad = false;

        /// <summary>
        /// Presenterのインスタンス
        /// </summary>
        private DataSaverPresenter _dataSaverPresenter;

        /// <summary>
        /// ADV起動時
        /// </summary>
        private void Awake()
        {
            InitText();
            _presenter = new ADVPresenter(this);
            _firstLoad = false;
            _fromGamePlaceView = new FromGamePlaceView();
        }
        
        /// <summary>
        /// ADVパート再生部の初期化
        /// </summary>
        /// 
        public void InitADV()
        {
            _presenter.InitADV();
        }

        /// <summary>
        /// テキスト初期化
        /// </summary>
        public void InitText()
        {
            _mainText.text = "";
        }

        /// <summary>
        /// ロード終了を待機、1度だけロード
        /// </summary>
        private void Update()
        {
            if (ADVConfig.GetLoadStatus() == LoadStatus.End && !_firstLoad)
            {
                ExecCommand();
                _firstLoad = true;
            }
        }

        /// <summary>
        /// クリック時に文字列、コマンドを読み込む
        /// </summary>
        public void OnClick()
        {
            if (ADVConfig.GetLoadStatus() == LoadStatus.End)
            {
                ExecCommand();
            }
        }

        /// <summary>
        /// 次の行のコマンドを実行
        /// </summary>
        private void ExecCommand()
        {
            _presenter.ExecCommand(_mainText, _charaName, _characterImage, _backgroundImage);
        }

        /// <summary>
        /// テキストのセッター
        /// </summary>
        /// <param name="text">テキスト</param>
        public void SetText(string text)
        {
            _presenter.SetText(_mainText, text);
        }

        /// <summary>
        /// 背景のセッター
        /// /// </summary>
        /// <param name="bg">Imageクラス</param>
        public void SetBG(Image bg)
        {
            _presenter.SetBackGround(_backgroundImage, bg);
        }

        /// <summary>
        /// ADV開始通知
        /// </summary>
        public void NotifyADVStart()
        {
            Debugger.Log("Start");
        }

        /// <summary>
        /// ADV終了通知
        /// </summary>
        public void NotifyADVFinish()
        {
            Debugger.Log("Finish");
            // ゲームデータを保存するインスタンス
            GameDataSaverView gameDataSaverView = new GameDataSaverView();

            // クリアしたエンドを保存
            ADVConfig.SetGoalScenario(ADVConfig.GetScenarioName());

            // セーブ成功時にゲーム全体にデータを反映
            if (gameDataSaverView.GameDataSave())
            {
                gameDataSaverView.GameDataLoad();
            }

            /* STEAM対応必須箇所 */
            // 初めてクリアしたエンドの場合、実績解除
            /* STEAM対応必須箇所 */

            // タイトルシーン遷移
            _fromGamePlaceView.OnClick(_titleSceneNum, _fadePanel, SEType.None, 2.0f);
        }
    }
}
