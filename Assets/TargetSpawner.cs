using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject cible;  // Le prefab de la cible
    public Transform player;  // Le joueur autour duquel les cibles apparaissent
    public float spawnRadius = 10f;  // Rayon autour du joueur
    public float spawnHeight = 5f;   // Hauteur à laquelle les cibles apparaissent
    private List<GameObject> activeCibles = new List<GameObject>(); // Liste des cibles actives
    private int maxCibles = 5;

    void Start()
    {
        // Crée les cibles initiales
        for (int i = 0; i < maxCibles; i++)
        {
            SpawnTarget();
        }
    }

    void SpawnTarget()
    {
        // Génère une position aléatoire autour du joueur
        Vector3 randomPos = player.position + (Random.insideUnitSphere * spawnRadius);
        randomPos.y = spawnHeight;  // Place la cible en hauteur

        // Instancie la cible et l'ajoute à la liste
        GameObject newCible = Instantiate(cible, randomPos, Quaternion.identity);
        activeCibles.Add(newCible);
    }

    public void OnCibleDestroyed(GameObject cibleDetruite)
    {
        // Retire la cible détruite de la liste
        activeCibles.Remove(cibleDetruite);

        // Réinstancie la cible après 1 seconde
        StartCoroutine(RespawnTarget());
    }

    IEnumerator RespawnTarget()
    {
        yield return new WaitForSeconds(1f);
        SpawnTarget();
    }
}
