using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemySk : MonoBehaviour
{
    // public Transform target;
    public float turnSpeed = .01f;
    Quaternion rotGoal;
    private Vector3 direction;
    
    private Animator _animator;
    private NavMeshAgent _agent;
    private Rigidbody rb;
    [SerializeField] private GameObject player;
    
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int AttackT = Animator.StringToHash("AttackT");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int AttackIndex = Animator.StringToHash("AttackIndex");


    private float distence
    {
        get { return Vector3.Distance(transform.position, player.transform.position); }
    }


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        //smother look at
        direction = (player.transform.position - transform.position).normalized; // target's pos - this.pos > direction vector
        rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
    }

    private void LateUpdate()
    {
        _agent.updateRotation = false;
        if (distence <= 10)
        {
            FollowPlayer();
        }else if (distence >= 10)
        {
            _agent.SetDestination(transform.position);
            _animator.SetBool(Walking,false);
        }
    }

    private void FollowPlayer()
    {
        
            _animator.SetBool(Walking,true);
            _agent.destination = player.transform.position;
            if (distence <= 2)
            {
                _animator.SetBool(Walking,false);
                StartCoroutine(StartAttack());
            }
            
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(0.5f);
        
        _animator.SetInteger(AttackIndex,Random.Range(0,3));
        _animator.SetTrigger(AttackT);
        
        if (distence >= 2)
        {
            _animator.SetBool(Attack,false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            rb.drag = 5;
        }
    }
}
