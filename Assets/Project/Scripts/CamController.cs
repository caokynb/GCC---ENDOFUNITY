using UnityEngine;
using UnityEngine.InputSystem;

public class CamController : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private Rigidbody2D rb;
    public float cameraMoveSpeed=3f;
    private InputAction moveAction;
    void OnEnable()
    {
        inputActions.FindActionMap("Camera").Enable();
    }
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(transform.position.x>=0f && transform.position.x<=24f) rb.linearVelocityX = moveAction.ReadValue<float>() * cameraMoveSpeed;
        else transform.position = new Vector3((int)transform.position.x,0,0);
    }
}
