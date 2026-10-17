using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WaterDemon : MonoBehaviour, IDamageable
{
    [SerializeField] public DemonTower demon;
    [SerializeField] private UnitSO unitData;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public BoxCollider2D cd;
    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] private TextMeshPro text;
    [SerializeField] public Animator anim;
    [SerializeField] public LayerMask layer;
    public StateMachine stateMachine {get; private set;}
    public DW_MarchState marchState {get; private set;}
    public DW_AttackState attackState {get; private set;}
    public IDamageable currentTarget;
    public string unitName;
    public Element element;
    public int hp;
    public int attack;
    public int defense;
    public float speed;
    public float attackRange;
    public float attackSpeed;
    public int manaCost;
    public bool attacking;
    private float outTimer;
    void Awake()
    {
        stateMachine = new StateMachine();
        marchState = new DW_MarchState(this);
        attackState = new DW_AttackState(this);
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
        outTimer=0.5f;
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
        RaycastHit2D touched2 = Physics2D.Raycast(transform.position,new Vector3(Mathf.Sign(transform.localScale.x),0,0),attackRange,layer);
        if (touched2.collider != null)
        {
            currentTarget=touched2.collider.GetComponent<IDamageable>();
            stateMachine.ForceSetState(attackState);
        }
        else
        {
            if(attacking)
            {
                if(outTimer>0f) outTimer-=Time.deltaTime;
                else 
                {
                    outTimer=0.5f;
                    stateMachine.ChangeState(marchState);
                }
            }
        }
    }
    public void TakeDamage(int attack, Element e)
    {
        float penalty=1f;
        switch (element)
        {
        case Element.Fire:
            if (e == Element.Water) penalty = 1.1f;
            else if (e == Element.Wood) penalty = 0.8f;
            break;
        case Element.Water:
            if (e == Element.Wood) penalty = 1.1f;
            else if (e == Element.Fire) penalty = 0.8f;
            break;
        case Element.Wood:
            if (e == Element.Fire) penalty = 1.1f;
            else if (e == Element.Water) penalty = 0.8f;
            break;
        }
        hp-=(int)(attack*penalty-defense);
        RenderHp();
        StartCoroutine(Flash());
        if(hp<=0)
        {
            cd.enabled=false;
            rb.constraints=RigidbodyConstraints2D.FreezePositionX;
            anim.Play("EW_Death");
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    void RenderHp()
    {
        text.text=$"{Mathf.Clamp(hp,0,int.MaxValue):F0}";
    }
    private IEnumerator Flash()
    {   
        Color org = sprite.color;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = org;
    }
}
