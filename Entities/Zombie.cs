
using System;
namespace AsciiGame.Entities
{
    public class Zombie : GameObject
    {
        
        public Zombie(int _x, int _y)
        {
            _state = AI_state.Idle;
            X = _x;
            Y = _y;
            Character = 'Z';
            _then = DateTime.Now;
        }
        DateTime _then;
        GameObject _target;
        AI_state _state;
        
        public enum AI_state
        {
            Idle,
            Thinking,
            Moving,
            Interacting,
            Dead
        }
        public void ZombieAI()
        {
            switch(_state)
            {
                case AI_state.Idle:
                    ZombieIdle();
                break;
                case AI_state.Thinking:
                    ZombieThinking();
                break;
                case AI_state.Moving:
                    ZombieMoving();
                break;
                case AI_state.Interacting:
                    ZombieIdle();
                break;
                case AI_state.Dead:
                    ZombieIdle();
                break;
            }
        }
        private void ZombieIdle()
        {
            _state = AI_state.Thinking;
        }
        private void ZombieThinking()
        {
            foreach (var item in Program.CurrentMap.Objects)
            {

                if(item.Value is Player)
                {
                    _target = item.Value;
                    _state = AI_state.Moving;
                }
            }
        }
        private void ZombieMoving()
        {
            var DeltaTime = DateTime.Now.Second - _then.Second;
            if(DeltaTime == 1)
            {
                MoveTowardsObject(_target);
                _then = DateTime.Now;

            }
            
        }
        private void ZombieInteracting(GameObject obj)
        {

        }
    }
}