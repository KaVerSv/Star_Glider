using UnityEngine;

public class HealthBar : MonoBehaviour, IObserver
{
    public ProgressBar healthBar;

    private PlayerHealth playerHealth;

    // Pole do przypisania obiektu do œledznienia
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {

        if (playerObject != null)
        {
            PlayerHealth playerHealthComponent = playerObject.GetComponent<PlayerHealth>();

            SetPlayerHealth(playerHealthComponent);

            float pHealth = playerHealthComponent.getMaxHealth();
            float maxHealth = playerHealthComponent.getMaxHealth();

            if (healthBar != null)
            {
                healthBar.BarValue = (pHealth * 100) / maxHealth;
            }
        }
    }

    public void UpdateObserver()
    {
        float pHealth = playerHealth.getHealth();
        float maxHealth = playerHealth.getMaxHealth();

        if (healthBar != null)
        {
            healthBar.BarValue = (pHealth * 100) / maxHealth;
        }
    }

    private void SetPlayerHealth(PlayerHealth health)
    {
        playerHealth = health;

        // Subskrybcja obserwatora
        if (playerHealth != null)
        {
            playerHealth.AddObserver(this);
        }
    }
}