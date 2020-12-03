using System;
using AsciiGame.Entities;

namespace AsciiGame.AI
{
    public class HumanBrain : Brain
    {
        public DateTime _then;
        private GameObject _target;
        private Human _HumanOwner => (Human)_owner;

        public HumanBrain(GameObject owner) : base(owner){}
        
        public override void Update()
        {
            switch(State)
            {
                case AI_state.Idle:
                case AI_state.Dead:
                    State = AI_state.Thinking;
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
            }
        }
        
        private void Thinking() 
        { 
            if( _HumanOwner.Inventory.Contains("Wood"))
            {
                var wood = _HumanOwner.Inventory.GetItem("Wood");
                
                if(wood.Quantity < 10)
                    LookForTree();
                else
                    ReturnToCamp();
            }
            else
                LookForTree();
        }
        private void Moving()
        {
            var distanceX = Math.Abs(_owner.X - _target.X);
            var distanceY = Math.Abs( _owner.Y - _target.Y);

            if (distanceX > 1 || distanceY > 1)
            {
                var DeltaTime = DateTime.Now - _then;
                if (DeltaTime.Seconds < 0.5)
                    return;

                _owner.MoveTowardsObject(_target);
                _then = DateTime.Now;
            }
            else
                State = AI_state.Interacting;
        }
        private void Interacting(GameObject obj)
        {          
            if(_target is Tree targetTree)
                ChopTree(targetTree); 
            if(_target is Camp)
                AddResourcesToCamp();
        }
        private void LookForTree()
        {
            foreach(var kvp in Program.CurrentMap.Objects)
            {
                if (kvp.Value is Tree)
                {
                    _target = kvp.Value;
                    State = AI_state.Moving;                    
                    break;
                }
            }

            if(_target == null)
                _target = _HumanOwner.MyCamp;
        }
        private void ChopTree(Tree targetTree)
        {
            if(!targetTree.Inventory.Contains("Wood"))
            {
                targetTree.Despawn();
                State= AI_state.Thinking;
            }
            else
            {
                targetTree.Inventory.RemoveItem("Wood",1);
                _owner.Inventory.AddItem("Wood", 1);
            }
        }
        private void ReturnToCamp()
        {
            _target = _HumanOwner.MyCamp;
            State = AI_state.Moving;
        }
        private void AddResourcesToCamp()
        {
            foreach(var item in _HumanOwner.MyCamp.DesiredResources)
            {
                while(_owner.Inventory.Contains(item))
                {
                    _owner.Inventory.RemoveItem(item,1);
                    _HumanOwner.MyCamp.Inventory.AddItem(item,1);
                }
            }
            State= AI_state.Idle;
        }
    }
}