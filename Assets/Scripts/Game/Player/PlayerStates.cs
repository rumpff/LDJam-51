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

public class PlayerStateHealthy : IPlayerState
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

public class PlayerStateDamaged : IPlayerState
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