using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FieldType
{
    Normal,
    Attack,
    Health,
    Guard,
}

[System.Serializable]
public class FieldData
{
    public FieldType FieldType;
    public int SizeOfEffect;
}

public class FieldDataInfo : MonoBehaviour
{
    // マスの設定ファイル
    [SerializeField]
    private TextAsset _fieldInfoJson = null;
    // マスの情報のデータリスト
    [System.NonSerialized]
    public List<FieldData> FieldDataList = new List<FieldData>();

    /// <summary>
    /// Jsonデータから効果マスの情報を読み込む
    /// </summary>
    /// <returns></returns>
    public async UniTask LoadFieldData()
    {
        string fieldInfoJson = _fieldInfoJson.ToString();
        JsonNode json = JsonNode.Parse(fieldInfoJson);
        foreach (JsonNode node in json["FieldData"])
        {
            FieldData fieldData = new FieldData();
            // マスの効果の読み込み
            fieldData.FieldType = (FieldType)Enum.Parse(typeof(FieldType), node["FieldType"].Get<string>());
            // 効果量の読み込み
            fieldData.SizeOfEffect = int.Parse(node["SizeOfEffect"].Get<string>());
            // マスのデータをリストに追加
            FieldDataList.Add(fieldData);
            await UniTask.Yield();
        }
    }
}