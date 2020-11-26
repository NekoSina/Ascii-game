
using System;
using AsciiGame.Entities;

namespace AsciiGame.AI
{
    public class ZombieBrain : Brain
    {
        public DateTime _then;
        public GameObject _target;
        
        public ZombieBrain(GameObject owner):base(owner){}

        public override void Update()
        {
            switch(State)
            {
                case AI_state.Idle:
                    Idle();
                break;
                case AI_state.Thinking:
                    Thinking();
                break;
                case AI_state.Moving:
                    Moving();
                break;
                case AI_state.Interacting:
                    Interacting(null);
                break;
                case AI_state.Dead:
                    Idle();
                break;
            }
        }
        private void Idle()
        {
            State = AI_state.Thinking;
        }
        private void Thinking()
        {
            foreach (var item in Program.CurrentMap.Objects)
            {
                if(item.Value is Player)
                {
                    _target = item.Value;
                    State = AI_state.Moving;
                    break;
                }
            }
        }
        private void Moving()
        {
            var DeltaTime = DateTime.Now - _then;

            if (DeltaTime.Seconds < 1)
                return;

            _owner.MoveTowardsObject(_target);
            _then = DateTime.Now;
        }
        private void Interacting(GameObject obj)
        {
            State = AI_state.Idle;
        }
    }
}