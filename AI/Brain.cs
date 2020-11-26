
using System;
using AsciiGame.Entities;

namespace AsciiGame.AI
{
    public class Brain
    {
        public AI_state State;
        public GameObject _owner;

        public Brain(GameObject owner)
        {
            _owner=owner;
            State = AI_state.Idle;
        }
        public virtual void Update()
        {
            
        }        
    }
}