using UnityEngine;
using UnityEngine.Events;

public class StoneGoalTrigger : MonoBehaviour
{
    public Transform targetStone;        // ������ �� (Rune Pillar Broken)
    public float triggerDistance = 0.1f; // �󸶳� ������ �������� ����
    public UnityEvent onStonePlaced;     // �̺�Ʈ Ʈ���� (�ν����Ϳ��� ���� ����)

    private bool triggered = false;

    void Update()
    {
        if (triggered) return;

        float distance = Vector2.Distance(transform.position, targetStone.position);
        if (distance < triggerDistance)
        {
            Debug.Log("���� ��ǥ ������ ������!");
            triggered = true;
            onStonePlaced?.Invoke(); // ����� �̺�Ʈ ����
        }
    }
}