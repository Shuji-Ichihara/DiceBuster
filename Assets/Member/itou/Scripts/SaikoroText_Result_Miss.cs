using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaikoroText_Result_Miss : MonoBehaviour
{
    [SerializeField]
    private GameObject dice;
    private Rigidbody2D rb2D;
    private Image diceImage;
    private int preNum;
    [SerializeField]
    private Text text;
    [SerializeField]
    private float autoStartDelay = 2f; // 自動開始の遅延時間（秒）
    private bool isRandom = false;

    [Header("ルーレット終了時の選択番号 (0〜7)")]
    [SerializeField]
    private int fixedCase = -1; // -1ならランダム、0〜7なら固定

    [Header("高度の設定")]
    [SerializeField]
    private float launchSpeed = 5f; // 初速を統一する値

    public bool mini;

    void Start()
    {
        diceImage = dice.GetComponent<Image>();
        rb2D = dice.GetComponent<Rigidbody2D>();

        // 指定時間後にルーレットを開始
        Invoke(nameof(StartDiceRoll), autoStartDelay);
    }

    void Update()
    {
        if (isRandom)
        {
            if (!rb2D.IsSleeping())
            {
                int num = Random.Range(0, 8);
                switch (num)
                {
                    case 0:
                        text.text = "M";
                        break;
                    case 1:
                        text.text = "I";
                        break;
                    case 2:
                        text.text = "S";
                        break;
                    case 3:
                        text.text = "C";
                        break;
                    case 4:
                        text.text = "l";
                        break;
                    case 5:
                        text.text = "E";
                        break;
                    case 6:
                        text.text = "A";
                        break;
                    case 7:
                        text.text = "R";
                        break;
                }
                preNum = num;
            }
            else
            {
                isRandom = false;
                int finalNum = fixedCase >= 0 && fixedCase < 4 ? fixedCase : preNum;
                Debug.Log(finalNum + 1);

                switch (finalNum)
                {
                    case 0:
                        Debug.Log(mini);
                        mini = true;
                        Debug.Log(mini);
                        text.text = "M";
                        break;
                    case 1:
                        text.text = "I";
                        mini = true;
                        break;
                    case 2:
                        text.text = "S";
                        mini = true;
                        break;
                    case 3:
                        text.text = "S";
                        mini = true;
                        break;
                }
            }
        }
    }

    private void StartDiceRoll()
    {
        if (!isRandom)
        {
            // 初速を統一して設定
            rb2D.velocity = Vector2.up * launchSpeed;
            isRandom = true;
        }
    }
}
