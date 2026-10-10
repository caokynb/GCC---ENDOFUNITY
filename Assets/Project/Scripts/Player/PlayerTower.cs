using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTower : MonoBehaviour
{
    private PlayerData player;
    [SerializeField] private int maxHp;
    [SerializeField] private int hp;
    [SerializeField] private float mana;
    [SerializeField] private float maxMana;
    [SerializeField] private float manaRegenRate;
    [SerializeField] private int spiritLimit;
    [SerializeField] private List<int> upgrades = new List<int>{1,1,1};
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private Transform transform;
    private InputAction spawnAction;
    [SerializeField] private GameObject fireUnit;
    void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    
    void Awake()
    {
        spawnAction = InputSystem.actions.FindAction("Spawn");
        player = new PlayerData();
        upgrades = new List<int>(player.upgrades);
        maxHp = Mathf.RoundToInt(player.maxHp + (upgrades[0]*0.1f));
        hp = maxHp;
        maxMana = player.maxMana + (upgrades[1]*0.15f);
        mana = maxMana;
        manaRegenRate = player.manaRegenRate + (upgrades[2]*0.05f);
        spiritLimit = player.spiritLimit;
    }
    void Update()
    {
        if (spawnAction.WasPressedThisFrame())
        {
            Instantiate(fireUnit,transform.position,Quaternion.identity);
        }
    }
}
public enum UpgradeType
{
        MaxHp,
        MaxMana,
        ManaRegenRate
}