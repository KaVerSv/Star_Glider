using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] Projectile _projectilePrefab;
    [SerializeField] Transform _muzzle;

    [SerializeField] float fireRate = 0.8f;

    WeaponsControlls controls;
    private bool readyToShoot = true;

    void Start()
    {

    }

    private void Awake()
    {
        controls = new WeaponsControlls();
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (controls.WeaponControls.Shoot.IsPressed() && readyToShoot == true)
        {
            FireProjectile();
            readyToShoot = false;

            Invoke("ResetShoot", fireRate);
        }

    }

    private void ResetShoot()
    {
        readyToShoot = true;
    }

    void FireProjectile()
    {
        Instantiate(_projectilePrefab, _muzzle.position, transform.rotation);
    }

    private void OnEnable()
    {
        controls.WeaponControls.Enable();
    }

    private void OnDisable()
    {
        controls.WeaponControls.Disable();
    }
}
