using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerState : State
{
    protected D_FollowPlayerState stateData;

    protected bool isPlayerInMaxAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isPlayerInSight;
    protected bool performCloseRangeAction;

    public FollowPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_FollowPlayerState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();

        isPlayerInSight = false;
        entity.SetVelocity(stateData.followSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMaxAgroRange)
        {
            isPlayerInSight = true;

            entity.aliveGO.transform.position = Vector2.MoveTowards(this.entity.aliveGO.transform.position, entity.playerCheck.position, stateData.followSpeed * Time.deltaTime);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
