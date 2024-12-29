using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ステータス
    public int health = 100; // エネミーの体力
    public int attackPower = 10; // エネミーの攻撃力

    // アニメーション用
    private Animator animator;
    private bool isAttacking = false; // 攻撃中フラグ

    private void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
    }

    // 攻撃を受けるメソッド
    // 引数で指定されたダメージ量だけ体力を減らし、体力が0以下になると死亡する
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

    // 死亡メソッド
    // エネミーが死亡した際に呼び出され、ログを表示してオブジェクトを削除する
    private void Die()
    {
        // 死亡ログを表示
        Debug.Log("Enemy has died.");

        Destroy(gameObject, 1f); // 1秒後に削除
    }

    // 敵を攻撃するメソッド
    // 引数で指定されたターゲットがエネミーである場合、そのエネミーに攻撃力分のダメージを与える
    public void AttackTarget(GameObject target)
    {
        // 攻撃中でない場合のみ実行
        if (isAttacking) return;

        // 攻撃を開始
        isAttacking = true;

        // ターゲットのEnemyコンポーネントを取得
        Enemy targetEnemy = target.GetComponent<Enemy>();

        // ターゲットがエネミーの場合
        if (targetEnemy != null)
        {
            // 攻撃ログを表示
            Debug.Log("Attacking target with power: " + attackPower);

            // 攻撃アニメーションを再生
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }

            // アニメーション終了時にダメージを与える処理をコルーチンで実行
            StartCoroutine(ApplyDamageAfterAnimation(targetEnemy));
        }
        else
        {
            // ターゲットがエネミーでない場合のログを表示
            Debug.Log("Target is not an enemy!");
            isAttacking = false; // 攻撃終了
        }
    }

    // アニメーション終了後にダメージを適用するコルーチン
    private System.Collections.IEnumerator ApplyDamageAfterAnimation(Enemy targetEnemy)
    {
        // 攻撃アニメーションの長さを取得（Animatorに"Attack"の再生時間が必要）
        float attackAnimationTime = animator.GetCurrentAnimatorStateInfo(0).length;

        // アニメーションが完了するまで待機
        yield return new WaitForSeconds(attackAnimationTime);

        // ターゲットにダメージを与える
        targetEnemy.TakeDamage(attackPower);

        // 攻撃終了
        isAttacking = false;
    }
}
