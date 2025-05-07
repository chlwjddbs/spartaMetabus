using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private TilemapRenderer tilemapRenderer;
    private float cameraHalfHeight;
    private float cameraHalfWidth;

    private Vector2 areaMin;
    private Vector2 areaMax;

    private float cameraLimitsHeight;
    private float cameraLimitsWidth;

    private Vector3 cameraOffset = new Vector3(0, 0, -10);

    private Vector3 cameraPos;

    [SerializeField] private float chaseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Bounds bounds = tilemapRenderer.bounds;
        cameraHalfHeight = Camera.main.orthographicSize;
        cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;

        areaMin = bounds.min;
        areaMax = bounds.max;
    }

   
    private void FixedUpdate()
    {
        cameraLimitsHeight = Mathf.Clamp(target.position.y, areaMin.y + cameraHalfHeight, areaMax.y - cameraHalfHeight);
        cameraLimitsWidth = Mathf.Clamp(target.position.x, areaMin.x + cameraHalfWidth, areaMax.x - cameraHalfWidth);

        cameraPos.x = cameraLimitsWidth;
        cameraPos.y = cameraLimitsHeight;
        cameraPos.z = cameraOffset.z;

        transform.position = Vector3.Lerp(transform.position, cameraPos, Time.fixedDeltaTime * chaseSpeed);
    }
}
