using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    private GameObject _playerObject;
    private PlayerMoveTest _playerMoveTest;
    public PlayerParameter PlayerParameter => _playerParameter;
    private PlayerParameter _playerParameter;

    public bool GameClear = false;
    public int MoveCount = 0;

    [SerializeField]
    private MoveCountCheck _moveCountCheck = null;

    // Start is called before the first frame update
    async void Start()
    {
        await UniTask.WaitForSeconds(0.5f);
        //_playerObject = GameObject.Find("Player");
        _playerMoveTest = _playerObject.GetComponent<PlayerMoveTest>();
        _playerParameter = _playerObject.GetComponentInChildren<PlayerParameter>();
        EnemyGenerater.Instance.GenerateEnemy();
        //PlayerHPUI.Instance.SetUpHpBar(_playerParameter);
        PreUpdate().Forget();
    }

    private async UniTask PreUpdate()
    {
        var enemyList = EnemyGenerater.Instance.GetEnemyList();
        while (GameClear == false)
        {
            await UniTask.Yield(PlayerLoopTiming.Update);
            await PlayerTurn();
            if (enemyList[0].Health <= 0
                && enemyList[1].Health <= 0
                && enemyList[2].Health <= 0)
            {
                GameClear = true;
            }
            else if (_playerParameter.Hp <= 0)
            {
                SceneChangeManager.Instance.CallChangeScene(SceneChangeManager.Instance.SceneNames[3]);
            }
            //await EnemyTurn();
        }
        // クリアシーンに遷移
        SceneChangeManager.Instance.CallChangeScene(SceneChangeManager.Instance.SceneNames[2]);
    }

    // Update is called once per frame
    void Update()
    {
        //await PlayerTurn();
    }

    private int RandomMoveCount()
    {
        int randomValue = Random.Range(0, 6) + 1;
        return randomValue;
    }

    private async UniTask PlayerTurn()
    {
        // 移動
        await Move();
        // 攻撃
        List<Transform> fieldList = _playerParameter.FoundFieldOfFourDirection();
        if (fieldList == null || fieldList.Count <= 0) return;
        Enemy enemy = null;
        for (int i = 0; i < fieldList.Count; i++)
        {
            var fieldStatus = fieldList[i].GetComponent<FieldStatus>();
            if (fieldStatus != null) enemy = fieldStatus.GetEnemy();
            if (enemy != null) break;
        }
        await UniTask.WaitForSeconds(0.3f);
        _playerParameter.Attack(ref enemy);
    }

    private async UniTask Move()
    {
        int diceNum = _moveCountCheck._DiceNum;
        MoveCount = diceNum;
        while (MoveCount > 0)
        {
            Debug.Log(MoveCount);
            await UniTask.Yield(PlayerLoopTiming.Update);
            await _playerMoveTest.MovePlayer();
        }
        MoveCount = 0;
        _moveCountCheck.ResetDice();

    }

    private async UniTask EnemyTurn()
    {

    }

}
