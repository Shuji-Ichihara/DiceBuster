using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaikoroText_Result_Clear : MonoBehaviour
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

    [SerializeField]
    private GameObject hanabi;
    [SerializeField]
    private List<GameObject> _nazo;

    public bool mini;

    //このboolが演出が終わった後にtrueになるのでこれを使ってください
    public bool Buttonclickok = false;

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
                int finalNum = fixedCase >= 0 && fixedCase < 5 ? fixedCase : preNum;
                Debug.Log(finalNum + 1);

                switch (finalNum)
                {
                    case 0:
                        text.text = "C";
                        //text.color = Color.yellow;
                        StartCoroutine(hanabis());
                        break;
                    case 1:
                        text.text = "L";
                        //text.color = Color.yellow;
                        break;
                    case 2:
                        text.text = "E";
                        //text.color = Color.yellow;
                        break;
                    case 3:
                        text.text = "A";
                        //text.color = Color.yellow;
                        break;
                    case 4:
                        text.text = "R";
                        //text.color = Color.yellow;
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

    IEnumerator hanabis()
    {
        Instantiate(hanabi, _nazo[0].transform.position,Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(hanabi, _nazo[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(hanabi, _nazo[2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(hanabi, _nazo[3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.6f);
        Instantiate(hanabi, _nazo[4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Buttonclickok = true;
    }
}
