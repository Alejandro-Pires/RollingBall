using UnityEngine;
using Managers;

namespace Scenes_Related
{
    public class SC_ZonaMuerte : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            if (SC_GameManager.Instance == null)
            {
                Debug.LogWarning("¡Te has caído pero no hay GameManager en la escena!");
            }
            else
            {
                SC_GameManager.Instance.GameOver();
            }
        }
    }
}