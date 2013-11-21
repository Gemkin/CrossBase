using System;
using CrossBase.Dispatch;
using CrossBase.Log;

namespace CrossBase.StateMachine
{
    /// <summary>
    /// Base class for state machines. Takes care of creating new necessary state machine data objects: transistions
    /// and context
    /// </summary>
    /// <typeparam name="P">Type of state context object. This object is shared between states</typeparam>
    /// <typeparam name="Q">Type of state transistion object. This object defines the initial state, normal and special state transitions</typeparam>
    /// <typeparam name="R">Type of event args raised when a state change happens</typeparam>
    public abstract class StateMachineBase<P, Q, R, S> : IDisposable, IStateMachine<S> 
        where P : IStateContext
        where Q : StateTransitionsDefinitionBase, new()
        where R : StateChangedEventArgsBase, new()
        where S : StateEvent
    {
        protected ILogger log;
        protected IDispatcher dispatcher;
        protected IState currentState;
        protected S lastEvent;
        protected Q transitionsDefinition;
        protected P context;
        protected IState previousState;
        protected bool stateMachineStarted;
        public virtual event EventHandler<R> StateChanged;

        /// <summary>
        /// Constructs the base of the state machine
        /// </summary>
        /// <param name="log">logger</param>
        /// <param name="dispatcher">dispatcher used to dispatch StateEvent handling</param>
        /// <param name="context">context for the statemachine</param>
        protected StateMachineBase(ILogger log, IDispatcher dispatcher, P context)
        {
            this.log = log;
            this.dispatcher = dispatcher;

            this.context = context;
            transitionsDefinition = new Q();
            currentState = CreateNextState(transitionsDefinition.InitialStateType);
            dispatcher.BeginInvoke(() => currentState.Enter());
        }

        /// <summary>
        /// Handles state events asynchroniously on the logic dispatcher
        /// </summary>
        /// <param name="stateEvent"></param>
        public void HandleEvent(S stateEvent)
        {
            dispatcher.BeginInvoke(() => DoHandleEvent(stateEvent));
        }

        private void DoHandleEvent(S stateEvent)
        {
            var nextState = GetNextState(stateEvent);

            if (nextState == null)
            {
                log.DebugFormat("Ignored event {0} in {1}", stateEvent, currentState);
                return;
            }

            previousState = currentState;
            lastEvent = stateEvent;

            if (currentState != null)
            {
                log.DebugFormat("Dispose old state {0}", currentState);
                currentState.Dispose();
            }

            log.InfoFormat("Enter next state {0}", nextState);
            currentState = nextState;
            OnEnteringNextState(new R{PrevState = previousState, NextState = currentState, StateEvent = stateEvent});

            currentState.Enter();
        }

        private IState GetNextState(S stateEvent)
        {
            foreach (var transistion in transitionsDefinition.Normal)
            {
                if (transistion.Current != currentState.GetType())
                    continue;

                if (transistion.Event == null)
                    continue;

                if (transistion.Event != stateEvent)
                    continue;

                if (transistion.Next == null)
                    continue;

                return CreateNextState(transistion.Next);
            }

            foreach (var transistion in transitionsDefinition.Special)
            {
                if (transistion.Event != stateEvent)
                    continue;
                return CreateNextState(transistion.Next);
            }
            return null;
        }

        protected virtual void OnEnteringNextState(R e)
        {
            var evnt = StateChanged;
            if (evnt != null) evnt(this, e);
        }

        public virtual void Dispose()
        {
        }

        private IState CreateNextState(Type type)
        {
            var constructorInfo = type.GetConstructor(new Type[] { });
            var state = (IState)constructorInfo.Invoke(new object[] { });
            type.GetProperty("Context").SetValue(state, context, null);
            type.GetProperty("Machine").SetValue(state, this, null);
            return state;
        }

    }
}