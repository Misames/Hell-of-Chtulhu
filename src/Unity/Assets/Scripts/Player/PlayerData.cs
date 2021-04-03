namespace Player
{
    public class PlayerData
    {
        public int level;
        public int health;
        public float[] position;
        public PlayerData()
        {
            position = new float[3];
        }
    }
}