using UnityEngine;

public class ReloadState : IBotState
{
    private BotController bot;
    private float reloadTime = 2f;
    private float timer = 0f;

    public ReloadState(BotController bot)
    {
        this.bot = bot;
    }

    public void Enter()
    {
        Debug.Log("Entering RELOAD 🔄");
        timer = 0f;
    }

    public void Execute()
    {
        timer += Time.deltaTime;

        if (bot.Health <= bot.fleeThreshold)
        {
            bot.StateMachine.ChangeState(new FleeState(bot));
            return;
        }

        if (timer >= reloadTime)
        {
            bot.Reload();

            if (bot.CanSeeEnemy())
                bot.StateMachine.ChangeState(new AttackState(bot));
            else
                bot.StateMachine.ChangeState(new PatrolState(bot));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting RELOAD");
    }
}