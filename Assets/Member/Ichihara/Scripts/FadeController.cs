using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : SingletonMonoBehaviour<FadeController>
{
    [SerializeField]
    private Image _fadeImage = null;

    [Header("フェードする秒数"), SerializeField]
    private float _fadeSecond = 2f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// FadeInのラッパー関数
    /// </summary>
    /// <returns></returns>
    public async UniTask FadeInWrap()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        //FadeIn(cts).Forget();
        await FadeIn(cts);
    }

    /// <summary>
    /// フェードイン
    /// </summary>
    /// <param name="cts"></param>
    /// <returns></returns>
    private async UniTask FadeIn(CancellationTokenSource cts)
    {
        var imageColor = _fadeImage.color;
        try
        {
            while (imageColor.a < 1f)
            {
                imageColor.a += Time.deltaTime / _fadeSecond;
                _fadeImage.color = imageColor;
                await UniTask.Yield();
                if (_fadeImage.color.a > 1f)
                {
                    imageColor.a = 1f;
                    _fadeImage.color = imageColor;
                }
            }
        }
        catch (OperationCanceledException)
        {
            throw;
        }
    }

    /// <summary>
    /// FadeOutのラッパー関数
    /// </summary>
    /// <returns></returns>
    public async UniTask FadeOutWrap()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        //FadeOut(cts).Forget();
        await FadeOut(cts);
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    /// <param name="cts"></param>
    /// <returns></returns>
    private async UniTask FadeOut(CancellationTokenSource cts)
    {
        var imageColor = _fadeImage.color;
        try
        {
            while (imageColor.a > 0f)
            {
                imageColor.a -= Time.deltaTime / _fadeSecond;
                _fadeImage.color = imageColor;
                await UniTask.Yield();
                if (_fadeImage.color.a < 0f)
                {
                    imageColor.a = 0f;
                    _fadeImage.color = imageColor;
                }
            }
        }
        catch (OperationCanceledException)
        {
            throw;
        }
    }
}