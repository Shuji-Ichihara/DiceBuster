using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FieldGenerater : SingletonMonoBehaviour<FieldGenerater>
{
    // 
    [SerializeField]
    private FieldStatus _field = null;
    public int FieldWidth => _fieldWidth;
    private int _fieldWidth = 9;
    public int FieldHeight => _fieldHeight;
    private int _fieldHeight = 6;
    private GameObject[,] _fieldGrid;
    // 
    [SerializeField]
    private Transform _gridOrigin = null;
    // 
    [SerializeField]
    private FieldDataInfo _fieldDataInfo = null;
    // AnimationCurveで乱数に偏りを持たせる
    [SerializeField]
    private AnimationCurve _randomCurve = null;
    //
    [SerializeField]
    private List<Material> _fieldMaterials = new List<Material>();

    private async void Awake()
    {
        base.Awake();
        // フィールドオブジェクトの情報を取得
        await _fieldDataInfo.LoadFieldData();
        // Gridの原点の座標を確定する
        float fieldSideLength = 10f;
        _gridOrigin.position = Vector3.zero;
        // 配列の情報を作成
        _fieldGrid = new GameObject[_fieldHeight, _fieldWidth];
        // フィールドオブジェクトを生成、配置
        for (int height = 0; height < _fieldHeight; height++)
        {
            for (int width = 0; width < _fieldWidth; width++)
            {
                var fieldStatus = Instantiate(_field
                                            , new Vector3(_gridOrigin.position.x + width * fieldSideLength
                                                        , _gridOrigin.position.y
                                                        , _gridOrigin.position.z + height * fieldSideLength)
                                            , Quaternion.identity);
                // _randomCurveから乱数を抽出
                float seed = _randomCurve.Evaluate(Random.value);
                int randomNum = (int)(seed * 100);
                randomNum %= _fieldDataInfo.FieldDataList.Count;
                // 読み込んだマス効果の情報を生成したマスに渡す
                fieldStatus.SetFieldStatus(_fieldDataInfo.FieldDataList[randomNum], _fieldMaterials[randomNum]);
                _fieldGrid[height, width] = fieldStatus.gameObject;
            }
        }
    }


    public void ChangeField(Vector3 playerPosition)
    {
        GameObject obj = GetFieldInfoInGrid(playerPosition);
        // マスを書き換える処理
        // _randomCurveから乱数を抽出
        float seed = _randomCurve.Evaluate(Random.value);
        int randomNum = (int)(seed * 100);
        randomNum %= _fieldDataInfo.FieldDataList.Count;
        // 読み込んだマス効果の情報を生成したマスに渡す
        var nextField = obj.GetComponent<FieldStatus>();
        nextField.SetFieldStatus(_fieldDataInfo.FieldDataList[randomNum], _fieldMaterials[randomNum]);
        obj = nextField.gameObject;
    }

    public float GetGridWidthMax()
    {
        return _fieldGrid[_fieldHeight - 1, _fieldWidth - 1].transform.position.x;
    }

    public float GetGridHeightMax()
    {
        return _fieldGrid[_fieldHeight - 1, _fieldWidth - 1].transform.position.z;
    }

    public float GetGridWidthMin()
    {
        return _fieldGrid[0, 0].transform.position.x;
    }

    public float GetGridHeightMin()
    {
        return _fieldGrid[0, 0].transform.position.z;
    }

    public Vector3 GetGridPosition(int height, int width)
    {
        return _fieldGrid[height, width].transform.position;
    }

    public GameObject GetFieldInfoInGrid(Vector3 position)
    {
        GameObject obj = null;
        var floorPosition = new Vector3(Mathf.Floor(position.x), position.y, Mathf.Floor(position.z));
        for (int height = 0; height < _fieldHeight; height++)
        {
            for (int width = 0; width < _fieldWidth; width++)
            {
                var fieldObj = _fieldGrid[height, width];
                if (fieldObj.transform.position.x == floorPosition.x
                    && fieldObj.transform.position.z == floorPosition.z)
                {
                    obj = fieldObj;
                    break;
                }
            }
        }
        return obj;
    }
}
