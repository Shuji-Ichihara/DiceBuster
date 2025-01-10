using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerater : SingletonMonoBehaviour<FieldGenerater>
{
    // 
    [SerializeField]
    private FieldStatus _field = null;
    private GameObject[,] _fieldGrid = new GameObject[6, 9];
    // 
    [SerializeField]
    private Transform _gridOrigin = null;
    // 
    [SerializeField]
    private FieldDataInfo _fieldDataInfo = null;

    private async void Awake()
    {
        base.Awake();
        // フィールドオブジェクトの情報を取得
        await _fieldDataInfo.LoadFieldData();
        // フィールドオブジェクトを生成、配置
        for (int height = 0; height < 6; height++)
        {
            for (int width = 0; width < 9; width++)
            {
                var fieldStatus = Instantiate(_field
                                            , new Vector3(_gridOrigin.position.x, _gridOrigin.position.y, _gridOrigin.position.z)
                                            , Quaternion.identity);
                int randomNum = Random.Range(0, _fieldDataInfo.FieldDataList.Count);
                // 読み込んだマス効果の情報を生成したマスに渡す
                _field.SetFieldStatus(_fieldDataInfo.FieldDataList[randomNum]);
                _fieldGrid[height, width] = fieldStatus.gameObject;
            }
        }
    }
}
