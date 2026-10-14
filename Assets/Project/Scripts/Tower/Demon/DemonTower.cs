using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DemonTower : MonoBehaviour, IDamageable
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
    [SerializeField] private TextMeshPro text;
    private InputAction spawnAction;
    [SerializeField] private GameObject fireDemon;
    void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    
    void Awake()
    {
        spawnAction = InputSystem.actions.FindAction("Spawn_D");
        player = new PlayerData();
        GetStat();
    }
    void GetStat()
    {
        maxHp = (int)Mathf.Pow(player.maxHp,1.2f);
        mana = player.maxMana;
        hp = maxHp;
        mana = maxMana;
        spiritLimit = player.spiritLimit;
    }
    void Start()
    {
        RenderHp();
    }
    void Update()
    {
        if (spawnAction.WasPressedThisFrame())
        {
            Instantiate(fireDemon,tf.position,Quaternion.identity);
        }
    }
    public void TakeDamage(int damage, Element e)
    {
        hp-=damage;
        RenderHp();
        StartCoroutine(Flash());
        if(hp<=0) Death();
    }
    void Death()
    {
        Time.timeScale=0;
    }
    void RenderHp()
    {
        text.text=$"{Mathf.Clamp(hp,0,int.MaxValue)}";
    }
    private IEnumerator Flash()
    {   
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}