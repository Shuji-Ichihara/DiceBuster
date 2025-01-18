using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : SingletonMonoBehaviour<EnemyGenerater>
{
    [SerializeField]
    private Enemy _enemy1 = null;
    [SerializeField]
    private Enemy _enemy2 = null;
    [SerializeField]
    private Enemy _enemy3 = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GenerateEnemy()
    {
        Instantiate(_enemy1, FieldGenerater.Instance.GetGridPosition(0,2), Quaternion.identity);
        Instantiate(_enemy2, FieldGenerater.Instance.GetGridPosition(2,6), Quaternion.identity);
        Instantiate(_enemy3, FieldGenerater.Instance.GetGridPosition(4,8), Quaternion.identity);
    }

}
