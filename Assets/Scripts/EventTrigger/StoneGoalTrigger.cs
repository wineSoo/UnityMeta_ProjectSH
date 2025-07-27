using UnityEngine;
using UnityEngine.Events;

public class StoneGoalTrigger : MonoBehaviour
{
    public Transform targetStone;        // 감지할 돌 (Rune Pillar Broken)
    public float triggerDistance = 0.1f; // 얼마나 가까우면 도착으로 볼지
    public UnityEvent onStonePlaced;     // 이벤트 트리거 (인스펙터에서 연결 가능)

    private bool triggered = false;

    void Update()
    {
        if (triggered) return;

        float distance = Vector2.Distance(transform.position, targetStone.position);
        if (distance < triggerDistance)
        {
            Debug.Log("돌이 목표 지점에 도달함!");
            triggered = true;
            onStonePlaced?.Invoke(); // 연결된 이벤트 실행
        }
    }
}