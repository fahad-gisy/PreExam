using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnim : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject SwordInBack;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("hit1"))
        {
            anim.SetBool("hit1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("hit2"))
        {
            
            anim.SetBool("hit2", false);
        }
        
        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("hit3"))
        {
            Sword.SetActive(false);
            SwordInBack.SetActive(true);
            
            anim.SetBool("hit3", false);
            noOfClicks = 0;
        }
        
        
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
 
        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                Sword.SetActive(true);
                SwordInBack.SetActive(false);
                OnClick();
            }
        }
    }
    
    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            StartCoroutine(SwordSoundDelay());
            anim.SetLayerWeight(1,1);
            anim.SetBool("hit1", true);
            
        }

        IEnumerator SwordSoundDelay()
        {
            yield return new WaitForSeconds(0.6f);
            GameManager.instance.SwordSlashSound();
        }
        
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
 
        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("hit1"))
        {
            StartCoroutine(SwordSoundDelay());
            anim.SetLayerWeight(1,1);
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", true);
            
        }
        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("hit2"))
        {
            StartCoroutine(SwordSoundDelay());
            anim.SetLayerWeight(1,1);
            anim.SetBool("hit2", false);
            anim.SetBool("hit3", true);
        }
    }
}
