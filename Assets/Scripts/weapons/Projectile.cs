using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float bound = 500.0f;
    [SerializeField] float damage = 15.0f;
    [SerializeField] private string bulletTag;

    void Update()
    {
        if (transform.position.x > bound || transform.position.x < -bound ||
            transform.position.y > bound || transform.position.y < -bound ||
            transform.position.z > bound || transform.position.z < -bound)
        {
            Destroy(gameObject);
        }
    }

    /*
    public void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ, czy obiekt ma tag "Enemy"
        if (collision.collider.CompareTag(bulletTag))
        {
            if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth target))
            {
                target.ReciveDamage(damage);
            }
        }

        // Zniszcz obecn¹ kulê po zderzeniu
        Destroy(gameObject);
    }
    */

    public void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy obiekt ma tag "Enemy"
        if (other.CompareTag(bulletTag))
        {
            if (other.TryGetComponent<PlayerHealth>(out PlayerHealth target))
            {
                target.ReciveDamage(damage);
            }
        }
        // Zniszcz obecn¹ kulê po zderzeniu
        Destroy(gameObject);

        // Nie zniszczaj obiektu, nawet jeœli ma tag "Player"
        // Poniewa¿ ustawiliœmy Collider jako Trigger, obiekt bêdzie przenika³ przez inne obiekty
    }
}