using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuka : MonoBehaviour
{
    private GameObject _player;
    private PlayerMove _playerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player = other.gameObject;
            _playerMove = _player.GetComponent<PlayerMove>();
            if(_playerMove._isMoving == false)
            {
                _playerMove._movetransfrom.Add(this.transform);
            }
        }
    }
}
