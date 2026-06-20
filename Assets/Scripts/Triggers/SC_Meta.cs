using Managers;
using UnityEngine;

namespace Scenes_Related
{
    public class SC_Meta : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            if (SC_GameManager.Instance != null)
            {
                SC_GameManager.Instance.WinGame();
            }
        }
    }
}
