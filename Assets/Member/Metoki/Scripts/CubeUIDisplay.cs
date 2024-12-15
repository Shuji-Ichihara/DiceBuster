using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeUIDisplay : MonoBehaviour
{
    [SerializeField]
    private RawImage[] faceImages; // UI上の6つのRawImage
    [SerializeField]
    private Texture[] faceTextures; // キューブに使った6つのテクスチャ

    void Start()
    {
        if (faceImages.Length == 6 && faceTextures.Length == 6)
        {
            for (int i = 0; i < 6; i++)
            {
                faceImages[i].texture = faceTextures[i]; // 各面の画像をUIに設定
            }
        }
        else
        {
            Debug.LogError("6つのRawImageとTextureを指定してください");
        }
    }
}
