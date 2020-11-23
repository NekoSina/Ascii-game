namespace AsciiGame.Entities
{
    public class Zombie : GameObject
    {
        public Zombie(int _x, int _y)
        {
            X = _x;
            Y = _y;
            Character = 'Z';
        }
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
            
        }
        private void ZombieIdle()
        {

        }
        private void ZombieThinking()
        {

        }
        private void ZombieMoving()
        {

        }
        private void ZombieInteracting(GameObject obj)
        {

        }
    }
}