using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Pausa
{
    public class SC_MenuPausa : MonoBehaviour
    {
        public static SC_MenuPausa Instance { get; private set; }

        [Header("Referencias Visuales")]
        [SerializeField] private GameObject pausePanel;
        
        //[Header("Navegación UI")]
        //[SerializeField] private GameObject firstSelectedButton;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            
            if (pausePanel != null) pausePanel.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                TogglePause();
            }
        }
        
        public void TogglePause()
        {
            if (pausePanel.activeSelf) 
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }

        private void PauseGame()
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    
        public void ResumeGame()
        {
            Time.timeScale = 1f; 
            pausePanel.SetActive(false);
        }
    
        public void RestartGame()
        {
            // Es vital devolver el tiempo a la normalidad antes de recargar
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
        public void GoToMainMenu()
        {
            Time.timeScale = 1f;
            
            if (SC_GameManager.Instance != null)
            {
                Destroy(SC_GameManager.Instance.gameObject);
            }

            SceneManager.LoadScene(0); 
        }
    }
}

