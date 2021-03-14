using UnityEngine;

public class GridPosition
{
    /// <summary>
    /// 取得したGrid情報を位置情報に変換し返すメソッド(駒用)
    /// </summary>
    /// <param name="gridPoint"></param>
    /// <returns></returns>
    static public Vector3 PointFromGrid(Vector2Int gridPoint)
    {
        float x = 0.5f + gridPoint.x;
        float z = 0.5f + gridPoint.y;
        return new Vector3(x, 0.5f, z);
    }
    /// <summary>
    /// 取得したGrid情報を位置情報に変換し返すメソッド（Field用）
    /// </summary>
    /// <param name="gridPoint"></param>
    /// <returns></returns>
    static public Vector3 PointFromGridForField(Vector2Int gridPoint)
    {
        float x = gridPoint.x;
        float z = gridPoint.y;
        return new Vector3(x, 0, z);
    }

    static public Vector2Int GridPoint(int col, int row)
    {
        return new Vector2Int(col, row);
    }

    /// <summary>
    /// 取得した位置情報を切り下げし、int型に変更し返す関数
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    static public Vector2Int GridFromPoint(Vector3 point)
    {
        int col = Mathf.FloorToInt(point.x);
        int row = Mathf.FloorToInt(point.z);
        return new Vector2Int(col, row);
    }
}