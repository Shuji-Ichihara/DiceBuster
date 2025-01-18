using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    [SerializeField]
    private int _maxHp = 100;
    [System.NonSerialized]
    public int Hp = 0;
    [SerializeField]
    private int _baseAttackPower = 10;
    [System.NonSerialized]
    public int AttackPower = 0;

    private void Start()
    {
        Hp = _maxHp;
        AttackPower = _baseAttackPower;
    }

    public void Attack(ref Enemy enemy)
    {
        if (enemy == null) return;
        enemy.TakeDamage(AttackPower);
    }

    private void FieldEffect(FieldStatus status)
    {
        switch (status.FieldType)
        {
            case FieldType.Attack:
                AttackPower += status.SizeOfEffect;
                break;
            case FieldType.Health:
                if (Hp < _maxHp)
                    Hp += status.SizeOfEffect;
                if (Hp > _maxHp)
                    Hp = _maxHp;
                break;
            case FieldType.Guard:
                break;
        }
    }

    public void Buff()
    {
        var fieldInfo = FieldGenerater.Instance.GetFieldInfoInGrid(transform.position);
        var status = fieldInfo.GetComponentInParent<FieldStatus>();
        GameManager.Instance.PlayerParameter.FieldEffect(status);
    }

    public List<Transform> FoundFieldOfFourDirection()
    {
        var fieldInfo = FieldGenerater.Instance.GetFieldInfoInGrid(transform.position);
        if (fieldInfo == null) return null;
        var fieldList = new List<Transform>();
        Transform? dummTransform = null;
        Vector3 fieldInfoPosition = fieldInfo.transform.position;
        float fieldSideLength = 10f;
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    Vector3 dummyforwardFieldInfo = fieldInfoPosition + Vector3.forward * fieldSideLength;
                    dummTransform = FieldGenerater.Instance.GetFieldInfoInGrid(dummyforwardFieldInfo)?.transform;

                    break;
                case 1:
                    Vector3 dummyrightFieldInfo = fieldInfoPosition + Vector3.right * fieldSideLength;
                    dummTransform = FieldGenerater.Instance.GetFieldInfoInGrid(dummyrightFieldInfo)?.transform;
                    break;
                case 2:
                    Vector3 dummybackwardFieldInfo = fieldInfoPosition + Vector3.back * fieldSideLength;
                    dummTransform = FieldGenerater.Instance.GetFieldInfoInGrid(dummybackwardFieldInfo)?.transform;
                    break;
                case 3:
                    Vector3 dummyleftFieldInfo = fieldInfoPosition + Vector3.left * fieldSideLength;
                    dummTransform = FieldGenerater.Instance.GetFieldInfoInGrid(dummyleftFieldInfo)?.transform;
                    break;
            }
            if (dummTransform != null) fieldList.Add(dummTransform);
        }
        return fieldList;
    }

    public async void DeadPlayer()
    {
        if (_maxHp <= 0)
        {
            await UniTask.WaitForSeconds(0.5f);
            SceneChangeManager.Instance.CallChangeScene(SceneChangeManager.Instance.SceneNames[2]);
        }
    }

    public int GetMaxHp()
    {
        return _maxHp;
    }
}
