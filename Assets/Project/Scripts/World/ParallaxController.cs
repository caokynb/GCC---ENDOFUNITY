using UnityEngine;
using UnityEngine.InputSystem;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private Transform main;
    [SerializeField] private Rigidbody2D rb0;
    [SerializeField] private Rigidbody2D rb1;
    [SerializeField] private Rigidbody2D rb2;
    [SerializeField] private Rigidbody2D rb3;
    private InputAction moveAction;
    [SerializeField] private float moveSpeed;
    void OnEnable()
    {
        inputActions.FindActionMap("Camera").Enable();
    }
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }
    void Update()
    {
        if(main.position.x>0f && main.position.x<24f){
            rb0.linearVelocityX=moveAction.ReadValue<float>()*moveSpeed;
            rb1.linearVelocityX=moveAction.ReadValue<float>()*moveSpeed*0.8f;
            rb2.linearVelocityX=moveAction.ReadValue<float>()*moveSpeed*0.6f;
            rb3.linearVelocityX=moveAction.ReadValue<float>()*moveSpeed*0.4f;
        }
        else
        {
            rb0.linearVelocityX=rb1.linearVelocityX=rb2.linearVelocityX=rb3.linearVelocityX=0f;
        }
    }
}
