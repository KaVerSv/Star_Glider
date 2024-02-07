using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private GameObject player; // Zamiast u¿ywaæ Transform, u¿yjemy GameObject //obiekt gracza

    private void Start()
    {
        // ZnajdŸ obiekt gracza na scenie przy u¿yciu tagu "Player"
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