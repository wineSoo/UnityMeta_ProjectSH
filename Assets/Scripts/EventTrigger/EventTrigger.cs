using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject pressETextUI;

    private bool playerInZone = false;

    private void Start()
    {
        // 게임 시작 시 UI 텍스트 비활성화
        if (pressETextUI != null)
        {
            pressETextUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E 키 입력 감지됨. 이벤트 실행!");
            // 나중에 여기에 미니게임 전환 코드 넣기
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;

            if (pressETextUI != null)
            {
                pressETextUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;

            if (pressETextUI != null)
            {
                pressETextUI.SetActive(false);
            }
        }
    }
}