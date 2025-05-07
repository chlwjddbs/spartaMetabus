using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyPlane
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;

        public GameObject GameOverUI;

        // Start is called before the first frame update
        void Start()
        {
            if (GameOverUI == null)
            {
                Debug.LogError("gameoverUI is null");
            }

            if (scoreText == null)
            {
                Debug.LogError("score text is null");
            }

            GameOverUI.gameObject.SetActive(false);
        }

        public void SetGameOverUI()
        {
            GameOverUI.gameObject.SetActive(true);
        }

        public void UpdateScore(int socre)
        {
            scoreText.text = socre.ToString();
        }
    }
}