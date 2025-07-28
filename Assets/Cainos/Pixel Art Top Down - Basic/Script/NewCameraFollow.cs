using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    public Transform target;      
    public float smoothSpeed = 5f; 
    public Vector2 minBounds;     
    public Vector2 maxBounds;     

    private Vector3 offset;      

    void Start()
    {
        // 초기 거리 설정 (보통 z 축만 -10)
        offset = transform.position - target.position;
    }

    // LateUpdate()를 사용하는 이유는 모든 캐릭터 이동이 끝난 후에 카메라가 따라가는 연출을 만들기 위함
    void LateUpdate()
    {
        // 따라가야 할 위치 계산 (z는 유지)
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

        // 위치 제한 적용
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }
}