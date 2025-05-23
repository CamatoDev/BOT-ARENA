using UnityEngine;

// L�IA poursuit l�ennemi jusqu�� �tre � port�e de tir
public class ChaseState : IBotState
{
    private BotController bot;

    public ChaseState(BotController bot) { this.bot = bot; }

    public void Enter()
    {
        Debug.Log("Entering CHASE");
        bot.stateText.text = "Entering CHASE";
        bot.SetTarget(bot.enemyTarget);
    }

    public void Execute()
    {
        bot.stateText.text = "CHASE...";
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

        if (bot.Ammo <= 0)
        {
            bot.StateMachine.ChangeState(new ReloadState(bot));
            return;
        }

        // Si l'ennemi est � distance de tir, passer � Shoot
        if (bot.IsInShootingRange())
        {
            bot.StateMachine.ChangeState(new ShootState(bot));
            return;
        }

        // Sinon, continuer la poursuite
        bot.SetTarget(bot.enemyTarget);
    }

    public void Exit()
    {
        Debug.Log("Exiting CHASE");
    }
}
