using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Tilemap tilemap;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (player == null || tilemap == null)
            return;

        Bounds bounds = tilemap.GetComponent<TilemapRenderer>().bounds;

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        float x;
        float y;

        // X AXIS
        if (bounds.size.x <= halfWidth * 2)
        {
            // Map is smaller than camera, center camera
            x = bounds.center.x;
        }
        else
        {
            x = Mathf.Clamp(
                player.position.x,
                bounds.min.x + halfWidth,
                bounds.max.x - halfWidth
            );
        }

        // Y AXIS
        if (bounds.size.y <= halfHeight * 2)
        {
            // Map is smaller than camera, center camera
            y = bounds.center.y;
        }
        else
        {
            y = Mathf.Clamp(
                player.position.y,
                bounds.min.y + halfHeight,
                bounds.max.y - halfHeight
            );
        }

        transform.position = new Vector3(x, y, -10f);
    }
}