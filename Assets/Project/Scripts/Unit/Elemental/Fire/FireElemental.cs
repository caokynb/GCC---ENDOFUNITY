using System;
using UnityEngine;

public class FireElemental : MonoBehaviour, IDamageable
{
    [SerializeField] private UnitSO unitData;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public BoxCollider2D cd;
    [SerializeField] public LayerMask layer;
    public StateMachine stateMachine;
    public MarchStateFire marchState;
    public AttackStateFire attackState;
    public IDamageable currentTarget;
    public string unitName;
    public Element element;
    public int hp;
    public int attack;
    public int defense;
    public int speed;
    public float attackRange;
    public float attackSpeed;
    public int manaCost;
    void Awake()
    {
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
        AttackCheck();
    }
    void FixedUpdate()
    {
        stateMachine.FixedTick();
    }
    public void AttackCheck()
    {
        RaycastHit2D touched = Physics2D.Raycast(transform.position,Mathf.Sign(transform.localScale.x)*Vector3.one,attackRange/2f,layer);
        if (touched.collider != null)
        {
            currentTarget=touched.collider.GetComponent<IDamageable>();
            stateMachine.ForceSetState(attackState);
        }
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
    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,new Vector3(Mathf.Sign(transform.localScale.x)*attackRange/2f,0,0));
    }
}
