using UnityEngine;

public class SC_CambioCamara : MonoBehaviour
{
    [Header("Configuración de Cámaras")]
    [SerializeField] private GameObject camaraActivar;
    [SerializeField] private GameObject camaraDesactivar;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        if (camaraActivar != null) camaraActivar.SetActive(true);
        
        if (camaraDesactivar != null) camaraDesactivar.SetActive(false);
    }
}