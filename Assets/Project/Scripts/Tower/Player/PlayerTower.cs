using System;
using System.Collections;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] private Transform tf;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI textM;
    [SerializeField] private GameObject fireUnit;
    [SerializeField] private GameObject waterUnit;
    [SerializeField] private GameObject groundUnit;
    private InputAction spawnAction;
    private InputAction spawnAction2;
    private InputAction spawnAction3;
    public int currentSpirits=0;
    private float timer;
    void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    
    void Awake()
    {
        spawnAction = InputSystem.actions.FindAction("Spawn");
        spawnAction2 = InputSystem.actions.FindAction("Spawn2");
        spawnAction3 = InputSystem.actions.FindAction("Spawn3");
        player = new PlayerData();
        GetStat();
    }
    void GetStat()
    {
        maxHp=player.maxHp;
        maxMana=player.maxMana;
        manaRegenRate=player.manaRegenRate;
        hp = maxHp;
        mana = maxMana;
        spiritLimit = player.spiritLimit;
        currentSpirits=0;
        timer=1f;
    }
    void Start()
    {
        RenderHp();
    }
    void Update()
    {
        RenderMana();
        RenderHp();
        mana=Mathf.Clamp(mana,0,maxMana);
        if (spawnAction.WasPressedThisFrame())
        {
            Summon(1,75);
        }
        if (spawnAction2.WasPressedThisFrame())
        {
            Summon(2,100);
        }
        if (spawnAction3.WasPressedThisFrame())
        {
            Summon(3,50);
        }
    }
    void FixedUpdate()
    {
        if (currentSpirits > spiritLimit)
        {
            if(timer>0f) timer-=Time.deltaTime;
            else 
            {
                TakeDamage((int)(maxHp*Mathf.Pow(0.02f,1f/(currentSpirits-spiritLimit))),0);
                timer=1f;
            }
        }
        mana+=manaRegenRate;
    }
    public void Summon(int n, int manaDeducted)
    {
        if(mana<manaDeducted) return;
        if(n==1) Instantiate(fireUnit,tf.position,Quaternion.identity);
        if(n==2) Instantiate(waterUnit,tf.position,Quaternion.identity);
        if(n==3) Instantiate(groundUnit,tf.position,Quaternion.identity);
        mana-=manaDeducted;
        UpdateSpirit(true);
    }
    public void TakeDamage(int damage,Element e)
    {
        RenderHp();
        hp-=damage;
        StartCoroutine(Flash());
        if(hp<=0) Death();
    }
    void Death()
    {
        Time.timeScale=0;
    }
    void RenderHp()
    {
        text.text = $"{Mathf.Clamp(hp, 0, int.MaxValue):F0}";
    }
    void RenderMana()
    {
        textM.text = $"{Mathf.Clamp(mana,0,maxMana):F0}";
    }
    public void UpdateSpirit(bool n)
    {
        if(n) currentSpirits++;
        else currentSpirits--;
    }
    private IEnumerator Flash()
    {   
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}