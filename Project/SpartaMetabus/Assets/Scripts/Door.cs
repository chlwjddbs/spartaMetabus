using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer doorSprite;
    [SerializeField] Sprite closeDoor;
    [SerializeField] Sprite openDoor;

    [SerializeField] private BoxCollider2D doorCollider;

    [SerializeField] private LayerMask layerMask;

    private bool isOpen;

    private bool isEnter;

    private string openDoorNotice = "Press \"E\" Key to Open Door";
    private string closeDoorNotice = "Press \"E\" Key to Close Door";

    private void Start()
    {
        doorSprite = GetComponent<SpriteRenderer>();
        CloseDoor();
    }

    private void Update()
    {
        if (isEnter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleDoor();
            }
        }
    }

    private void ToggleDoor()
    {
        if (!isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        doorSprite.sprite = openDoor;
        doorCollider.enabled = false;
        UIManager.Instance.SetNotice(closeDoorNotice);
    }

    private void CloseDoor()
    {
        isOpen = false;
        doorSprite.sprite = closeDoor;
        doorCollider.enabled = true;
        UIManager.Instance.SetNotice(openDoorNotice);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((layerMask & (1 << collision.gameObject.layer)) != 0)
        {
            isEnter = true;
            UIManager.Instance.OpenNotice(openDoorNotice);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((layerMask & (1 << collision.gameObject.layer)) != 0)
        {
            isEnter = false;
            CloseDoor();
            UIManager.Instance.CloseNotice();
        }
    }
}
