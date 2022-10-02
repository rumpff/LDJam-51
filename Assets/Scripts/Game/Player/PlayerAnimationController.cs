using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * ZAID
 * 
 * Handles the animation of the player character. 
 * Currently responds to the change in rigidbody velocity of the player as that was the only exposed parameter. 
 * It's fine for now.
 */
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator animationController;
    [SerializeField] float velocityMagnitudeThreshold = 1.5f;
    [SerializeField] Rigidbody2D PlayerRigidbody;
    [SerializeField] PlayerWeaponHandler PlayerWeaponHandler;
    [SerializeField] private Transform PlayerModel;

    public void UpdateAnimation()
    {
    
        if (PlayerRigidbody.velocity.magnitude > velocityMagnitudeThreshold)
        {
            animationController.SetFloat("MovementMagnitude", 1f, 0.2f, Time.deltaTime);
        }
        else
        {
            animationController.SetFloat("MovementMagnitude", 0f, 0.1f, Time.deltaTime);
        }

        if (!animationController.GetBool("Dead"))
        {
            var angle = Mathf.Atan2(PlayerWeaponHandler.AimDirection.y, PlayerWeaponHandler.AimDirection.x) * Mathf.Rad2Deg;
            PlayerModel.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.down);
        }
    }
    public void SetPlayerDead(bool dead)
    {
        animationController.SetBool("Dead", dead);
    }
    private void LateUpdate()
    {

        UpdateAnimation(); // Put this in an event, possibly.
        
    }
}
