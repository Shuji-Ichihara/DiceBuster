using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : SingletonMonoBehaviour<SceneChangeManager>
{
    // 遷移するシーンアセットの名称
    private string[] _sceneNames = new string[] { };

    // 
    [SerializeField]
    private FadeController _controller = null;

    // Start is called before the first frame update
    void Start()
    {
        int dummySceneCount = SceneManager.sceneCountInBuildSettings;
        _sceneNames = new string[dummySceneCount];
        // BuildSettingsから読み込むシーンの名称を取得し、配列に格納する
        for (int NumberOfScenes = 0; NumberOfScenes < dummySceneCount; NumberOfScenes++)
        {
            string scenePath = EditorBuildSettings.scenes[NumberOfScenes].path;
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            _sceneNames[NumberOfScenes] = sceneName;
        }
        DontDestroyOnLoad(gameObject);
        _controller.FadeOutWrap().Forget();
    }

    private void Update()
    {
        /* テストコード 
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CallChangeScene(_sceneNames[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            CallChangeScene(_sceneNames[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            CallChangeScene(_sceneNames[2]);
        */
    }

    /// <summary>
    /// ChangeSceneのラッパー関数及びシーン遷移の演出を記述する
    /// 外部から呼び出す場合はこちらを使用する
    /// </summary>
    /// <param name="sceneName">次に読み込むシーンの名称</param>
    public async void CallChangeScene(string sceneName)
    {
        await _controller.FadeInWrap();
        await ChangeScene(sceneName);
        await _controller.FadeOutWrap();
    }


    /// <summary>
    /// シーンを読み込む
    /// </summary>
    /// <param name="sceneName">次に読み込むシーンの名称</param>
    /// <returns></returns>
    private async UniTask ChangeScene(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName);
    }
}
