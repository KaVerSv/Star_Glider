using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private GameObject player; // Zamiast u�ywa� Transform, u�yjemy GameObject //obiekt gracza

    private void Start()
    {
        // Znajd� obiekt gracza na scenie przy u�yciu tagu "Player"
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            AimAtPlayer();
        }
    }

    private void AimAtPlayer()
    {
        transform.LookAt(player.transform);
    }
}