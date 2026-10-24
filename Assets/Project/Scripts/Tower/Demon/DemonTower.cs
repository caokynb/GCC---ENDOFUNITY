using System;
using UnityEngine;

public class DemonTower : TowerBase
{
    [SerializeField] private TowerSO demonData;
    [SerializeField] private GameObject fireDemon;
    [SerializeField] private GameObject waterDemon;
    [SerializeField] private GameObject groundDemon;
    public Action roundCheck;
    private float timer1;
    private float timer2;
    private float timer3;

    void Awake()
    {
        GetStat();
        GetTimer(1);
        GetTimer(2);
        GetTimer(3);
    }
    protected override void GetStat()
    {
        maxHp = UpgradeManager.GetUpgradesDemonINT(demonData.maxHp,RoundManager.round);
        maxMana = UpgradeManager.GetUpgradeDemonFLOAT(demonData.maxMana,RoundManager.round);
        manaRegenRate = UpgradeManager.GetUpgradeDemonFLOAT(demonData.manaRegenRate,RoundManager.round);
        hp = maxHp;
        mana = maxMana;
        RenderHp();
    }
    void GetTimer(int n)
    {
        if(n==1) timer1 = UpgradeManager.GetTimerDemon(10f,RoundManager.round);
        if(n==2) timer2 = UpgradeManager.GetTimerDemon(20f,RoundManager.round);
        if(n==3) timer3 = UpgradeManager.GetTimerDemon(30f,RoundManager.round);
    }

    void FixedUpdate()
    {
        RegenMana();
        TrySpawn(ref timer1,fireDemon,1);
        TrySpawn(ref timer2,waterDemon,2);
        TrySpawn(ref timer3,groundDemon,3);
    }
    protected override void OnTowerDestroyed()
    {
        roundCheck?.Invoke();
    }

    private void TrySpawn(ref float timer,GameObject demon,int n)
    {
        if (timer>0f) timer-=Time.fixedDeltaTime;
        if (timer>0f || demon==null) return;
        // sorry em chua biet fix cai nay cho hop li anh aj, tai vi thang demon la gameobject nen e chua biet lay mana cost cua no
        UnitBase demonPrefab = demon.GetComponent<UnitBase>();
        if (demonPrefab != null && SummonManager.Instance.Summon(this, demonPrefab)) GetTimer(n);
    }
}
