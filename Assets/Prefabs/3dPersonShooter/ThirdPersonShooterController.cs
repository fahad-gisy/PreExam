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
    //[SerializeField] private GameObject VfxHitWall;
    //[SerializeField] private GameObject VfxHitBlood;
    private Animator _animator;
    private StarterAssetsInputs _starterAssetsInputs;
    private ThirdPersonController _thirdPersonController;
    
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

        if(_starterAssetsInputs.aim)
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


            if (_starterAssetsInputs.shoot && _starterAssetsInputs.aim)
            {
                _sm.PlayGunShoot();
                //_animator.SetBool("Shoot",true);
                _animator.SetTrigger("PistolShoot");
                if (hitTransform != null)
                {
                    Debug.Log("hit" + hitTransform);
                    if (hitTransform.GetComponent<BulletTarget>() != null)
                    {
                        //Instantiate(VfxHitBlood, transform.position, Quaternion.identity);
                        Debug.Log("hit Enemy" + hitTransform);
                    }
                    else
                    {
                        //Instantiate(VfxHitWall, transform.position, Quaternion.identity);
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
