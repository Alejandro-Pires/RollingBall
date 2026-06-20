using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Pausa
{
    public class SC_ButtonSound : MonoBehaviour, IPointerEnterHandler, ISelectHandler
    {
        [Header("Sonidos UI")]
        [SerializeField] private AudioSource uiAudioSource; 
        [SerializeField] private AudioClip hoverSound;
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            PlaySound();
        }
    
        public void OnSelect(BaseEventData eventData)
        {
            PlaySound();
        }
    
        private void PlaySound()
        {
            if (uiAudioSource != null && hoverSound != null)
            {
                uiAudioSource.PlayOneShot(hoverSound);
            }
        }
    }
}