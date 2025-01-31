using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScrollController : MonoBehaviour
{
    public GameObject imagePrefab;       // 生成するイメージプレハブ
    public Transform parentPanel;        // 親パネル（Canvas内のUI要素）
    public RectTransform[] spawnPoints;  // スポーンポイント（UIの座標を持つ）
    public Sprite[] imageSprites;        // 使用する画像のリスト
    public float spawnInterval = 1f;     // 画像を生成する間隔
    public float moveSpeed = 100f;       // 画像が左に流れる速度
    public float spacing = 200f;         // 画像間の間隔

    private Vector2[] lastImagePositions;  // 各スポーンポイントの最新の画像位置

    void Start()
    {
        // スポーンポイントごとの最後の位置を初期化
        lastImagePositions = new Vector2[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            lastImagePositions[i] = spawnPoints[i].anchoredPosition;
        }

        // 一定間隔で画像をスポーンし続ける
        StartCoroutine(SpawnImagesContinuously());
    }

    IEnumerator SpawnImagesContinuously()
    {
        while (true)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            SpawnImage(spawnIndex);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnImage(int spawnIndex)
    {
        // スポーン位置を決定（前の画像の少し後ろ）
        Vector2 spawnPosition = lastImagePositions[spawnIndex];
        spawnPosition.x += spacing;

        // Imageを生成（親パネルに追加）
        GameObject newImage = Instantiate(imagePrefab, parentPanel);
        RectTransform rectTransform = newImage.GetComponent<RectTransform>();

        // UI座標で配置
        rectTransform.anchoredPosition = spawnPosition;
        rectTransform.localScale = Vector3.one;

        // ランダムな画像を適用
        newImage.GetComponent<Image>().sprite = imageSprites[Random.Range(0, imageSprites.Length)];

        // 左に移動するスクリプトを追加
        IconScroll mover = newImage.AddComponent<IconScroll>();
        mover.moveSpeed = moveSpeed;

        // 最後の位置を更新
        lastImagePositions[spawnIndex] = spawnPosition;
    }
}
