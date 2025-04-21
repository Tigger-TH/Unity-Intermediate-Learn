using System;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
///  Struct class for each state of an enemy AI
/// </summary>
public class State
{
        public event Action OnStateChange;
        /// <summary>
        /// Event for other funtion
        /// </summary>

        public enum STATE
        {
            IDLE,
            ROAMING,
            BATTLE
        }

        public enum EVENT
        {
            ENTER,
            UPDATE,
            EXIT
        }

        public STATE Name;

        protected EVENT Stage;
        protected Enemy EnemyClass;
        protected NavMeshAgent Agent;

        protected State NextState;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="agent"></param>
        public State(Enemy enemy,NavMeshAgent agent)
        {
            EnemyClass = enemy;
            Agent = agent;

            Stage = EVENT.ENTER;
        }
        /// <summary>
        /// what to do on Enter this state
        /// </summary>
        public virtual void Enter()
        {
            Stage = EVENT.UPDATE;
        }
        /// <summary>
        /// What to do while in this state. Including condition
        /// to change state
        /// you need to implement 'Stage = EVENT.EXIT' on State changed
        /// </summary>
        public virtual void Update()
        {
            Stage = EVENT.UPDATE;
        }
        /// <summary>
        /// What to do on Exit this state (Wrap up)
        /// </summary>
        public virtual void Exit()
        {
            Stage = EVENT.UPDATE;
        }
        

        public State Process()
        {
            if(Stage == EVENT.ENTER)
            {
                Enter();
            }
            if(Stage == EVENT.UPDATE)
            {
                Update();
            }
            if(Stage == EVENT.EXIT)
            {
                Exit();
                OnStateChange?.Invoke();

                return NextState;
            }
            return this;
        }
}
