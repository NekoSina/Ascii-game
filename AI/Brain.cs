using AsciiGame.Entities;

namespace AsciiGame.AI
{
    public class Brain
    {
        public AI_state State;
        public GameObject _owner;

        public Brain(GameObject owner)
        {
            _owner = owner;
            State = AI_state.Idle;
        }
        public virtual void Update()
        {
            
        }        
    }
    public class NullBrain : Brain
    {
        public NullBrain(GameObject owner) : base(owner) { }
        public override void Update(){}
    }
}