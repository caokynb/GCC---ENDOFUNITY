using UnityEngine;
public class EW_MarchState : IState
{
    private WaterElemental waterUnit;
    public EW_MarchState(WaterElemental waterUnit)
    {
        this.waterUnit = waterUnit;
    }
    public void Enter()
    {

    }
    public void Tick()
    {
        waterUnit.rb.linearVelocityX=waterUnit.speed;
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        waterUnit.rb.linearVelocityX=0f;
    }

}