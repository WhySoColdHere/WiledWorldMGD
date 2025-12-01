using UnityEngine;

public abstract class PlayerState
{
    protected Player player;
    public PlayerState(Player player) 
    {
        this.player = player;
    }

    public void Enter() { }
    public void Exit() { }

    public void Update() { }
    public void FixedUpdate() { }
}
