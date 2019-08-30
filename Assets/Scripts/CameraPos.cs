using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    public float cameraSpeed = 4;
    private float elapsed;
    private float duration = 1f;
    public bool transition;
    private bool resetScene;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float moveX = player.transform.position.x - offset.x;
        float moveY = player.transform.position.y - offset.y;
        Vector3 moveLimit = new Vector3(Mathf.Clamp(moveX, -4.273f, 4.273f), Mathf.Clamp(moveY, -2.4f, 2.4f), transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, moveLimit, cameraSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        if(transition)
        {
            elapsed += Time.deltaTime / duration;
            GetComponent<Camera>().orthographicSize = Mathf.SmoothStep(3f, 1f, elapsed);
            if (elapsed > 1f)
            {
                transition = false;
                player.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
                resetScene = true;
                elapsed = 0;
                duration = 0.5f;
            }
        }
        if(resetScene)
        {
            elapsed += Time.deltaTime / duration;
            GetComponent<Camera>().orthographicSize = Mathf.SmoothStep(1f, 3f, elapsed);
            if (elapsed > 1f)
            {
                player.GetComponent<Player>().StartCoroutine(player.GetComponent<Player>().RespawnAnimation());
                resetScene = false;
            }
        }
    }
}
