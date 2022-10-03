using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void OnEnter(Enemy e);
    void OnUpdate();
    void OnFixedUpdate();
    void OnExit();
}

public class EnemyAliveState : IEnemyState
{
    private Enemy _enemy;

    public virtual void OnEnter(Enemy e)
    {
        _enemy = e;
    }

    public virtual void OnUpdate()
    {
        _enemy.WeaponHandler.HandleWeapon();
    }

    public virtual void OnFixedUpdate()
    {
    }

    public virtual void OnExit()
    {

    }
}

public class EnemyHuntedState : IEnemyState
{
    private Enemy _enemy;

    public virtual void OnEnter(Enemy e)
    {
        _enemy = e;
    }

    public virtual void OnUpdate()
    {
        // Run away or something
    }

    public virtual void OnFixedUpdate()
    {
    }

    public virtual void OnExit()
    {

    }
}

public class EnemyDeadState : IEnemyState
{
    private Enemy _enemy;

    public virtual void OnEnter(Enemy e)
    {
        _enemy = e;
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnFixedUpdate()
    {
    }

    public virtual void OnExit()
    {

    }
}