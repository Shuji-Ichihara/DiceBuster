using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int Health = 100; // プレイヤーの体力

    // プレイヤーがダメージを受ける
    public void TakeDamage(int damage)
    {
        // ダメージを体力から減算
        Health -= damage;

        // ログを表示
        Debug.Log("ダメージ量: " + damage + ", 残りHP: " + Health);

        // 体力が0以下になったらゲームオーバー処理を実行
        if (Health <= 0)
        {
            Die();
        }
    }

    // 死亡処理
    private void Die()
    {
        Debug.Log("Player has died!");
    }
}
