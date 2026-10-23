using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour, IDamageable
{
    [SerializeField] protected int maxHp;
    [SerializeField] protected int hp;
    [SerializeField] protected float mana;
    [SerializeField] protected float maxMana;
    [SerializeField] protected float manaRegenRate;
    [SerializeField] protected int spiritLimit;
    [SerializeField] protected Transform tf;
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected TMP_Text text;
    [SerializeField] protected TMP_Text textM;
    private readonly List<GameObject> activeUnits = new();
    public float CurrentMana => mana;
    public float MaxMana => maxMana;
    public int CurrentHp => hp;
    public int MaxHp => maxHp;
    private bool dead;
    public int ActiveUnitCount
    {
        get
        {
            activeUnits.RemoveAll(unit => unit == null);
            return activeUnits.Count;
        }
    }
    public Vector3 SpawnPosition => tf.position;
    protected void GetStat(TowerSO towerData)
    {
        if (gameObject.layer == LayerMask.NameToLayer("Elemental"))
        {
            maxHp = UpgradeManager.GetUpgradesINT(towerData.maxHp,0);
            maxMana = UpgradeManager.GetUpgradesFLOAT(towerData.maxMana,4);
            manaRegenRate = UpgradeManager.GetUpgradesFLOAT(towerData.manaRegenRate,5);
            int tmp=0;
            for(int i=0;i<3;i++){
                tmp = Mathf.Max(tmp,UpgradeManager.GetUpgradesINT(towerData.spiritLimit,i));
            }
            spiritLimit = tmp;
        }
        else
        {
            maxHp = UpgradeManager.GetUpgradesDemonINT(towerData.maxHp,RoundManager.round);
            maxMana = UpgradeManager.GetUpgradeDemonFLOAT(towerData.maxMana,RoundManager.round);
            manaRegenRate = UpgradeManager.GetUpgradeDemonFLOAT(towerData.manaRegenRate,RoundManager.round);
        }
        hp = maxHp;
        mana = maxMana;
        RenderHp();
    }
    public bool SpendMana(float deductedMana)
    {
        if(deductedMana<0f || mana<deductedMana) return false;
        mana -= deductedMana;
        RenderMana();
        return true;
    }
    protected void RegenMana()
    {
        mana = Mathf.Clamp(mana + manaRegenRate * Time.fixedDeltaTime, 0f, maxMana);
        RenderMana();
    }
    public void AddUnit(UnitBase unit)
    {
        activeUnits.Add(unit.gameObject);
    }
    public void UnregisterUnit(UnitBase unit)
    {
        if (unit != null)
            activeUnits.Remove(unit.gameObject);
    }
    protected void RenderHp()
    {
        text.text = Mathf.Clamp(hp, 0, int.MaxValue).ToString();
        RenderMana();
    }
    private void RenderMana()
    {
        textM.text = Mathf.Clamp(mana, 0f, maxMana).ToString("F0");
    }
    public virtual void TakeDamage(int damage, Element element)
    {
        if (dead || damage <= 0) return;
        hp = Mathf.Max(0,hp-damage);
        RenderHp();
        StartCoroutine(Flash());
        if (hp <= 0)
        {
            dead = true;
            OnTowerDestroyed();
        }
    }
    protected abstract void OnTowerDestroyed();
    private IEnumerator Flash()
    {
        Color originalColor = sprite.color;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = originalColor;
    }
}
