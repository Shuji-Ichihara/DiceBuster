using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExsampleDiceText : MonoBehaviour
{
    public int totalSteps;  // サイコロの出目（合計移動可能マス数）

    public int remainingSteps;  // 残りの移動マス数

    public Transform[] boardTiles; // すごろくのマス（タイル）のTransform配列
    private int currentTileIndex = 0; // 現在のマス番号 // サイコロを振る処理
    public void RollDice() 
    { 
        totalSteps = Random.Range(1, 7); // 1～6の出目
        remainingSteps = totalSteps; NotifyStepChange(); // 残りマス数の変更を通知
    } 
    // マスを1つ進む処理
    public void MovePlayer() 
    { 
        if (remainingSteps > 0 && currentTileIndex < boardTiles.Length - 1) 
        { 
            currentTileIndex++; // 次のマスへ
            transform.position = boardTiles[currentTileIndex].position; // 位置を変更
            remainingSteps--; // 残りマス数を減らす
            NotifyStepChange(); // 残りマス数の変更を通知
        } 
    } 
    // 残りマス数の変更を通知
    private void NotifyStepChange() 
    {
        // MassMoveCountTextに通知
        MassMoveCountText.Instance.UpdateText(remainingSteps); 
    }

}
