using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeUIDisplay : MonoBehaviour
{
    [SerializeField]
    private RawImage[] faceImages; // UI���6��RawImage
    [SerializeField]
    private Texture[] faceTextures; // �L���[�u�Ɏg����6�̃e�N�X�`��

    void Start()
    {
        if (faceImages.Length == 6 && faceTextures.Length == 6)
        {
            for (int i = 0; i < 6; i++)
            {
                faceImages[i].texture = faceTextures[i]; // �e�ʂ̉摜��UI�ɐݒ�
            }
        }
        else
        {
            Debug.LogError("6��RawImage��Texture���w�肵�Ă�������");
        }
    }
}
