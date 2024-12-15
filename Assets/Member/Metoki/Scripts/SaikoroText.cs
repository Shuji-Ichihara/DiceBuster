using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaikoroText : MonoBehaviour
{
    [SerializeField]
    private GameObject dice;
    Rigidbody2D rb2D;
    private Image diceImage;
    private int preNum;
    [SerializeField]
    private Text text;
    float posY;

    private bool isRandom = false;

    void Start()
    {
        diceImage = dice.GetComponent<Image>();
        rb2D = dice.GetComponent<Rigidbody2D>();
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
                        text.text = "サ";
                        break;
                    case 1:
                        text.text = "イ";
                        break;
                    case 2:
                        text.text = "コ";
                        break;
                    case 3:
                        text.text = "ロ";
                        break;
                    case 4:
                        text.text = "バ";
                        break;
                    case 5:
                        text.text = "ス";
                        break;
                    case 6:
                        text.text = "タ";
                        break;
                    case 7:
                        text.text = "ー";
                        break;
                }
                preNum = num;
            }
            else
            {
                Debug.Log(preNum + 1);
                isRandom = false;
                switch (this.gameObject.name)
                {
                    case "sa":
                        text.text = "サ";
                        break;
                    case "i":
                        text.text = "イ";
                        break;
                    case "ko":
                        text.text = "コ";
                        break;
                    case "ro":
                        text.text = "ロ";
                        break;
                    case "ba":
                        text.text = "バ";
                        break;
                    case "su":
                        text.text = "ス";
                        break;
                    case "ta":
                        text.text = "タ";
                        break;
                    case "a":
                        text.text = "ー";
                        break;
                }
            }
        }
    }
    //クリックで呼ぶ
    public void OnClickDice()
    {
        if (rb2D.IsSleeping() && !isRandom)
        {
            rb2D.AddForce(new Vector2(0f, 1000f));
            isRandom = true;
        }
    }
}
