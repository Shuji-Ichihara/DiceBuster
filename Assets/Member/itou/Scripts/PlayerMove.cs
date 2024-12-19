using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public List<Transform> _movetransfrom;
    public int _movecount;
    public int _movecountmax;
    private int _direction;
    public bool _isMoving;
    // Start is called before the first frame update
    void Start()
    {
        _movecount = Random.Range(1, 7);
        _movecountmax = _movecount;
    }

    // Update is called once per frame
    void Update()
    {
        if (_movecount >= 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && _isMoving == false)
            {
                _isMoving = true;
                _direction = 0;
                StartCoroutine(Move());
            }
            if (Input.GetKeyDown(KeyCode.S) && _isMoving == false)
            {
                _isMoving = true;
                _direction = 1;
                StartCoroutine(Move());
            }
            if (Input.GetKeyDown(KeyCode.A) && _isMoving == false)
            {
                _isMoving = true;
                _direction = 2;
                StartCoroutine(Move());
            }
            if (Input.GetKeyDown(KeyCode.D) && _isMoving == false)
            {
                _isMoving = true;
                _direction = 3;
                StartCoroutine(Move());
            }
        }
    }

    private IEnumerator Move()
    {
        switch (_direction)
        {
            case 0:
                for (int i = 0; i < 180; i++)
                {
                    yield return new WaitForSeconds(0.001f);
                    this.gameObject.transform.Rotate(0.5f, 0, 0, Space.World);
                    this.transform.position += new Vector3(0, 0, 0.00555555556f);
                }
                //this.transform.rotation = Quaternion.Euler(0, 0, 0);
                _movecount--;
                _isMoving = false;
                break;
            case 1:
                for (int i = 0; i < 180; i++)
                {
                    yield return new WaitForSeconds(0.001f);
                    this.gameObject.transform.Rotate(-0.5f, 0, 0, Space.World);
                    this.transform.position += new Vector3(0, 0, -0.00555555556f);
                }
                //this.transform.rotation = Quaternion.Euler(0, 0, 0);
                _movecount--;
                _isMoving = false;
                break;
            case 2:
                for (int i = 0; i < 180; i++)
                {
                    yield return new WaitForSeconds(0.001f);
                    this.gameObject.transform.Rotate(0, 0, 0.5f,Space.World);
                    this.transform.position += new Vector3(-0.00555555556f, 0, 0);
                }
                //this.transform.rotation = Quaternion.Euler(0, 0, 0);
                _movecount--;
                _isMoving = false;
                break;
            case 3:
                for (int i = 0; i < 180; i++)
                {
                    yield return new WaitForSeconds(0.001f);
                    this.gameObject.transform.Rotate(0, 0, -0.5f,Space.World);
                    this.transform.position += new Vector3(0.00555555556f, 0, 0);
                }
                //this.transform.rotation = Quaternion.Euler(0, 0, 0);
                _movecount--;
                _isMoving = false;
                break;
        }
    }
}
