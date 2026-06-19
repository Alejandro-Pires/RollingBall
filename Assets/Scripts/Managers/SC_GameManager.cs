using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SC_GameManager : MonoBehaviour
    {
        public static SC_GameManager Instance { get; private set; }

        [Header("Configuración de Respawn")]
        [SerializeField] private float respawnDelay = 2f; 
        [SerializeField] private float winDelay = 1.5f;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void GameOver()
        {
            StartCoroutine(RespawnRoutine());
        }

        public void WinGame()
        {
            StartCoroutine(WinRoutine());
        }
    
        private IEnumerator RespawnRoutine()
        {
            yield return new WaitForSeconds(respawnDelay);
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
        private IEnumerator WinRoutine()
        {
            yield return new WaitForSeconds(winDelay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}