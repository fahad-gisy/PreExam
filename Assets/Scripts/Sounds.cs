
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip swordSlash;
 

    public void ShotGunSound()
    {
        audioSource.PlayOneShot(swordSlash);
        
    }
    
    
}
