using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : SingletonMonoBehaviour<EnemyGenerater>
{
    [SerializeField]
    private List<Enemy> _enemies = new List<Enemy>();

    public void GenerateEnemy()
    {
        _enemies[0] = Instantiate(_enemies[0], FieldGenerater.Instance.GetGridPosition(0, 2), Quaternion.identity);
        _enemies[1] = Instantiate(_enemies[1], FieldGenerater.Instance.GetGridPosition(2, 6), Quaternion.identity);
        _enemies[2] = Instantiate(_enemies[2], FieldGenerater.Instance.GetGridPosition(4, 8), Quaternion.identity);
    }

    public List<Enemy> GetEnemyList()
    {
        return _enemies;
    }

}
