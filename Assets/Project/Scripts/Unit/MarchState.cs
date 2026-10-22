using UnityEngine;

public class MarchState : IState
{
    private UnitBase unit;
    public MarchState(UnitBase unit)
    {
        this.unit = unit;
    }
    public void Enter()
    {
        
    }
    public void Tick()
    {
        unit.rb.linearVelocityX=unit.speed*unit.transform.localScale.x;
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        unit.rb.linearVelocityX=0f;
    }
}
