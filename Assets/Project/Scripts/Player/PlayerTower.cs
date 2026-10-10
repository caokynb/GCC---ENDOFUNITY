using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTower : MonoBehaviour, IDamageable
{
    private PlayerData player;
    [SerializeField] private int maxHp;
    [SerializeField] private int hp;
    [SerializeField] private float mana;
    [SerializeField] private float maxMana;
    [SerializeField] private float manaRegenRate;
    [SerializeField] private int spiritLimit;
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private Transform transform;
    [SerializeField] private SpriteRenderer sprite;
    private InputAction spawnAction;
    [SerializeField] private GameObject fireUnit;
    void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    
    void Awake()
    {
        spawnAction = InputSystem.actions.FindAction("Spawn");
        player = new PlayerData();
        GetStat();
    }
    void GetStat()
    {
        maxHp=player.maxHp;
        mana=player.maxMana;
        hp = maxHp;
        mana = maxMana;
        spiritLimit = player.spiritLimit;
    }
    void Update()
    {
        if (spawnAction.WasPressedThisFrame())
        {
            Instantiate(fireUnit,transform.position,Quaternion.identity);
        }
    }
    public void TakeDamage(int damage)
    {
        hp-=damage;
        Debug.Log($"Á hự, máu còn {Mathf.Clamp(hp,0,int.MaxValue)}");
        StartCoroutine(Flash());
        if(hp<=0) Death();
    }
    void Death()
    {
        Time.timeScale=0;
    }
    private IEnumerator Flash()
    {   
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}