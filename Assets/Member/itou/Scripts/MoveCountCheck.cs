using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class MoveCountCheck : MonoBehaviour
{
    [SerializeField] private Sprite[] _diceSprite;
    [SerializeField] private Button _btn;
    [SerializeField] private PlayerMoveTest _playerMoveTest;
    [SerializeField] private PlayerAttack _playerAttack;
    private Image _rend;
    public int _diceRollCount = 20;
    private int _spriteNum = 0;
    public int _DiceNum = 0;
    public bool _movelock;
    private List<GameObject> _EnemyAttack;
    void Start()
    {
        _movelock = true;
        _rend = this.GetComponent<Image>();
    }
    public void RollingDice()
    {
        if (_movelock)
        {
            _playerMoveTest._moveCount = 0;
            _movelock = false;
            _EnemyAttack.Add(GameObject.Find("EnemyAttackColider1"));
            _EnemyAttack.Add(GameObject.Find("EnemyAttackColider2"));
            _EnemyAttack.Add(GameObject.Find("EnemyAttackColider3"));
            StartCoroutine(LoadDice());
            //LoadDice();
        }
    }
    private IEnumerator LoadDice()
    {
        _playerAttack.attack = false;
        _btn.interactable = false;
        for (int i = 0; i <= _diceRollCount; i++)
        {
            _spriteNum = Random.Range(0, _diceSprite.Length);
            _rend.sprite = _diceSprite[_spriteNum];
            yield return new WaitForSeconds(0.02f);
        }
        _DiceNum =_spriteNum + 1;
        _playerAttack._movecounttext = _DiceNum;
        _playerAttack._Texts[3].text = "あと" + _DiceNum + "マス";
        _btn.interactable = true;
    }
    /*
    private void LoadDice()
    {
        _movelock = false;
        _btn.interactable = false;
        for (int i = 0; i <= _diceRollCount; i++)
        {
            _spriteNum = Random.Range(0, _diceSprite.Length);
            _rend.sprite = _diceSprite[_spriteNum];
        }
        _playerMoveTest._moveCount = _spriteNum + 1;
        _btn.interactable = true;
    }
    */
}

//参考サイト
//https://nosystemnolife.com/unity_2ddice/#google_vignette