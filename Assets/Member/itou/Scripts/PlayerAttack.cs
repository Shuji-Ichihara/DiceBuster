using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public List<GameObject> _Enemys;
    public List<GameObject> _Buttons;
    public List<Button> _Button;
    public List<Text> _Texts;
    public int _movecounttext;
    private bool _move;
    //private Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _Buttons[0].SetActive(false);
        _Buttons[1].SetActive(false);
        _Buttons[2].SetActive(false);
        _Buttons[3].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0.0f, this.transform.rotation.eulerAngles.y, 0.0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attacks());
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if(_movecounttext != 0)
            {
                _move = true;
                _movecounttext--;
                _Texts[3].text = "Ç†Ç∆" + _movecounttext + "É}ÉX";
            }
        }
        if (_move == true)
        {
            _move = false;
            _Buttons[0].SetActive(false);
            _Buttons[1].SetActive(false);
            _Buttons[2].SetActive(false);
            _Buttons[3].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _Enemys.Add(other.gameObject);
        }
    }
    private void OnTriggerSt1ay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _Enemys.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _Enemys.Remove(other.gameObject);
        }
    }

    public void Enemy1()
    {
        //_enemy = _Enemys[0].gameObject.GetComponent<Enemy>();
        //_enemy._Hp -= 10;
        Debug.Log("a");
        _Buttons[0].SetActive(false);
        _Buttons[1].SetActive(false);
        _Buttons[2].SetActive(false);
        _Buttons[3].SetActive(false);
    }
    public void Enemy2()
    {
        //_enemy = _Enemys[1].gameObject.GetComponent<Enemy>();
        //_enemy._Hp -= 10;
        _Buttons[0].SetActive(false);
        _Buttons[1].SetActive(false);
        _Buttons[2].SetActive(false);
        _Buttons[3].SetActive(false);
    }
    public void Enemy3()
    {
        //_enemy = _Enemys[2].gameObject.GetComponent<Enemy>();
        //_enemy._Hp -= 10;
        _Buttons[0].SetActive(false);
        _Buttons[1].SetActive(false);
        _Buttons[2].SetActive(false);
        _Buttons[3].SetActive(false);
    }

    public void Return()
    {
        _Buttons[0].SetActive(false);
        _Buttons[1].SetActive(false);
        _Buttons[2].SetActive(false);
        _Buttons[3].SetActive(false);
    }

    IEnumerator Attacks()
    {
        _Buttons[0].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        if (_Enemys[0] != null)
        {
            _Buttons[1].SetActive(true);
            _Texts[0].text = _Enemys[0].name;
            _Button[0].onClick.AddListener(() => Enemy1());
            if (_Enemys[1] != null)
            {
                _Buttons[2].SetActive(true);
                _Texts[1].text = _Enemys[1].name;
                _Button[1].onClick.AddListener(() => Enemy2());
                if (_Enemys[2] != null)
                {
                    _Buttons[3].SetActive(true);
                    _Texts[2].text = _Enemys[2].name;
                    _Button[2].onClick.AddListener(() => Enemy3());
                }
            }
        }
    }
}
