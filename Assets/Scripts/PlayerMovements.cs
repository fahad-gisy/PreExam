
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    public CharacterController characterController;
    private Vector3 Velcoity;
    public float gravity = -9.81f;
    [SerializeField] private float mouseSpeed;
    public Transform playerTransform;
   [SerializeField] private LayerMask layerMask;
   [SerializeField] private GameObject groundCheck;
   [SerializeField] private float jumpH;
   public Vector3 movementVector3 = Vector3.zero;

   [SerializeField] private ParticleSystem gunFire;

  


  
  

   private float mouseInputRotateX;

   
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        mouseInputRotateX =  Input.GetAxis("Mouse X");
        // mouseInputRotateY = Input.GetAxis("Mouse Y");
        
        
        bool grounded = Physics.Linecast(transform.position,groundCheck.transform.position,layerMask);
        Debug.DrawLine(transform.position,groundCheck.transform.position);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            // Jump();
            Velcoity.y = jumpH;
        }
        
    }

    private void FixedUpdate()
    {

       
        
        float inputH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float inputV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        
         movementVector3 = transform.right * inputH + transform.forward * inputV;
        characterController.Move(movementVector3);
        
        Velcoity.y += gravity * Time.deltaTime;
        characterController.Move(Velcoity * Time.deltaTime);
        
        playerTransform.Rotate(Vector3.up * mouseSpeed * mouseInputRotateX * Time.deltaTime);
        

    }

   

}
