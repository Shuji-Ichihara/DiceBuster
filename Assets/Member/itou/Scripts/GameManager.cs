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

    // Start is called before the first frame update
    async void Start()
    {
        await UniTask.WaitForSeconds(0.5f);
        //_playerObject = GameObject.Find("Player");
        _playerMoveTest = _playerObject.GetComponent<PlayerMoveTest>();
        _playerParameter = _playerObject.GetComponentInChildren<PlayerParameter>();
        EnemyGenerater.Instance.GenerateEnemy();
        PlayerHPUI.Instance.SetUpHpBar(_playerParameter);
        PreUpdate().Forget();
    }

    private async UniTask PreUpdate()
    {
        while (GameClear == false)
        {
            await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
            await PlayerTurn();
        }
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
        // à⁄ìÆ
        MoveCount = RandomMoveCount();
        while (MoveCount > 0)
        {
            await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
            await _playerMoveTest.MovePlayer();
        }
        await UniTask.Yield();
        // çUåÇ
        List<Transform> fieldList = _playerParameter.FoundFieldOfFourDirection();
        if (fieldList == null) return;
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

    /*
    private async UniTask EnemyTurn()
    {
        // çUåÇ
        var fieldList = _playerParameter.FoundFieldOfFourDirection();
        for (int i = 0; i < fieldList.Count; i++)
        {
            var fieldStatus = fieldList[i].GetComponent<FieldStatus>();
            if (fieldStatus != null) enemy = fieldStatus.GetEnemy();
            if (enemy != null) break;
        }
        _playerParameter.Attack(ref enemy);
    }*/
}
