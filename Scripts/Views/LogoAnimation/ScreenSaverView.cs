using System.Collections;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// スクリーンセーバ機能
/// idleTime時間無操作で動画をループ再生する
/// </summary>
public class LogoAnimationView : MonoBehaviour
{
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
    [SerializeField] private Camera _logoAnimeCamera;
    /// <summary>
    /// 再生中フラグ
    /// </summary>
    private bool _isPlaying = false;


    void Awake()
    {
        Config.SetIsOpenSettingWindow(true);
        Config.SetIsDoneLogoAnime(false);
        // カメラの設定
        _mainCamera.enabled = true;
        _logoAnimeCamera.enabled = false;
        // ムービーバッファ読み込み
        _videoPlayer.Prepare();
    }

    void Start()
    {
        _ChangeCamera(_mainCamera, _logoAnimeCamera);
        StartCoroutine(_PlayMovie());
        //_videoPlayer.loopPointReached += OnVideoEnd;
    }

    void Update()
    {
        // 一定時間の無操作で切り替える
        if (_IsHandleScreen() && _isPlaying)
        {
            _StopMovie();
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
    /// 動画よ見込み次第ムービーを再生
    /// CameraをvideoCameraに移動
    /// </summary>
    private IEnumerator _PlayMovie()
    {
        while (!_videoPlayer.isPrepared)
            yield return null;

        _isPlaying = true;
        _videoPlayer.Play();
        yield return new WaitForSeconds((float)_videoPlayer.length);
        _isPlaying = false;

        // ムービー再生が終わったら停止
        _StopMovie();
    }

    /// <summary>
    /// フラグを更新し、ムービーの再生を停止
    /// CameraをmainCameraに移動
    /// </summary>
    private void _StopMovie()
    {
        _videoPlayer.Stop();
        _ChangeCamera(_logoAnimeCamera, _mainCamera);
        Config.SetIsOpenSettingWindow(false);
        Config.SetIsDoneLogoAnime(true);
    }

    /// <summary>
    /// ゲーム内で何らかの操作があればtrueを返す
    /// </summary>
    /// <returns>ゲーム操作中かどうか</returns>
    private bool _IsHandleScreen()
    {
        // キーボード操作チェック
        bool isKeyDown = Input.anyKeyDown;
        return isKeyDown;
    }

    /// <summary>
    /// ビデオ再生終了時、メインに移動
    /// </summary>
    void OnVideoEnd(VideoPlayer vp)
    {
        _StopMovie();
    }
}