/// <summary>
/// 盤面の情報を管理するクラス
/// </summary>
public class FieldManager
{
    static FieldState[,] m_field = new FieldState[7, 5];

    public static FieldState[,] Field
    {
        set { m_field = value; }
        get { return m_field; }
    }

    void Awake()
    {
        SetFieldInfo();
    }

    /// <summary>
    /// Fieldの情報を初期化する
    /// </summary>
    void SetFieldInfo()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                m_field[i, j] = FieldState.Empty;
            }
        }
        m_field[1, 0] = FieldState.MyPiece;
        m_field[1, 1] = FieldState.MyPiece;
        m_field[1, 2] = FieldState.MyPiece;
        m_field[1, 3] = FieldState.MyPiece;
        m_field[1, 4] = FieldState.MyPiece;
        m_field[5, 0] = FieldState.EnePiece;
        m_field[5, 1] = FieldState.EnePiece;
        m_field[5, 2] = FieldState.EnePiece;
        m_field[5, 3] = FieldState.EnePiece;
        m_field[5, 4] = FieldState.EnePiece;
    }
}

public enum FieldState
{
    Empty,
    MyPiece,
    EnePiece
}
