using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ : MonoBehaviour
{
    [SerializeField]
    private SaikoroText_Result_Miss _Result_Miss;
    float s;

    //このboolが演出が終わった後にtrueになるのでこれを使ってください
    public bool Buttonclickok = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Result_Miss.mini)
        {
            StartCoroutine(minis());
            _Result_Miss.mini = false;
        }
    }

    IEnumerator minis()
    {
        for (int i = 0; i < 40; i++)
        {
            // 少しずつsの値を小さくする。
            s = 120 - i * 3;
            Debug.Log(s);

            this.transform.localScale = new Vector3(s, 2, 1);
            yield return new WaitForSeconds(0.1f);
        }
        Buttonclickok = true;
    }
}
