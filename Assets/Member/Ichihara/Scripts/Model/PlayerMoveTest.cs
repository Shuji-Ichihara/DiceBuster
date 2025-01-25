using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObject = null;
    private bool _isMoving;
    public int _moveCount;

    private Transform _childTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        //_playerObject.transform.position = FieldGenerater.Instance.GetGridPosition(0, 5);
        _childTransform = _playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async UniTask MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.W) && _isMoving == false)
        {
            // 光線を飛ばす
            if (ShootRayFromThePlayer(Vector3.forward) == true) return;
            _isMoving = true;
            await MoveForwardPlayer(Vector3.forward);
            GameManager.Instance.PlayerParameter.Buff();
            GameManager.Instance.MoveCount--;
        }
        if (Input.GetKeyDown(KeyCode.S) && _isMoving == false)
        {
            // 光線を飛ばす
            if (ShootRayFromThePlayer(Vector3.back) == true) return;
            _isMoving = true;
            await MoveBackwardPlayer(Vector3.back);
            GameManager.Instance.PlayerParameter.Buff();
            GameManager.Instance.MoveCount--;
        }
        if (Input.GetKeyDown(KeyCode.A) && _isMoving == false)
        {
            // 光線を飛ばす
            if (ShootRayFromThePlayer(Vector3.left) == true) return;
            _isMoving = true;
            await MoveLefPlayer(Vector3.left);
            GameManager.Instance.PlayerParameter.Buff();
            GameManager.Instance.MoveCount--;
        }
        if (Input.GetKeyDown(KeyCode.D) && _isMoving == false)
        {
            // 光線を飛ばす
            if (ShootRayFromThePlayer(Vector3.right) == true) return;
            _isMoving = true;
            await MoveRightPlayer(Vector3.right);
            GameManager.Instance.PlayerParameter.Buff();
            GameManager.Instance.MoveCount--;
        }
    }


    private bool ShootRayFromThePlayer(Vector3 shootVector)
    {
        var vector = shootVector * _childTransform.localScale.x;
        Ray ray = new Ray(_childTransform.position, vector);
        RaycastHit hit;
        bool check = Physics.Raycast(ray, out hit);
        if (check)
        {
            float distance = Vector3.Distance(_childTransform.position, hit.transform.position);
            if (distance > 5f && distance <= 15f) return check;
        }
        return false;
    }

    #region プレイヤーの移動関数
    /// <summary>
    /// 前移動
    /// </summary>
    /// <param name="moveVector"></param>
    /// <returns></returns>
    private async UniTask MoveForwardPlayer(Vector3 moveVector)
    {
        float playerScaleZ = _childTransform.localScale.z;
        var basePosition = transform.position;
        var playerObjectPosition = Vector3.Scale(basePosition, Vector3.forward);
        while (Mathf.Abs(transform.position.z) <= Mathf.Abs(basePosition.z) + moveVector.z * playerScaleZ - 1
               && transform.position.z < FieldGenerater.Instance.GetGridHeightMax())
        {
            await UniTask.Yield();
            playerObjectPosition = moveVector * playerScaleZ * Time.deltaTime;
            transform.position += playerObjectPosition;
        }
        var floor = Mathf.Ceil(transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, floor);
        _moveCount++;
        _isMoving = false;
    }

    /// <summary>
    /// 後ろ移動
    /// </summary>
    /// <param name="moveVector"></param>
    /// <returns></returns>
    private async UniTask MoveBackwardPlayer(Vector3 moveVector)
    {
        float playerScaleZ = _childTransform.localScale.z;
        var basePosition = transform.position;
        var playerObjectPosition = Vector3.Scale(basePosition, Vector3.forward);
        while (Mathf.Abs(transform.position.z) >= Mathf.Abs(basePosition.z) + moveVector.z * playerScaleZ + 1
               && transform.position.z > FieldGenerater.Instance.GetGridHeightMin())
        {
            await UniTask.Yield();
            playerObjectPosition = moveVector * playerScaleZ * Time.deltaTime;
            transform.position += playerObjectPosition;
        }
        var floor = Mathf.Floor(transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, floor);
        _moveCount++;
        _isMoving = false;
    }

    /// <summary>
    /// 左移動
    /// </summary>
    /// <param name="moveVector"></param>
    /// <returns></returns>
    private async UniTask MoveLefPlayer(Vector3 moveVector)
    {
        float playerScaleX = _childTransform.localScale.x;
        var basePosition = transform.position;
        var playerObjectPosition = Vector3.Scale(basePosition, Vector3.right);
        while (Mathf.Abs(transform.position.x) >= Mathf.Abs(basePosition.x) + moveVector.x * playerScaleX + 1
               && transform.position.x > FieldGenerater.Instance.GetGridWidthMin())
        {
            await UniTask.Yield();
            playerObjectPosition = moveVector * playerScaleX * Time.deltaTime;
            transform.position += playerObjectPosition;
        }
        var floor = Mathf.Floor(transform.position.x);
        transform.position = new Vector3(floor, transform.position.y, transform.position.z);
        _moveCount++;
        _isMoving = false;
    }

    /// <summary>
    /// 右移動
    /// </summary>
    /// <param name="moveVector"></param>
    /// <returns></returns>
    private async UniTask MoveRightPlayer(Vector3 moveVector)
    {
        float playerScaleX = _childTransform.localScale.x;
        var basePosition = transform.position;
        var playerObjectPosition = Vector3.Scale(basePosition, Vector3.right);
        while (Mathf.Abs(transform.position.x) <= Mathf.Abs(basePosition.x) + moveVector.x * playerScaleX - 1
               && transform.position.x < FieldGenerater.Instance.GetGridWidthMax())
        {
            await UniTask.Yield();
            playerObjectPosition = moveVector * playerScaleX * Time.deltaTime;
            transform.position += playerObjectPosition;
        }
        var floor = Mathf.Ceil(transform.position.x);
        transform.position = new Vector3(floor, transform.position.y, transform.position.z);
        _moveCount++;
        _isMoving = false;
    }
    #endregion
}
