using UnityEngine;

namespace UI.MainMenu
{
    public class SC_TextoAnimado : MonoBehaviour
    {
        [Header("Configuración de Escala")]
        
        [Tooltip("Velocidad de latido")]
        [SerializeField] private float velocidadEscala = 3f;
        
        [Tooltip("Distancia de latido")]
        [SerializeField] private float magnitudEscala = 0.05f;

        private Vector3 escalaInicial;

        void Start()
        {
            escalaInicial = transform.localScale;
        }

        void Update()
        {
            // Mathf.Sin para crear una onda suave que va de -1 a 1 con el paso del tiempo
            float variacion = Mathf.Sin(Time.time * velocidadEscala) * magnitudEscala;
        
            //cálculo final del cambio de tamaño
            transform.localScale = escalaInicial + new Vector3(variacion, variacion, variacion);
        }
    }
}