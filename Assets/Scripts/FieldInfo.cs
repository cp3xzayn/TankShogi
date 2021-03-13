/// <summary>
/// 盤面の情報を管理するクラス
/// </summary>
public class FieldInfo
{
    static FieldState[] m_field = new FieldState[35];

    public static FieldState[] Field
    {
        set { m_field = value; }
        get { return m_field; }
    }

    static int m_fieldWidth = 5;

    public static int FieldWidth
    {
        get { return m_fieldWidth; }
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
        for (int i = 0; i < 35; i++)
        {
            m_field[i] = FieldState.Empty;
        }
        m_field[5] = FieldState.MyPiece;
        m_field[6] = FieldState.MyPiece;
        m_field[7] = FieldState.MyPiece;
        m_field[8] = FieldState.MyPiece;
        m_field[9] = FieldState.MyPiece;
        m_field[25] = FieldState.EnePiece;
        m_field[26] = FieldState.EnePiece;
        m_field[27] = FieldState.EnePiece;
        m_field[28] = FieldState.EnePiece;
        m_field[29] = FieldState.EnePiece;
    }
}

public enum FieldState
{
    Empty,
    MyPiece,
    EnePiece
}
