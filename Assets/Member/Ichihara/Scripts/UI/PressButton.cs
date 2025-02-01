using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public void ChangeTitle()
    {
        SceneChangeManager.Instance.CallChangeScene(SceneChangeManager.Instance.SceneNames[0]);
    }

    public void ChangeMainGame()
    {
        SceneChangeManager.Instance.CallChangeScene(SceneChangeManager.Instance.SceneNames[1]);
    }
}
