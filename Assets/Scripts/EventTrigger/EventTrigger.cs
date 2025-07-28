using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerZone : MonoBehaviour
{
    public GameObject pressETextUI;

    private bool playerInZone = false;

    private void Start()
    {
        // ���� ���� �� UI �ؽ�Ʈ ��Ȱ��ȭ
        if (pressETextUI != null)
        {
            pressETextUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("FlappyBirdScene");
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