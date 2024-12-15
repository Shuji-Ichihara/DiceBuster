using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMaterialAssin : MonoBehaviour
{
    [SerializeField]
    private Renderer[] quadRenderers; // �eQuad��Renderer (6�w��)
    [SerializeField]
    private RawImage[] uiImages;         // UI��Image (6�w��)

    private void Start()
    {
        if (quadRenderers.Length != 6 || uiImages.Length != 6)
        {
            Debug.LogError("6��Quad��UI Image���w�肵�Ă�������");
            return;
        }

        // 2�b���ƂɐF��ύX����R���[�`�����J�n
        StartCoroutine(ChangeColors());
    }

    private System.Collections.IEnumerator ChangeColors()
    {
        while (true)
        {
            for (int i = 0; i < 6; i++)
            {
                // �����_���ȐF�𐶐�
                Color randomColor = new Color(Random.value, Random.value, Random.value);

                // Quad�̃}�e���A���J���[��ύX
                quadRenderers[i].material.color = randomColor;

                // UI Image�̃J���[������
                uiImages[i].color = randomColor;
            }

            // 2�b�ҋ@
            yield return new WaitForSeconds(2f);
        }
    }
}
