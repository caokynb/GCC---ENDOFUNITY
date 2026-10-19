using System;
using System.Collections;
using System.Threading;
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
    [SerializeField] private Transform tf;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject fireDemon;
    [SerializeField] private GameObject waterDemon;
    [SerializeField] private GameObject groundDemon;
    private float timer1;
    private float timer2;
    private float timer3;
    
    void Awake()
    {
        player = new PlayerData();
        GetStat();
    }
    void GetStat()
    {
        maxHp = (int)Mathf.Pow(player.maxHp,1.2f);
        maxMana=(int)Mathf.Pow(player.maxMana,1.2f);
        manaRegenRate=(int)Mathf.Pow(player.manaRegenRate,1.025f);
        hp = maxHp;
        mana = maxMana;
        timer1=11f;
        timer2=17f;
        timer3=23f;
    }
    void Start()
    {
        RenderHp();
    }
    void FixedUpdate()
    {
        mana=Mathf.Clamp(mana,0,maxMana);
        mana+=manaRegenRate;
        if (timer1 > 0f)
        {
            timer1-=Time.deltaTime;
            if (timer1 <= 0f)
            {
                if(mana>=80) Instantiate(fireDemon,transform.position,Quaternion.identity);
                timer1=11f;
                mana-=80;
            }
        }
        if (timer2 > 0f)
        {
            timer2-=Time.deltaTime;
            if (timer2 <= 0f)
            {
                if(mana>=100) Instantiate(waterDemon,transform.position,Quaternion.identity);
                timer1=17f;
                mana-=100;
            }
        }
        if (timer3 > 0f)
        {
            timer3-=Time.deltaTime;
            if (timer3 <= 0f)
            {
                if(mana>=55) Instantiate(groundDemon,transform.position,Quaternion.identity);
                timer3=23f;
                mana-=55;
            }
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