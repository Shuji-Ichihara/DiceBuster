using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    int _direction;
    bool _isMoving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && _isMoving == false)
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
                _isMoving = false;
                break;
        }
    }
}
