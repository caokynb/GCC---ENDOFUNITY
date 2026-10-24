using System;
using UnityEngine;

public class PlayerTower : TowerBase
{
    [SerializeField] private TowerSO towerData;
    [SerializeField] private GameObject fireUnit;
    [SerializeField] private GameObject waterUnit;
    [SerializeField] private GameObject groundUnit;
    public Action roundCheck;
    private float timer;
    void Awake()
    {
        GetStat();
        timer=1f;
        RenderHp();
    }
    public int currentSpirits => ActiveUnitCount;
    protected override void GetStat()
    {
        maxHp = UpgradeManager.GetUpgradesINT(towerData.maxHp,0);
        maxMana = UpgradeManager.GetUpgradesFLOAT(towerData.maxMana,4);
        manaRegenRate = UpgradeManager.GetUpgradesFLOAT(towerData.manaRegenRate,5);
        int tmp=0;
        for(int i=0;i<3;i++){
            tmp = Mathf.Max(tmp,UpgradeManager.GetUpgradesINT(towerData.spiritLimit,i));
        }
        spiritLimit = tmp;
        hp = maxHp;
        mana = maxMana;
        RenderHp();
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (currentSpirits > spiritLimit)
        {
            if (timer > 0f)
                timer -= Time.fixedDeltaTime;
            else
            {
                TakeDamage((int)(maxHp*Mathf.Pow(0.02f,1f/(currentSpirits-spiritLimit))),Element.Fire);
                timer = 1f;
            }
        }
        RegenMana();
    }

    public void Summon(int n)
    {
        UnitBase unit = SummonInit(n);
        if (unit != null && SummonManager.Instance != null)
            SummonManager.Instance.Summon(this, unit);
    }

    protected override void OnTowerDestroyed()
    {
        roundCheck?.Invoke();
    }

    public UnitBase SummonInit(int slot)
    {
        GameObject unit = slot switch
        {
            1 => fireUnit,
            2 => waterUnit,
            3 => groundUnit,
            _ => null
        };
        return unit.GetComponent<UnitBase>();
    }
}
