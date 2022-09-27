using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] float _pistolCd=1f;
    float lastShot =0f;
    [SerializeField] private CinemachineVirtualCamera _aimVirtualCamera;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private SoundManager _sm;
    [SerializeField] private MultiAimConstraint _aimConstrained;
    [SerializeField] private GameObject bulletImpact;
    [SerializeField] private float bulletImpactDuration;
    //[SerializeField] private GameObject VfxHitWall;
    //[SerializeField] private GameObject VfxHitFlash;
    private Animator _animator;
    public bool canAim = false;
    [SerializeField] public GameObject gun;
    private StarterAssetsInputs _starterAssetsInputs;
    private ThirdPersonController _thirdPersonController;
    [SerializeField] private GameObject muzzleEffect;
    [SerializeField] private GameObject muzzleSpwan;
    [SerializeField] private GameObject mapPuzzleP1;
    [SerializeField] private GameObject mapPuzzleP2;
    [SerializeField] private GameObject mapPuzzleP3;
    
    void Start()
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        if(_starterAssetsInputs.aim && canAim)
        {
            _animator.SetLayerWeight(1,Mathf.Lerp(_animator.GetLayerWeight(1),1f,Time.deltaTime*20f));
            _thirdPersonController.SetRotateOnMove(false);
            _aimVirtualCamera.gameObject.SetActive(true);
            _aimConstrained.weight = 1f;
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            _animator.SetLayerWeight(1,Mathf.Lerp(_animator.GetLayerWeight(1),0f,Time.deltaTime*20f));
            _aimVirtualCamera.gameObject.SetActive(false);
            _thirdPersonController.SetRotateOnMove(true);
            _aimConstrained.weight = 0f;
        }
        
        if (Time.time>lastShot)
        {


            if (_starterAssetsInputs.shoot && _starterAssetsInputs.aim&& canAim)
            {
               
                _sm.PlayGunShoot();
                
                Instantiate(muzzleEffect, muzzleSpwan.transform.position, muzzleSpwan.transform.rotation);
                
                GameObject impact = Instantiate(bulletImpact, raycastHit.point + (raycastHit.normal * 0.002f),
                    Quaternion.LookRotation(raycastHit.normal, Vector3.up));
                Destroy(impact,bulletImpactDuration);
                
                //_animator.SetBool("Shoot",true);
                _animator.SetTrigger("PistolShoot");
                if (hitTransform != null)
                {
                    if (hitTransform.CompareTag("MoveUp"))
                    {
                        mapPuzzleP1.transform.position = new Vector3(mapPuzzleP1.transform.position.x,mapPuzzleP1.transform.position.y + 3,mapPuzzleP1.transform.position.z);
                    }
                    
                    if (hitTransform.CompareTag("MoveDown"))
                    {
                        mapPuzzleP1.transform.position = new Vector3(mapPuzzleP1.transform.position.x,mapPuzzleP1.transform.position.y - 3,mapPuzzleP1.transform.position.z);
                    }
                    
                    if (hitTransform.CompareTag("MoveRotY"))
                    {
                        mapPuzzleP2.transform.Rotate(0,35,0);
                    }
                    
                    if (hitTransform.CompareTag("MoveRight"))
                    {
                        mapPuzzleP3.transform.position = new Vector3(mapPuzzleP3.transform.position.x - 3 ,mapPuzzleP3.transform.position.y,mapPuzzleP3.transform.position.z);
                    }
                    
                    if (hitTransform.CompareTag("MoveLeft"))
                    {
                        mapPuzzleP3.transform.position = new Vector3(mapPuzzleP3.transform.position.x + 3 ,mapPuzzleP3.transform.position.y,mapPuzzleP3.transform.position.z);
                    }
                    
                    Debug.Log("hit" + hitTransform);
                    if (hitTransform.GetComponent<BulletTarget>() != null)
                    {
                       // Destroy(hitTransform.gameObject);
                       GameManager.instance.hpAmount -= 50.0f * Time.deltaTime;
                       Debug.Log(hitTransform);
                    }
                    else
                    {
                        Debug.Log("hit Something else" + hitTransform);
                    }
                }


                _starterAssetsInputs.shoot = false;
                //_animator.SetBool("Shoot",false);

                lastShot = Time.time + _pistolCd;
            }
        }
    }

    
}
