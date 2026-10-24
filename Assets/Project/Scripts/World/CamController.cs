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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,0f,24f),0,-10);
        rb.linearVelocityX = moveAction.ReadValue<float>() * cameraMoveSpeed;
    }
}
