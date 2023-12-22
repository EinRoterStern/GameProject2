using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap77 : MonoBehaviour
{
    private Terrain terrain;

    void Start()
    {
        // Получаем ссылку на terrain
        terrain = Terrain.activeTerrain;

        if (terrain == null)
        {
            Debug.LogError("Terrain not found. Make sure there is an active terrain in the scene.");
        }
        else
        {
            AlignToTerrain();
        }
    }

    void AlignToTerrain()
    {
        // Получаем текущую позицию объекта
        Vector3 currentPosition = transform.position;

        // Определяем высоту terrain в точке текущей позиции объекта
        float terrainHeight = terrain.SampleHeight(currentPosition);

        // Корректируем позицию объекта так, чтобы он был на поверхности terrain
        currentPosition.y = terrainHeight;

        // Устанавливаем новую позицию объекта
        transform.position = currentPosition;
    }
}

