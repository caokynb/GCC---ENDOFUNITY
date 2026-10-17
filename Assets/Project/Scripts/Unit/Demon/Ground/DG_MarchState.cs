using UnityEngine;
public class DG_MarchState : IState
{
    private GroundDemon groundDemon;
    public DG_MarchState(GroundDemon groundDemon)
    {
        this.groundDemon = groundDemon;
    }
    public void Enter()
    {

    }
    public void Tick()
    {
        groundDemon.rb.linearVelocityX=groundDemon.speed;
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        groundDemon.rb.linearVelocityX=0f;
    }

}