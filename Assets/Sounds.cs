
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shotGun;
    [SerializeField] private AudioClip enemyHit;
    [SerializeField] private AudioClip playerDmg;
    [SerializeField] private AudioClip EnemySteps;

    public void ShotGunSound()
    {
        audioSource.PlayOneShot(shotGun);
        
    }
    

    public void EnemyHit()
    {
        audioSource.PlayOneShot(enemyHit);
    }

    public void PlayerDamage()
    {
        audioSource.PlayOneShot(playerDmg);
    }
    
    public void EnemyStepsSound()
    {
        // audioSource.clip = EnemySteps;
        audioSource.PlayOneShot(EnemySteps);
    }
    
}
