using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    private void OnMouseDown()
    {
        //Debug.Log("Mouse was clicked");
        SpawnDefender(GetSquareClicked());
    }
    
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        //Debug.Log("GetSquareClicked worldPos: " + worldPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        //Debug.Log("SnapToGrid gridPos: " + gridPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    private void SpawnDefender(Vector2 roundedPause)
    {
        Defender newDefender = Instantiate(defender, roundedPause, Quaternion.identity) as Defender;
        //Debug.Log(Time.timeSinceLevelLoad);
    }
}
