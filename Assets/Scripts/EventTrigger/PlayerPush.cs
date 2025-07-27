using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPush : MonoBehaviour
{
    public float interactDistance = 1f;
    public LayerMask interactableLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPushInAllDirections();
        }
    }

    void TryPushInAllDirections()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        foreach (Vector2 dir in directions)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, interactDistance, interactableLayer);
            Debug.DrawRay(transform.position, dir * interactDistance, Color.red, 0.5f);

            if (hit.collider != null)
            {
                Debug.Log("Ray hit " + dir + " → " + hit.collider.name);

                var pushable = hit.collider.GetComponent<InteractablePushableStone>();
                if (pushable != null)
                {
                    pushable.TryPush(dir);
                    return; // 하나만 밀고 끝내기
                }
            }
        }

        Debug.Log("Raycast miss in all directions");
    }
}