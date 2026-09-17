using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraBounds : MonoBehaviour
{
    public Tilemap tilemap;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Bounds bounds = tilemap.GetComponent<TilemapRenderer>().bounds;

        float cameraHeight = cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;

        float minX = bounds.min.x + cameraWidth;
        float maxX = bounds.max.x - cameraWidth;

        float minY = bounds.min.y + cameraHeight;
        float maxY = bounds.max.y - cameraHeight;

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}

