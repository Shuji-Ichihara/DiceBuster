using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconScroll : MonoBehaviour
{
    public float moveSpeed = 200f;

    void Update()
    {
        transform.localPosition += Vector3.left * moveSpeed * Time.deltaTime;

        // ‰æ–ÊŠO‚Éo‚½‚çíœ
        if (transform.localPosition.x < -Screen.width / 2)
        {
            Destroy(gameObject);
        }
    }
}
