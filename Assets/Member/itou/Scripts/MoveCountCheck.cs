using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DiceRoll : MonoBehaviour
{
    [SerializeField] private Sprite[] _diceSprite;
    [SerializeField] private Button _btn;
    private Image _rend;
    public int _diceRollCount = 20;
    private int _spriteNum = 0;
    public int _Movecount;
    void Start()
    {
        _rend = this.GetComponent<Image>();
    }
    public void RollingDice()
    {
        StartCoroutine(LoadDice());
    }
    private IEnumerator LoadDice()
    {
        _btn.interactable = false;
        for (int i = 0; i <= _diceRollCount; i++)
        {
            _spriteNum = Random.Range(0, _diceSprite.Length);
            _rend.sprite = _diceSprite[_spriteNum];
            yield return new WaitForSeconds(0.02f);
        }
        _Movecount = _spriteNum + 1;
        _btn.interactable = true;
    }
}

//参考サイト
//https://nosystemnolife.com/unity_2ddice/#google_vignette