using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnUIFadeInOut : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalPosition; // 元の位置
    [SerializeField]
    private float moveDistance;// 右にずらす距離
    [SerializeField]
    private float moveDuration; // 移動の時間

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition; // 元の位置を保存
    }

    private void Update()
    {
        /*
        //テスト
        if(Input.GetKeyDown(KeyCode.S))
        {
            MoveUI();
        }
        //テスト
        if (Input.GetKeyDown(KeyCode.B))
        {
            ReturnUI();
        }
        */
    }
    // UIを右に移動する処理
    public void MoveUI()
    {
        StopAllCoroutines(); // 連続実行防止
        Vector2 targetPosition = originalPosition + new Vector2(moveDistance, 0);
        StartCoroutine(MoveUIPosition(targetPosition, moveDuration));
    }

    // UIを元の位置に戻す処理（特定のタイミングで呼び出し）
    public void ReturnUI()
    {
        StopAllCoroutines();
        StartCoroutine(MoveUIPosition(originalPosition, moveDuration));
    }

    // UIを移動させるコルーチン
    private IEnumerator MoveUIPosition(Vector2 target, float duration)
    {
        float time = 0;
        Vector2 startPosition = rectTransform.anchoredPosition;

        while (time < duration)
        {
            time += Time.deltaTime;
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, target, time / duration);
            yield return null;
        }

        rectTransform.anchoredPosition = target; // 最終位置を確定
    }
}
