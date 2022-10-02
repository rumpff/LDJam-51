using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    void OnEnter(ref Player p);
    void OnUpdate();
    void OnFixedUpdate();
    void OnExit();
}

public class PlayerAliveState : IPlayerState
{
    protected Player _player;

    public virtual void OnEnter(ref Player p)
    {
        _player = p;
    }

    public virtual void OnUpdate()
    {
        _player.PlayerMovement.HandleMovement();
        _player.PlayerWeapon.HandleWeapon();
    }

    public virtual void OnFixedUpdate()
    {

    }

    public virtual void OnExit()
    {

    }
}


public class PlayerStateHealthy : PlayerAliveState
{
    public override void OnEnter(ref Player p)
    {
        base.OnEnter(ref p);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}

public class PlayerStateDamaged : PlayerAliveState
{
    public override void OnEnter(ref Player p)
    {
        base.OnEnter(ref p);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}

public class PlayerStateDead : IPlayerState
{
    public void OnEnter(ref Player p)
    {

    }

    public void OnUpdate()
    {

    }

    public void OnFixedUpdate()
    {

    }

    public void OnExit()
    {

    }
}