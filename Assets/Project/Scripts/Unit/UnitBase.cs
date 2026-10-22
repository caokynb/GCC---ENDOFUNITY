using System;
using TMPro;
using UnityEngine;

public class UnitBase : MonoBehaviour, IDamageable
{
    [SerializeField] private UnitSO unitData;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public BoxCollider2D cd;
    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] private TextMeshPro text;
    [SerializeField] public Animator anim;
    private LayerMask layer;
    public StateMachine stateMachine {get; private set;}
    public MarchState marchState {get; private set;}
    public AttackState attackState {get; private set;}
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

    public UnitSO Data => unitData;

    void Awake()
    {
        if(gameObject.layer==LayerMask.NameToLayer("Elemental")) layer=LayerMask.GetMask("Demon");
        else layer=LayerMask.GetMask("Elemental");
        stateMachine = new StateMachine();
        marchState = new MarchState(this);
        attackState = new AttackState(this);
        GetStat();
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
    }
    void Update()
    {
        anim.SetFloat("Speed",Math.Sign(Mathf.Abs(rb.linearVelocityX)));
        stateMachine.Tick();
        AttackCheck();
        UnitVisual.RenderHp(text,hp);
    }
    void FixedUpdate()
    {
        stateMachine.FixedTick();
    }
    public void AttackCheck()
    {
        RaycastHit2D touched = Physics2D.Raycast(transform.position,new Vector3(Mathf.Sign(transform.localScale.x),0,0),attackRange,layer);
        if (touched.collider != null)
        {
            currentTarget=touched.collider.GetComponent<IDamageable>();
            if(currentTarget!=null) stateMachine.ChangeState(attackState);
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
        StartCoroutine(UnitVisual.Flash(sprite));   
        if(hp<=0)
        {
            cd.enabled=false;
            rb.constraints=RigidbodyConstraints2D.FreezePositionX;
            anim.SetTrigger("Die");
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    
}
