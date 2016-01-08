using UnityEngine;
using System.Collections;

// This class contains all the info required for tiles to determine where to move or where a player is on the map.
public class Tile : MonoBehaviour
{
    [SerializeField]
    private bool m_DoesPathLoop;
	private GameObject[] m_Tiles;
	private int m_NumberOfTiles;

    void Start()
    {
		m_NumberOfTiles = this.gameObject.transform.childCount;
		m_Tiles = new GameObject [m_NumberOfTiles];
		SetTiles();
    }

    //void Update()
    //{
	//
	//}

	private void SetTiles()
	{
		for (int i = 0; i < m_NumberOfTiles; i++)
		{
			m_Tiles [i] = this.gameObject.transform.GetChild (i).gameObject;
		}
	}

	public Transform GetTileForIndex(int aIndex)
	{
		if (aIndex < m_NumberOfTiles)
		{
			Transform tileHolder = this.gameObject.transform;
			//Returns the tile based on the index
			return tileHolder.GetChild(aIndex).gameObject.transform;
		}
		//If we got here then tile not in range
		return null;
	}

    public bool IsLoopablePath()
    {
        return m_DoesPathLoop;
    }
}
