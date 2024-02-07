using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;

    private float nextFireTime;

    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        // SprawdŸ, czy warstwa obiektu, na który strzelamy, nie jest t¹ sam¹, co warstwa przeciwnika
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int bulletLayer = bulletPrefab.layer;

        if (bulletLayer != enemyLayer)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}