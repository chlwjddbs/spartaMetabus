using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private bool isEnter;

    [SerializeField] private string playeNotice = "Press \"E\" Key to Start Play Flappy Plane";
    [SerializeField] private string playGameSceneName = "FlappyPlaneScene";

    private void Update()
    {
        if (isEnter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayGame();
            }
        }
    }

    public void PlayGame()
    {
        GameManager.Instance.SaveLastPos();
        SceneManager.LoadScene(playGameSceneName);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layerMask & (1 << collision.gameObject.layer)) != 0)
        {
            isEnter = true;
            UIManager.Instance.OpenNotice(playeNotice);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((layerMask & (1 << collision.gameObject.layer)) != 0)
        {
            isEnter = false;
            UIManager.Instance.CloseNotice();
        }
    }
}
