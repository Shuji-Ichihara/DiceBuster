using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldStatus : MonoBehaviour
{
    // マスの属性
    public FieldType FieldType => _fieldType;
    private FieldType _fieldType;
    // マス効果の効果量
    public int SizeOfEffect => _sizeOfEffect;
    private int _sizeOfEffect;

    private Enemy enemy = null;

    public void SetFieldStatus(FieldData fieldData, Material material)
    {
        _fieldType = fieldData.FieldType;
        _sizeOfEffect = fieldData.SizeOfEffect;
        var child = transform.GetChild(1);
        var renderer = child.GetComponent<MeshRenderer>();
        renderer.material = material;
    }

    public Enemy GetEnemy()
    {
        return enemy;
    }

    private void OnCollisionEnter(Collision other)
    {
        var dummyEnemy = other.gameObject.GetComponent<Enemy>();
        if(dummyEnemy != null) 
        {
            enemy = dummyEnemy;
        }
    }
}
