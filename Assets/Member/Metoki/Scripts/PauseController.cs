using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseImage;
    public void ShowImage()
    {
        _pauseImage.SetActive(true);//Pause‰æ–Ê•\Ž¦
    }
    public void CloseImage()
    {
        _pauseImage.SetActive(false);
    }
}
