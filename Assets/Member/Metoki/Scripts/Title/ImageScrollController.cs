using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScrollController : MonoBehaviour
{
    [SerializeField]
    private GameObject imagePrefab; // Imageのプレハブ
    [SerializeField]
    private Transform spawnPoint; // 画像の生成位置（右端）
    [SerializeField]
    private Transform parentPanel; // Imageを配置するパネル
    [SerializeField]
    private Sprite[] imageSprites; // 画像のリスト
    [SerializeField]
    private float spawnInterval = 1.5f; // 画像の生成間隔
    [SerializeField]
    private float moveSpeed = 200f; // 左に流れるスピード

    void Start()
    {
        StartCoroutine(SpawnImages());
    }

    IEnumerator SpawnImages()
    {
        while (true)
        {
            SpawnImage();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnImage()
    {
        GameObject newImage = Instantiate(imagePrefab, spawnPoint.position, Quaternion.identity, parentPanel);
        newImage.GetComponent<Image>().sprite = imageSprites[Random.Range(0, imageSprites.Length)];
        newImage.AddComponent<IconScroll>().moveSpeed = moveSpeed;
    }
}
