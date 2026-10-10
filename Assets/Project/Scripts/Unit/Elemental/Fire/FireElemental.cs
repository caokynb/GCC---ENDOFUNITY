using System;
using UnityEngine;

public class FireElemental : MonoBehaviour, IDamageable
{
    [SerializeField] private UnitSO unitData;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public BoxCollider2D cd;
    [SerializeField] public BoxCollider2D ad;
    public StateMachine stateMachine;
    public MarchStateFire marchState;
    public AttackStateFire attackState;
    public IDamageable currentTarget;
    private Formula formula;
    public string unitName;
    public Element element;
    public int hp;
    public int attack;
    public int defense;
    public int speed;
    public float attackRange;
    public float attackSpeed;
    public int manaCost;
    public bool isAttacking;
    void Awake()
    {
        formula = new Formula();
        stateMachine = new StateMachine();
        marchState = new MarchStateFire(this);
        attackState = new AttackStateFire(this);
        GetStat();
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }
    void GetStat()
    {
        unitName = unitData.unitName;
        element = unitData.element;
        hp = unitData.hp;
        attack = unitData.attack;
        defense = unitData.defense;
        speed = unitData.speed;
        attackRange = unitData.attackRange;
        ad.size = new Vector2(attackRange,0.5f);
        ad.offset = new Vector2(attackRange/2f,0f);
        attackSpeed = unitData.attackSpeed;
        manaCost = unitData.manaCost; 
    }
    void Start()
    {
        stateMachine.ForceSetState(marchState);
    }
    void Update()
    {
        stateMachine.Tick();
    }
    void FixedUpdate()
    {
        stateMachine.FixedTick();
    }
    public void TakeDamage(int attack)
    {
        hp-=attack;
        if(hp<=0) Death();
    }
    void Death()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Demon"))
        {
            currentTarget = collider.GetComponent<IDamageable>();
            stateMachine.ForceSetState(attackState);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(!isAttacking) stateMachine.ChangeState(marchState);
    }
}
