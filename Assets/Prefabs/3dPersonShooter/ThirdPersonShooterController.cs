using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _aimVirtualCamera;
    private StarterAssetsInputs _starterAssetsInputs;
    void Start()
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_starterAssetsInputs.aim)
        {
           _aimVirtualCamera.gameObject.SetActive(true);
        }
        else
        {
            _aimVirtualCamera.gameObject.SetActive(false);
        }
    }
}
