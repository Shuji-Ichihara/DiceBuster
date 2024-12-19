using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private PlayerMove _playerMove;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerMove = _player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerMove._movetransfrom.Count == _playerMove._movecountmax)
        {
            _playerMove._movecount = Random.Range(1, 7);
            _playerMove._movecountmax = _playerMove._movecount;
            _playerMove._movetransfrom.Clear();
        }
    }
}
