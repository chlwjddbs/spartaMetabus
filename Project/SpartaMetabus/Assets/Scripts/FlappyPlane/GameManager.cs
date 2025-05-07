using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyPlane
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private void Awake()
        {
            Instance = this;
            uiManager = FindObjectOfType<UIManager>();
        }

        private int currentSocre = 0;

        private UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }

        private void Start()
        {
            uiManager.UpdateScore(0);
        }

        public void GameOver()
        {
            Debug.Log("게임 오버");
            uiManager.SetGameOverUI();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        public void ReturnHome()
        {
            SceneManager.LoadScene("MainScene");
        }

        public void AddSocre(int socre)
        {
            currentSocre += socre;
            Debug.Log("Socre" + currentSocre);
            uiManager.UpdateScore(currentSocre);
        }
    }
}