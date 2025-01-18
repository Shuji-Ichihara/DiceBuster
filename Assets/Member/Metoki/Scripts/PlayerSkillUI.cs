using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillUI : MonoBehaviour
{
    //スキルバー
    [SerializeField]
    private Slider _skillUI;

    //スキル(仮)
    [SerializeField]
    private float _maxSkill;

    [SerializeField]
    private PlayerMoveTest _moveTest;
    //現在のスキル
    private float _currentHP;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHP();
    }

    //スキル値増加(仮)
    public void Heal(float heal)
    {
        _currentHP = heal;
        if (_currentHP > _maxSkill) _currentHP = _maxSkill;
        UpdateHP();
    }

    private void UpdateHP()
    {
        _skillUI.value = _currentHP / _maxSkill;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && _moveTest._moveCount >= _maxSkill)
        {
            _moveTest._moveCount = 0;
            UpdateHP() ;
        }
        Heal(_moveTest._moveCount);
    }
}
