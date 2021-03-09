public class PieceManager
{
    static int m_up;
    static int m_down;
    static int m_left;
    static int m_right;

    public static int Up
    {
        set { m_up = value; }
        get { return m_up; }
    }

    public static int Down
    {
        set { m_down = value; }
        get { return m_down; }
    }

    public static int Left
    {
        set { m_left = value; }
        get { return m_left; }
    }

    public static int Right
    {
        set { m_right = value; }
        get { return m_right; }
    }
}
