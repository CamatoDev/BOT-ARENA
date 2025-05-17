using UnityEngine;

public class AttackState : IBotState
{
    private BotController bot;

    public AttackState(BotController bot)
    {
        this.bot = bot;
    }

    public void Enter()
    {
        Debug.Log("Entering ATTACK 🔴");
        bot.SetTarget(bot.enemyTarget);
    }

    public void Execute()
    {
        if (bot.Health <= bot.fleeThreshold)
        {
            bot.StateMachine.ChangeState(new FleeState(bot));
            return;
        }

        if (!bot.CanSeeEnemy())
        {
            bot.StateMachine.ChangeState(new PatrolState(bot));
            return;
        }

        if (bot.Ammo > 0)
        {
            bot.Shoot();
        }
        else
        {
            bot.StateMachine.ChangeState(new ReloadState(bot));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting ATTACK");
    }
}