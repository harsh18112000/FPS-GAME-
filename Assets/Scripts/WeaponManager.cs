using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    [SerializeField]
    private WeaponHandler[] weapons;

    private int current_Weapon_Index;

  
    void Start()
    {
        current_Weapon_Index = 0;
        weapons[current_Weapon_Index].gameObject.SetActive(true);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }

        
    } 

    void TurnOnSelectedWeapon(int weaponIndex)
    {

        if (current_Weapon_Index == weaponIndex)
            return;

        
        weapons[current_Weapon_Index].gameObject.SetActive(false);

        
        weapons[weaponIndex].gameObject.SetActive(true);

        
        current_Weapon_Index = weaponIndex;

    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        return weapons[current_Weapon_Index];
    }

} 