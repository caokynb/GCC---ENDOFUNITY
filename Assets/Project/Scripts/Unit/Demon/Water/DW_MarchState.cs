using UnityEngine;
public class DW_MarchState : IState
{
    private WaterDemon waterDemon;
    public DW_MarchState(WaterDemon waterDemon)
    {
        this.waterDemon = waterDemon;
    }
    public void Enter()
    {

    }
    public void Tick()
    {
        waterDemon.rb.linearVelocityX=waterDemon.speed*-1;
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        waterDemon.rb.linearVelocityX=0f;
    }

}