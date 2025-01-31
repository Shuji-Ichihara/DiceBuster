using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : SingletonMonoBehaviour<EnemyGenerater>
{
    [SerializeField]
    private List<Enemy> _enemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GenerateEnemy()
    {
        Instantiate(_enemies[0], FieldGenerater.Instance.GetGridPosition(0,2), Quaternion.identity);
        Instantiate(_enemies[1], FieldGenerater.Instance.GetGridPosition(2,6), Quaternion.identity);
        Instantiate(_enemies[2], FieldGenerater.Instance.GetGridPosition(4,8), Quaternion.identity);
    }

}
