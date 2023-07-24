using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aswang_PlayerDetectedState : PlayerDetectedState
{
    private Aswang enemy;

    public Aswang_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,D_PlayerDetected stateData, Aswang enemy) : base(entity, stateMachine, animBoolName, stateData){
        this.enemy = enemy;
    }

    public override void Enter(){
        base.Enter();
    }

    public override void Exit(){
        base.Exit();
    }

    public override void LogicUpdate(){
        base.LogicUpdate();
        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        } else if(performLongeRangeAction){
            stateMachine.ChangeState(enemy.chargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
    }

    public override void PhysicsUpdate(){
        base.PhysicsUpdate();

    }
}
