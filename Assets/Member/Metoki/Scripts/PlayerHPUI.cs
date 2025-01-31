using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : SingletonMonoBehaviour<PlayerHPUI>
{
    [SerializeField]
    private PlayerParameter _playerParameter;
    //HPÉoÅ[
    [SerializeField]
    private Slider _hpUI;

    //HP(âº)
    [SerializeField]
    private float _maxHP;

    //åªç›ÇÃHP
    private float _currentHP;
    // Start is called before the first frame update
    void Start()
    {
        //èâä˙ê›íË
        _currentHP = _playerParameter.Hp;
        UpdateHP();
    }

    //HPå∏è≠(âº)
    public void Damage(float damage)
    {
        _currentHP -= damage;
        if(_currentHP < 0 ) _currentHP = 0;
        UpdateHP();
    }

    //HPëùâ¡(âº)
    public void Heal(float heal)
    {
        _currentHP += heal;
        if(_currentHP > _maxHP ) _currentHP = _maxHP;
        UpdateHP();
    }

    public void UpdateHP()
    {
        _hpUI.value = _playerParameter.Hp / _currentHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
