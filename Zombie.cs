namespace project1
{
    public class Zombie : GameObject
    {
        public Zombie(int _x, int _y)
        {
            x = _x;
            y = _y;
            character = 'Z';
            type = "Zombie";
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