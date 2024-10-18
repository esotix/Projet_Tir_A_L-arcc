using UnityEngine;

public class Cible : MonoBehaviour
{
    private TargetSpawner spawner;
    private AudioSource audioSource;
    public GameObject explosionEffect;  // R�f�rence au prefab du Particle System
    public float explosionDuration = 2f;  // Dur�e de l'explosion

    void Start()
    {
        spawner = FindObjectOfType<TargetSpawner>();
        audioSource = GetComponent<AudioSource>();

        // Joue le son � l'apparition
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    // D�tection des collisions
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // D�clenche l'effet de particules
            TriggerExplosion();

            // D�truit la cible
            Destroy(gameObject);

            // Informe le spawner qu'une cible a �t� d�truite
            spawner.OnCibleDestroyed(gameObject);
        }
    }

    // M�thode pour d�clencher l'explosion
    void TriggerExplosion()
    {
        // Instancie l'effet d'explosion � la position de la cible
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, explosionDuration);  // D�truit l'explosion apr�s un d�lai
        }
    }
}
