﻿using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField]
    private bool showGizmos;

    [SerializeField]
    private int mapIndex;

    [SerializeField]
    private Map[] maps;

    public static Map Map
    {
        get
        {
            return Instance.maps != null && Instance.maps.Length > Instance.mapIndex ? Instance.maps[Instance.mapIndex] : null;
        }
    }

    public static bool MouseIsInsideMap
    {
        get
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return mouseWorldPosition.y > -Map.Height / 2 && mouseWorldPosition.y < Map.Height / 2 && mouseWorldPosition.x > -Map.Width / 2 && mouseWorldPosition.x < Map.Width / 2;
        }
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos)
            return;

        for (int x = 0; x < Map.SizeX; x++)
        {
            for (int y = 0; y < Map.SizeY; y++)
            {
                switch (Map[x, y])
                {
                    case (SoilType.Bark):
                        Gizmos.color = Color.cyan;
                        break;

                    case (SoilType.Dirt):
                        Gizmos.color = Color.blue;
                        break;

                    case (SoilType.Grass):
                        Gizmos.color = Color.red;
                        break;

                    case (SoilType.Leaves):
                        Gizmos.color = Color.magenta;
                        break;

                    case (SoilType.Rock):
                        Gizmos.color = Color.black;
                        break;

                    case (SoilType.Sand):
                        Gizmos.color = Color.green;
                        break;

                    default:
                        Gizmos.color = Color.gray;
                        break;
                }

                Gizmos.DrawCube(Map.GetPositionFromCoordinate(x, y), Vector2.one * 0.2F);
            }
        }
    }
}