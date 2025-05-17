using UnityEngine;

public class FleeState : IBotState
{
    private BotController bot;

    public FleeState(BotController bot)
    {
        this.bot = bot;
    }

    public void Enter()
    {
        Debug.Log("Entering FLEE 🟡");
        bot.Flee();
    }

    public void Execute()
    {
        if (bot.Health > bot.fleeThreshold)
        {
            if (bot.Ammo > 0 && bot.CanSeeEnemy())
                bot.StateMachine.ChangeState(new AttackState(bot));
            else
                bot.StateMachine.ChangeState(new PatrolState(bot));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting FLEE");
    }
}
