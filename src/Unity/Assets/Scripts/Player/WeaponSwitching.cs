using UnityEngine;
public class WeaponSwitching : MonoBehaviour
{
    public int weaponSelected = 0;
    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        int previousSelectedWeapon = weaponSelected;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponSelected >= transform.childCount - 1) weaponSelected = 0;
            else ++weaponSelected;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponSelected <= 0) weaponSelected = transform.childCount - 1;
            else --weaponSelected;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) weaponSelected = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) weaponSelected = 1;
        if (previousSelectedWeapon != weaponSelected) SelectWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponSelected) weapon.gameObject.SetActive(true);
            else weapon.gameObject.SetActive(false);
            ++i;
        }
    }

}
