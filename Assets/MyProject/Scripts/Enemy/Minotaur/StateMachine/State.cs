using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target { get; set; }

    public void Enter(Player target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;

            foreach (Transition transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (Transition transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
