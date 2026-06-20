using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class SC_MainMenu : MonoBehaviour
    {
        [Header("Configuración")]
        [SerializeField] private int indiceNivelJuego = 1;

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                EmpezarJuego();
            }
        }

        private void EmpezarJuego()
        {
            SceneManager.LoadScene(indiceNivelJuego);
        }
    }
}