using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePushableStone : MonoBehaviour
{
    public float moveDistance = 1f;
    public LayerMask obstacleLayer;

    public void TryPush(Vector2 direction)
    {
        Vector2 targetPos = (Vector2)transform.position + direction * moveDistance;

        // 부딪히는 물체가 없는지 확인
        Collider2D hit = Physics2D.OverlapBox(targetPos, Vector2.one * 0.8f, 0f, obstacleLayer);
        if (hit == null)
        {
            transform.position = targetPos;
            Debug.Log("돌이 밀렸습니다!");
        }
        else
        {
            Debug.Log("앞에 장애물 있음, 못 밈");
        }
    }
}