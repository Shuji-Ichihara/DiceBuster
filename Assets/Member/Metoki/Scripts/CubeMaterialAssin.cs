using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMaterialAssin : MonoBehaviour
{
    [SerializeField]
    private Renderer[] quadRenderers; // 各QuadのRenderer (6つ指定)
    [SerializeField]
    private RawImage[] uiImages;         // UIのImage (6つ指定)

    private void Start()
    {
        if (quadRenderers.Length != 6 || uiImages.Length != 6)
        {
            Debug.LogError("6つのQuadとUI Imageを指定してください");
            return;
        }

        // 2秒ごとに色を変更するコルーチンを開始
        StartCoroutine(ChangeColors());
    }

    private System.Collections.IEnumerator ChangeColors()
    {
        while (true)
        {
            for (int i = 0; i < 6; i++)
            {
                // ランダムな色を生成
                Color randomColor = new Color(Random.value, Random.value, Random.value);

                // Quadのマテリアルカラーを変更
                quadRenderers[i].material.color = randomColor;

                // UI Imageのカラーも同期
                uiImages[i].color = randomColor;
            }

            // 2秒待機
            yield return new WaitForSeconds(2f);
        }
    }
}
