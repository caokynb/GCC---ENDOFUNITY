using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FireElemental : MonoBehaviour, IDamageable
{
    [SerializeField] private UnitSO unitData;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public BoxCollider2D cd;
    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] private TextMeshPro text;
    [SerializeField] public Animator anim;
    [SerializeField] public LayerMask layer;
    public StateMachine stateMachine {get; private set;}
    public EF_MarchState marchState {get; private set;}
    public EF_AttackState attackState {get; private set;}
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
        marchState = new EF_MarchState(this);
        attackState = new EF_AttackState(this);
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
        RenderHp();
    }
    void Update()
    {
        anim.SetFloat("Speed",Math.Sign(Mathf.Abs(rb.linearVelocityX)));
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
        else
        {
            stateMachine.ChangeState(marchState);
        }
    }
    public void TakeDamage(int attack)
    {
        hp-=attack;
        RenderHp();
        StartCoroutine(Flash());
        if(hp<=0) Death();
    }
    void Death()
    {
        Destroy(gameObject);
    }
    void RenderHp()
    {
        text.text=$"{Mathf.Clamp(hp,0,int.MaxValue)}";
    }
    private IEnumerator Flash()
    {   
        Color org = sprite.color;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = org;
    }
}
