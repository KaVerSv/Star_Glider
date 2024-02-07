using UnityEditor;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public int selectedWeapon = 0;
    WeaponsControlls controls;
    
    void Start()
    {
        SelectWeapon();
    }

    private void Awake()
    {
        controls = new WeaponsControlls();
    }

    void Update()
    {
        int previousSelected = selectedWeapon;

        if (controls.WeaponControls.WeaponChange.WasPressedThisFrame())
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;

            }
        }

        if (previousSelected != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    /* Method to select active wepon
     * method activates next weapon and deactivates rest
     */
    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform module in transform)
        {
            if (i == selectedWeapon)
            {
                foreach (Transform weapon in module)
                {
                    weapon.gameObject.GetComponent<Blaster>().enabled = true;
                }
            }
            else
            {
                foreach (Transform weapon in module)
                {
                    weapon.gameObject.GetComponent<Blaster>().enabled = false;
                }
            }
            i++;
        }
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
