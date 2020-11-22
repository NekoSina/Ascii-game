namespace project1
{
    public class GameObject
    {
        public string type;
        public string characters;
        public int x = 0;
        public int y = 0;
        public GameObject(string _characters, string _type)
        {
            characters = _characters;
            type = _type;
        }
        public void setposition(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
    }
}