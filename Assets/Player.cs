using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100; // プレイヤーの体力

    // プレイヤーがダメージを受ける
    public void TakeDamage(int damage)
    {
        // ダメージを体力から減算
        health -= damage;

        // ログを表示
        Debug.Log("Player took damage: " + damage + ", Remaining health: " + health);

        // 体力が0以下になったらゲームオーバー処理を実行
        if (health <= 0)
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
