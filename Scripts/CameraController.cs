using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 20f;
    public float borderNear = 10f;
    public float scrollSpeed = 20f;
    public Vector2 cameraLimit;

    private Camera cam;
    private float zoom = 8;
    public Camera battleCam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderNear)
        {
            pos.y += cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= borderNear)
        {
            pos.y -= cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderNear)
        {
            pos.x += cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <=  borderNear)
        {
            pos.x -= cameraSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (zoom > 3.5)
                zoom -= Time.deltaTime * scrollSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoom < 12)
                zoom += Time.deltaTime * scrollSpeed;
        }

        cam.orthographicSize = zoom;
        pos.x = Mathf.Clamp(pos.x, -cameraLimit.x, cameraLimit.x);
        pos.y = Mathf.Clamp(pos.y, -cameraLimit.y, cameraLimit.y);
        transform.position = pos;
    }
        
    public void BattleOn()
    {
        if (battleCam.enabled)
            battleCam.enabled = false;
        else
            battleCam.enabled = true;
    }


}
