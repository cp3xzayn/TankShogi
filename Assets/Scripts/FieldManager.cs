using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    int[,] m_field = new int[5, 7];

    public int[,] Field
    {
        get { return m_field; }
    }
}
