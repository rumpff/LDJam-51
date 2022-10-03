using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    void OnEnter(Player p);
    void OnUpdate();
    void OnFixedUpdate();
    void OnExit();
}

public class PlayerAliveState : IPlayerState
{
    protected Player _player;

    public virtual void OnEnter(Player p)
    {
        _player = p;
    }

    public virtual void OnUpdate()
    {
        _player.PlayerWeapon.HandleWeapon();
    }

    public virtual void OnFixedUpdate()
    {
        _player.PlayerMovement.HandleMovement();
    }

    public virtual void OnExit()
    {

    }
}


public class PlayerStateHealthy : PlayerAliveState
{
    public override void OnEnter(Player p)
    {
        base.OnEnter(p);
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

public class PlayerStateHunting : PlayerAliveState
{
    public override void OnEnter(Player p)
    {
        base.OnEnter(p);
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
    public void OnEnter(Player p)
    {
        p.PlayerAnimationController.SetPlayerDead(true);
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