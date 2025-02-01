using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 市原追記
    public int Health => health;
    // ステータス
    [SerializeField] int health = 100; // エネミーの体力
    [SerializeField] int attackPower = 10; // エネミーの攻撃力
    //アニメーション用
    [SerializeField] Animator animator;

    private bool isAttacking = false; // 攻撃中フラグ

    private void Start()
    {
    }

    // 攻撃された
    public void TakeDamage(int damage)
    {
        // ダメージを体力から減算
        health -= damage;

        // 現在の体力をログに表示
        Debug.Log("Enemy took damage: " + damage + ", Remaining health: " + health);

        // 体力が0以下になったら死亡処理を呼び出す
        if (health <= 0)
        {
            Die();
        }
    }

    // 死亡
    private void Die()
    {
        // 死亡ログを表示
        Debug.Log("Enemy has died.");

        Destroy(gameObject, 1f); // 1秒後に削除
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("アタック確認");

            // 攻撃中でない場合のみ実行
            if (isAttacking) return;

            // 攻撃を開始
            isAttacking = true;

            PlayerParameter targetPlayer = other.GetComponent<PlayerParameter>();

            targetPlayer.TakeDamage(attackPower);

            animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isAttacking = false;
    }

    /*
    // 敵を攻撃（ターゲットをプレイヤーに変更）
    public void AttackTarget(GameObject target)
    {
        // 攻撃中でない場合のみ実行
        if (isAttacking) return;

        // 攻撃を開始
        isAttacking = true;

        // ターゲットのPlayerコンポーネントを取得
        Player targetPlayer = target.GetComponent<Player>();

        // ターゲットがプレイヤーの場合
        if (targetPlayer != null)
        {
            // 攻撃ログを表示
            Debug.Log("Attacking player with power: " + attackPower);

            // 攻撃アニメーションを再生
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }

            // アニメーション終了時にダメージを与える処理をコルーチンで実行
            StartCoroutine(ApplyDamageAfterAnimation(targetPlayer));
        }
        else
        {
            // ターゲットがプレイヤーでない場合のログを表示
            Debug.Log("Target is not a player!");
            isAttacking = false; // 攻撃終了
        }
    }
    */

    /*
    // アニメーション終了後にダメージを適用するコルーチン
    private System.Collections.IEnumerator ApplyDamageAfterAnimation(Player targetPlayer)
    {
        // 攻撃アニメーションの長さを取得（Animatorに"Attack"の再生時間が必要）
        float attackAnimationTime = animator.GetCurrentAnimatorStateInfo(0).length;

        // アニメーションが完了するまで待機
        yield return new WaitForSeconds(attackAnimationTime);

        // ターゲットにダメージを与える
        targetPlayer.TakeDamage(attackPower);

        // 攻撃終了
        isAttacking = false;
    }
    */
}
