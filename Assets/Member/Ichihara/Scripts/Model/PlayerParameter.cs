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
    [SerializeField]
    private PlayerHPUI _playerHPUI;

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
            default:
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
        Transform dummyTransform = null;
        Vector3 fieldInfoPosition = fieldInfo.transform.position;
        float fieldSideLength = 10f;
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    Vector3 dummyforwardFieldInfo = fieldInfoPosition + Vector3.forward * fieldSideLength;
                    // 一番上の行にプレイヤーがいる場合、上側のマスが存在しない為処理をスキップ
                    if (dummyforwardFieldInfo.z > 10f * (FieldGenerater.Instance.FieldHeight - 1)) continue;
                    dummyTransform = FieldGenerater.Instance.GetFieldInfoInGrid(dummyforwardFieldInfo).transform;
                    break;
                case 1:
                    Vector3 dummyrightFieldInfo = fieldInfoPosition + Vector3.right * fieldSideLength;
                    // 一番右の列にプレイヤーがいる場合、右側のマスが存在しない為処理をスキップ
                    if (dummyrightFieldInfo.x > 10f * (FieldGenerater.Instance.FieldWidth - 1)) continue;
                    dummyTransform = FieldGenerater.Instance.GetFieldInfoInGrid(dummyrightFieldInfo).transform;
                    break;
                case 2:
                    Vector3 dummybackwardFieldInfo = fieldInfoPosition + Vector3.back * fieldSideLength;
                    // 一番下の行にプレイヤーがいる場合、下側のマスが存在しない為処理をスキップ
                    if (dummybackwardFieldInfo.z < 0f) continue;
                    dummyTransform = FieldGenerater.Instance.GetFieldInfoInGrid(dummybackwardFieldInfo).transform;
                    break;
                case 3:
                    Vector3 dummyleftFieldInfo = fieldInfoPosition + Vector3.left * fieldSideLength;
                    // 一番左の列にプレイヤーがいる場合、左側のマスが存在しない為処理をスキップ
                    if (dummyleftFieldInfo.x < 0f) continue;
                    dummyTransform = FieldGenerater.Instance.GetFieldInfoInGrid(dummyleftFieldInfo).transform;
                    break;
            }
            if (dummyTransform != null) fieldList.Add(dummyTransform);
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

    public void TakeDamage(int damage)
    {
        // ダメージを体力から減算
        Hp -= damage;
        _playerHPUI.UpdateHP();
        // ログを表示
        Debug.Log("ダメージ量: " + damage + ", 残りHP: " + Hp);

        // 体力が0以下になったらゲームオーバー処理を実行
        if (Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
