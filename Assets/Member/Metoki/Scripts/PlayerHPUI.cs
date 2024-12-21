using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
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
        _currentHP = _maxHP;
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

    private void UpdateHP()
    {
        _hpUI.value = _currentHP / _maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<PlayerHPUI>().Damage(10f);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            GetComponent<PlayerHPUI>().Heal(10f);
        }
    }
}
