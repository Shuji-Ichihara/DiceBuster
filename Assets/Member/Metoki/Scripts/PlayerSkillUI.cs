using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillUI : MonoBehaviour
{
    //スキルバー
    [SerializeField]
    private Slider _hpUI;

    //スキル(仮)
    [SerializeField]
    private float _maxHP;

    //現在のスキル
    private float _currentHP;
    // Start is called before the first frame update
    void Start()
    {
        /*
        //初期設定
        _currentHP = GameManager.Instance.PlayerParameter.GetMaxHp();
        UpdateHP();
        */
    }

    //スキル値減少(仮)
    public void Damage(float damage)
    {
        _currentHP -= damage;
        if (_currentHP < 0) _currentHP = 0;
        UpdateHP();
    }

    //スキル値増加(仮)
    public void Heal(float heal)
    {
        _currentHP += heal;
        if (_currentHP > _maxHP) _currentHP = _maxHP;
        UpdateHP();
    }

    private void UpdateHP()
    {
        _hpUI.value = _currentHP / GameManager.Instance.PlayerParameter.GetMaxHp();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<PlayerHPUI>().Damage(100f);
        }
        */
    }
}
