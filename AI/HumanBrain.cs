using System;
using AsciiGame.Entities;

namespace AsciiGame.AI
{
    public class HumanBrain : Brain
    {
        public DateTime _then;
        private GameObject _target;
        private Zombie _targetZombie;
        private Tree _targetTree;
        private Human _HumanOwner;
        
        public HumanBrain(Human owner):base(owner)
        {
            _HumanOwner = owner;
        }
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
                    Interacting(_target);
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
            LookForTree();
        }
        private void Moving()
        {
            var distanceX = Math.Abs(_owner.X - _target.X);
            var distanceY = Math.Abs( _owner.Y - _target.Y); 
            if(distanceX <= 1 && distanceY <=1)
                State = AI_state.Interacting;
            else
            {
                var DeltaTime = DateTime.Now - _then;
                if (DeltaTime.Seconds < 0.5)
                return;

                _owner.MoveTowardsObject(_target);
                _then = DateTime.Now;
            }
        }
        private void Interacting(GameObject obj)
        {          
            if(_target is Tree)
            {
                _targetTree = (Tree)obj; 
                ChopTree(); 
            }
            if(_target is Camp)
            {
                ReturnWood();
            }
        }
        private void LookForTree()
        {
            foreach (var item in Program.CurrentMap.Objects)
            {
                if(item.Value is Tree)
                {
                    _target = (Tree)item.Value;
                    State = AI_state.Moving;
                    break;
                }
            }
        }
        private void ChopTree()
        {
            if(_targetTree.Wood.Quantity <= 0)
            {
                _targetTree.Despawn();
                ReturnToCamp();
            }
            else
            {
                _targetTree.Wood.Quantity--;
                _owner.Inventory.AddItem("Wood", 1);
            }
        }
        private void ReturnToCamp()
        {
            _target = _HumanOwner.MyCamp;
            State = AI_state.Moving;
        }
        private void ReturnWood()
        {
            var wood = _owner.Inventory.SelectItem("Wood");
            if(wood.Quantity <= 0)
            {
                State = AI_state.Idle;
            }
            else
            {
                wood.Quantity --;
                _HumanOwner.MyCamp.Inventory.AddItem("Wood", 1);
            }
        }
        private void Attack()
        {
            
        }
    }
    
}