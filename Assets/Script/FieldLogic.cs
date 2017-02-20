using UnityEngine;
using System.Collections;

public class FieldLogic : MonoBehaviour {

    public GameObject m_cell;
    public int m_gridLines;
    public int m_gridColumns;
    public int m_borderTop;
    public int m_borderBottom;
    public int m_borderLeft;
    public int m_borderRight;


    int m_heightPU;   //defines the height in pixels for the cell
    int m_widthPU;    //defines the width in pixels for the cell
    GameObject[][] m_grid;

	void Start ()
    {
        //instantiate grid logic
        GridToScreen();
        InstatiateGrid();        
    }
    
    void Update()
    {
        //DrawTile();
    }
    void InstatiateGrid()
    {/*
        Vector2 gridVector = new Vector2(m_gridColumns, m_gridLines);
        m_grid = new GameObject[(int)gridVector.x][];
        for (int x = 0; x < gridVector.x; x++)
        {
            m_grid[x] = new GameObject[(int)gridVector.y];
            for (int y = 0; y < gridVector.y; y++)
            {
                GameObject cell = Instantiate(m_cell);
                //cell.GetComponent<Cell>().m_cellHeight = m_heightPU;
                //cell.GetComponent<Cell>().m_cellLenght = m_widthPU;
                cell.name = "Cell" + y + x;
                Vector3 pos = Camera.main.ScreenToWorldPoint(CellPosition(x, y));
                pos.z = 0;
                cell.transform.position = pos;
                //cell.transform.localScale
                Debug.Log(CellPosition(x,y).ToString());
                // manipulate gameobject here
                m_grid[x][y] = cell;
            }
        }*/
    }

    void GridToScreen() //just math
    {
        m_heightPU = (Screen.height - m_borderTop - m_borderBottom) / m_gridColumns;
        m_widthPU = (Screen.width - m_borderLeft - m_borderRight) / m_gridLines;
        
    }

    Vector3 CellPosition(int x,int y)
    {
        Vector3 pos;
        pos = new Vector3(x* m_widthPU +m_borderLeft, y* m_heightPU + m_borderBottom, 0);
        return pos;
    }

    void DrawTile(Sprite toTile)
    {
        
    }
}
