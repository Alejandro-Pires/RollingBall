using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes_Related
{
    public class SC_WinScreen : MonoBehaviour
    {
        [Header("Configuración")]
        [SerializeField] private int mainMenuSceneIndex = 0;

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                LoadMenu();
            }
        }

        private void LoadMenu()
        {
            SceneManager.LoadScene(mainMenuSceneIndex);
        }
    }
}