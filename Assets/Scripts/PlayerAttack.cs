using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;

    private Camera mainCam;

    private GameObject crosshair;

    private bool is_Aiming;

    [SerializeField]
    private GameObject arrow_Prefab, spear_Prefab;

    [SerializeField]
    private Transform arrow_Bow_StartPosition;

    void Awake()
    {

        weapon_Manager = GetComponent<WeaponManager>();

        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();


        mainCam = Camera.main;

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
    
    }

    void WeaponShoot()
    {

       
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {

            
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {

                nextTimeToFire = Time.time + 1f / fireRate;

                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                BulletFired();

            }


           
        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {

                
                

              
                if (weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {

                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    BulletFired();

                }
                else
                {

              
                    if (is_Aiming)
                    {

                        weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                        if (weapon_Manager.GetCurrentSelectedWeapon().bulletType
                           == WeaponBulletType.ARROW)
                        {

                            
                        }
                        else if (weapon_Manager.GetCurrentSelectedWeapon().bulletType
                                == WeaponBulletType.SPEAR)
                        {

                            

                        }

                    }

                } 


            } 

        } 

    } 

   

    


  

    void BulletFired()
    {

        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {

            if (hit.transform.tag == Tags.ENEMY_TAG)
            {
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }

        }

    } // bullet fired

} 