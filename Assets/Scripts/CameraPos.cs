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
    private Player playerComp;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        playerComp = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!playerComp.dead)
        {
            float moveX = player.transform.position.x - offset.x;
            float moveY = player.transform.position.y - offset.y;
            Vector3 moveLimit = new Vector3(Mathf.Clamp(moveX, -4.273f, 4.273f), Mathf.Clamp(moveY, -2.4f, 2.4f), transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, moveLimit, cameraSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else
        {
            if (transition)
            {
                elapsed += Time.deltaTime / duration;
                GetComponent<Camera>().orthographicSize = Mathf.SmoothStep(3f, 1f, elapsed);
                if(elapsed > 1f)
                {
                    transition = false;
                }
            }
            
        }
    }
}
