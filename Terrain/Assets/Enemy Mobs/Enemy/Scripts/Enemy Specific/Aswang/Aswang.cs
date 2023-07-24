using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aswang : Entity
{
    public Aswang_IdleState idleState { get; private set; }
    public Aswang_MoveState moveState { get; private set; }
    public Aswang_PlayerDetectedState playerDetectedState { get; private set; }
    public Aswang_ChargeState chargeState { get; private set; }
    public Aswang_LookForPlayerState lookForPlayerState { get; private set; }
    public Aswang_MeleeAttackState meleeAttackState { get; private set; }
    public Aswang_FollowPlayerState followPlayerState { get; private set;  }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetected playerDetectedData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateData;
    [SerializeField] private D_MeleeAttackState meleeAttackStateData;
    [SerializeField] private D_FollowPlayerState followPlayerStateData;

    [SerializeField] private Transform meleeAttackPosition;

    public override void Start(){
        base.Start();

        moveState = new Aswang_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Aswang_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new Aswang_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData,this);
        chargeState = new Aswang_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new Aswang_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new Aswang_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        followPlayerState = new Aswang_FollowPlayerState(this, stateMachine, "followPlayer", followPlayerStateData, this);


        stateMachine.Initialize(moveState);
    }

    public virtual void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);

    }
}