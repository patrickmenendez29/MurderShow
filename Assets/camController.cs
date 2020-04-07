using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour
{
    public GameObject target;
    public Style style;
    private playerController playerController;
    private float yOffset;
    private Camera camera;


    public enum Style
    {
        STATIC, FOLLOW
    };
   

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
        try
        {
            playerController = target.GetComponent<playerController>();

        } catch (NullReferenceException)
        {
            Debug.Log("No script is attached to the player");
        }
        yOffset = target.transform.position.y + 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isOnSurface)
        {
            this.yOffset = +target.transform.position.y;
        }

        if (style == Style.STATIC)
        {
            transform.position = new Vector3(0, 0, -10);
            camera.orthographicSize = 15f;
        } else if (style == Style.FOLLOW)

        {
            if (playerController.isAscending)
            {
                // TODO: fix animation (seems to go down a little at frame 1)
                this.yOffset =+ target.transform.position.y;
            }

            camera.orthographicSize = 5f;
            followPlayer(this.yOffset);

            
        }
    }

    public void followPlayer(float yOffset)
    {
        transform.position = new Vector3(target.transform.position.x, yOffset, -10);
    }

    public void followPlayer()
    {
        transform.position = new Vector3(target.transform.position.x, yOffset, -10);
    }
}
