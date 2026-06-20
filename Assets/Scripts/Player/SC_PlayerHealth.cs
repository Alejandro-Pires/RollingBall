using UnityEngine;
using Managers;

namespace Player
{
    public class SC_PlayerHealth : MonoBehaviour, IHittable
    {
        [Header("Stats")] [SerializeField] private int maxHealth = 3;
        private int currentHealth;

        [Header("SFX Settings")] [SerializeField]
        private AudioClip clipGolpe;

        [SerializeField] private AudioClip clipMuerte;
        private AudioSource audioSource;

        [Header("UI")] [SerializeField] private GameObject[] heartsSprite;

        private bool isDead = false;

        private void Awake()
        {
            currentHealth = maxHealth;
            audioSource = GetComponentInParent<AudioSource>();
            UpdateHeartsUI();
        }

        public void Damage(float damage, Transform attacker)
        {
            if (isDead) return;

            int dmg = Mathf.RoundToInt(damage);
            currentHealth -= dmg;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            if (audioSource != null && clipGolpe != null)
            {
                audioSource.PlayOneShot(clipGolpe);
            }

            UpdateHeartsUI();

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void UpdateHeartsUI()
        {
            for (int i = 0; i < heartsSprite.Length; i++)
            {
                heartsSprite[i].SetActive(i < currentHealth);
            }
        }

        private void Die()
        {
            if (isDead) return;
            isDead = true;

            if (audioSource != null && clipMuerte != null)
            {
                audioSource.PlayOneShot(clipMuerte);
            }

            // 1. Se apagan los controles de la bola
            SC_Player scriptMovimiento = GetComponent<SC_Player>();
            if (scriptMovimiento != null) scriptMovimiento.enabled = false;

            // 2. Frenar la bola
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null) rb.linearVelocity = Vector3.zero;

            SC_GameManager.Instance.GameOver();
        }
    }
}