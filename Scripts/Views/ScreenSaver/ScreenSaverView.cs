using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// スクリーンセーバ機能
/// idleTime時間無操作で動画をループ再生する
/// </summary>
public class ScreenSaverView : MonoBehaviour
{
    /// <summary>
    /// アイドル状態とみなす秒数
    /// </summary>
    [SerializeField] private float idleTime = 30f;
    /// <summary>
    /// 前フレームのマウス位置
    /// </summary>
    private Vector3 _mousePosition;
    /// <summary>
    /// 再生中フラグ
    /// </summary>
    private bool _isPlay;
    /// <summary>
    /// アイドル状態の時間経過
    /// </summary>
    [SerializeField] private float _timeElapsed = 0f;
    /// <summary>
    /// ビデオ素材
    /// </summary>
    [SerializeField] private VideoPlayer _videoPlayer;
    /// <summary>
    /// MainCamera
    /// </summary>
    [SerializeField] private Camera _mainCamera;
    /// <summary>
    /// VideoCamera
    /// </summary>
    [SerializeField] private Camera _videoCamera;


    void Awake()
    {
        // マウス座標の初期化
        _mousePosition = Input.mousePosition;
        // 再生中フラグの初期化
        _isPlay = false;
        // カメラの設定
        _mainCamera.enabled = true;
        _videoCamera.enabled = false;
        // ムービーバッファ読み込み
        _videoPlayer.Prepare();
    }

    void Update()
    {
        // 一定時間の無操作で切り替える
        if (_IsHandleScreen())
        {
            // 無操作時間の初期化
            _timeElapsed = 0f;
            // マウス座標の更新
            _mousePosition = Input.mousePosition;
            // スクリーンセーバ中の場合、動画を停止する
            if (_isPlay)
            {
                _StopMovie();
            }
        }
        else if (!_isPlay)
        {
            // アイドル状態の時間を更新する
            _timeElapsed += Time.deltaTime;
            // アイドル状態が一定時間以上続いた場合、動画を再生する
            if (_timeElapsed >= idleTime)
            {
                _PlayMovie();
            }
        }
    }

    /// <summary>
    /// カメラを切り替える
    /// </summary>
    /// <param name="fromCamera">切り替え前(現在の)のカメラ</param>
    /// <param name="toCamera">切り替え後のカメラ</param>
    private void _ChangeCamera(Camera fromCamera, Camera toCamera)
    {
        fromCamera.enabled = false;
        toCamera.enabled = true;
    }

    /// <summary>
    /// フラグを更新し、ムービーを再生
    /// CameraをvideoCameraに移動
    /// </summary>
    private void _PlayMovie()
    {
        _isPlay = true;
        _videoPlayer.Play();
        _ChangeCamera(_mainCamera, _videoCamera);
    }

    /// <summary>
    /// フラグを更新し、ムービーの再生を停止
    /// CameraをmainCameraに移動
    /// </summary>
    private void _StopMovie()
    {
        _isPlay = false;
        _videoPlayer.Stop();
        _ChangeCamera(_videoCamera, _mainCamera);
    }

    /// <summary>
    /// ゲーム内で何らかの操作があればtrueを返す
    /// </summary>
    /// <returns>ゲーム操作中かどうか</returns>
    private bool _IsHandleScreen()
    {
        // キーボード操作チェック
        bool isKeyDown = Input.anyKeyDown;
        // キーボード操作チェック
        bool isMove = Input.mousePosition != _mousePosition;
        // コンフィグやロード画面を開いているかどうかのフラグを取ってくる(暫定的にfalse)
        bool isOpenSettingWindow = Config.GetIsOpenSettingWindow();
        
        return isKeyDown || isMove || isOpenSettingWindow;
    }
}
