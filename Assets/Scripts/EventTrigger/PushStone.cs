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

        // �ε����� ��ü�� ������ Ȯ��
        Collider2D hit = Physics2D.OverlapBox(targetPos, Vector2.one * 0.8f, 0f, obstacleLayer);
        if (hit == null)
        {
            transform.position = targetPos;
            Debug.Log("���� �зȽ��ϴ�!");
        }
        else
        {
            Debug.Log("�տ� ��ֹ� ����, �� ��");
        }
    }
}