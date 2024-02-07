using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private float maxHealth = 1200.0f;
    /*
    [SerializeField] private float maxShields = 800.0f;
    [SerializeField] private float rechargeTime = 60.0f;
    */
    [SerializeField] private int score_points = 1;

    private float pHealth;
    //private float shields;
    //private bool isRecharging = false;
    //rate of reacharge when shields are active is reduced
    //private float rechargeRate = 0.5f;

    //PlayerBar
    //public ProgressBar healthBar;
    public ProgressBar shieldBar;

    //lista obserwatorów stanu zdrowia jednostki
    private List<IObserver> observers = new List<IObserver>();

    void Start()
    {
        pHealth = maxHealth;
        //shields = maxShields;
        /*
        if ( healthBar != null )
        {
            healthBar.BarValue = (pHealth * 100) / maxHealth;
        }*/
        
        //shieldBar.BarValue = (shields*100)/maxShields;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public float getHealth()
    {
        return pHealth;
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.UpdateObserver();
        }
    }

    /*
    IEnumerator RechargeShields()
    {
        float startTime = Time.time;

        while (shields < maxShields)
        {
            float elapsedTime = Time.time - startTime;
            float progress = elapsedTime / rechargeTime;

            if (isRecharging)
            {
                shields = Mathf.Lerp(0.0f, maxShields, progress) + (rechargeRate * maxShields * elapsedTime);
            }
            else
            {
                shields = Mathf.Lerp(0.0f, maxShields, progress);
            }
            shieldBar.BarValue = (shields * 100) / maxShields;
            yield return null; // wait for next frame
        }

        shields = maxShields;
        isRecharging = false;
        shieldBar.BarValue = (shields * 100) / maxShields;
    }
    */
    /*

    //multiplayer depends on module hit
    public void ReciveDamage(float dmg)
    {
        if (isRecharging == false)
        { 
            if (dmg > shields)
            {
                dmg -= shields;
                shields = 0;
                isRecharging = true;
                StartCoroutine(RechargeShields());
                pHealth -= dmg;

                if (pHealth <= 0)
                {
                    Die();
                }
            }
            else
            {
                shields -= dmg;
                StartCoroutine(RechargeShields());
            }
        }
        else
        {
            pHealth -= dmg;
            if (pHealth <= 0)
            {
                Die();
            }
        }

        healthBar.BarValue = (pHealth * 100) / maxHealth;
        shieldBar.BarValue = (shields * 100) / maxShields;
    }
    */

    public void Die()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            ScoreManger.Instance.addPoints(score_points);
        }
        Destroy(gameObject);
    }

    /*
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReciveDamage(50f);
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            ReciveDamage(50f);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            ReciveDamage(50f);
        }

    }
    */

    //no shield version
    //multiplayer depends on module hit
    public void ReciveDamage(float dmg)
    {
        
        pHealth -= dmg;
        NotifyObservers();
        if (pHealth <= 0)
        {
            Die();
        }
        
        
        /*
        if ( healthBar != null )
        {
            healthBar.BarValue = (pHealth * 100) / maxHealth;
        }
        */
    }
}


