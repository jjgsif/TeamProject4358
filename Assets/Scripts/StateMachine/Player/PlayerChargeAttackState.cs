using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeAttackingState : PlayerState
{
    public PlayerChargeAttackingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        chargingAttackHash = Animator.StringToHash("ChargingAttack");
    }

    private float normalizedTime;
    private int chargingAttackHash;
    private float crossFixedDuration = 0.1f;

    public override void Enter()
    {
        PlayAnimation(chargingAttackHash, crossFixedDuration);
    }

    public override void Exit()
    {
    }

    public override void Tick()
    {
        HandleCameraMovement();
        Move(Vector3.zero);
        GameObject target = playerStateMachine.targetManager.GetCurrentTarget();
        if (target != null)
        {
            FaceTarget(target);
        }

        if (InputReader.Instance.isPressingWestButton) return; 

        playerStateMachine.SwitchState(new PlayerAttackingState(playerStateMachine, playerStateMachine.comboManager.chargeSwordAttackCombo, 0));
    }
}