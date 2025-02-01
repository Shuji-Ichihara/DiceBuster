using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;
using static UnityEditor.Lightmapping;

public class MoveCountCheck : MonoBehaviour
{
    [SerializeField] private Sprite[] _diceSprite;
    [SerializeField] private Button _btn;
    [SerializeField] private PlayerMoveTest _playerMoveTest;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private DiceIconFadeOut _DiceIconFadeOut;
    private Image _rend;
    public int _diceRollCount = 20;
    private int _spriteNum = 0;
    public int _DiceNum = 0;
    public bool _movelock;
    public bool _gameStart;
    [SerializeField]
    private List<GameObject> _EnemyAttack;
    [SerializeField]
    private List<TurnUIFadeInOut> _turnUIFadeInOuts;
    void Start()
    {
        _movelock = true;
        _gameStart = false;
        _rend = this.GetComponent<Image>();
    }
    public async void RollingDice()
    {
        //�_�C�X�J�n
        if (_movelock)
        {
            _playerMoveTest._moveCount = 0;
            _movelock = false;
            _gameStart = true;
            if(_EnemyAttack.Count == 0)
            {
                _EnemyAttack.Add(GameObject.Find("EnemyAttackColider1"));
                _EnemyAttack.Add(GameObject.Find("EnemyAttackColider2"));
                _EnemyAttack.Add(GameObject.Find("EnemyAttackColider3"));
            }
            _EnemyAttack[0].SetActive(false);
            _EnemyAttack[1].SetActive(false);
            _EnemyAttack[2].SetActive(false);
            //StartCoroutine(LoadDice());
            await LoadDice();
            //LoadDice();
        }
    }


    private IEnumerator LoadDice()
    //private async UniTask LoadDice()
    {
        _playerAttack.attack = false;
        _btn.interactable = false;
        for (int i = 0; i <= _diceRollCount; i++)
        {
            _spriteNum = Random.Range(0, _diceSprite.Length);
            _rend.sprite = _diceSprite[_spriteNum];
            yield return new WaitForSeconds(0.02f);
            //await UniTask.Yield(PlayerLoopTiming.Update);
        }
        _DiceNum = _spriteNum + 1;
        _playerAttack._movecounttext = _DiceNum;
        _playerAttack._Texts[3].text = "あと" + _DiceNum + "マス";
        _DiceIconFadeOut.MoveUI();
        _btn.interactable = true;
    }

    public IEnumerator EnemyturnAttack()
    {
        _turnUIFadeInOuts[0].MoveUI();
        _turnUIFadeInOuts[1].MoveUI();
        _EnemyAttack[0].SetActive(true);
        _EnemyAttack[1].SetActive(true);
        _EnemyAttack[2].SetActive(true);
        yield return new WaitForSeconds(2);
        _DiceIconFadeOut.ReturnUI();
        _turnUIFadeInOuts[0].ReturnUI();
        _turnUIFadeInOuts[1].ReturnUI();
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

//�Q�l�T�C�g
//https://nosystemnolife.com/unity_2ddice/#google_vignette