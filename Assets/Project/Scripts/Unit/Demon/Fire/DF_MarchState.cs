using UnityEngine;
public class DF_MarchState : IState
{
    private FireDemon fireDemon;
    public DF_MarchState(FireDemon fireDemon)
    {
        this.fireDemon = fireDemon;
    }
    public void Enter()
    {

    }
    public void Tick()
    {
        fireDemon.rb.linearVelocityX=fireDemon.speed*-1f;
    }
    public void FixedTick()
    {
        
    }
    public void Exit()
    {
        fireDemon.rb.linearVelocityX=0f;
    }

}