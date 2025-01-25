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
    private int _skillCount;
    // Start is called before the first frame update
    void Start()
    {
        Heal(_moveTest._skillmoveCount);
    }

    //スキル値増加(仮)
    public void Heal(float heal)
    {
        _currentHP = heal;
        if (_currentHP > _maxSkill) _currentHP = _maxSkill;
        _skillUI.value = _currentHP / _maxSkill;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && _moveTest._skillmoveCount >= _maxSkill && _skillCount == 0)
        {
            _moveTest._skillmoveCount = 0;
            Heal(_moveTest._skillmoveCount);
            _skillCount++;
        }
        if(_skillCount == 0)
        {
            Heal(_moveTest._skillmoveCount);
        }
    }
}
