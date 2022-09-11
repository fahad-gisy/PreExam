
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public class SelektonEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private  Transform playerTransform;
    private static GameObject _gameObject;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Attack1 = Animator.StringToHash("Attack");

   
 
    

    public enum EenemyState
    {
        
        Wandering,
        Following,
        AtPlayerPos,
        Attack,
    }

    private EenemyState _eenemyState = EenemyState.Following;
    

    void Awake()
    {
        
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        
    }
    // Update is called once per frame
    void Update()
    {
       
        
        switch (_eenemyState)
        {
            case EenemyState.Following:
                Following();
                break;
            case EenemyState.Attack:
                Attack();
                break;
        }
        
    }

    private void Following()
    {
        float distence = Vector3.Distance(playerTransform.transform.position,transform.position);
        
        if (distence <= 20f)
        {
            _agent.destination = playerTransform.position;
            _animator.SetBool(Walking,true);
            if (distence <= 2f)
            {
                _eenemyState = EenemyState.Attack;
            }
        }else if (distence >= 20f)
        {
            _agent.destination = transform.position;
            _animator.SetBool(Attack1,false);
            _animator.SetBool(Walking,false);
        }
        
        
    }

    private void Attack()
    {
        _animator.SetBool(Walking,false);

        _agent.destination = transform.position;
        
        _animator.SetBool(Attack1,true);
    }
}
