using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSatelitte : MonoBehaviour
{
    int zoom = 20;
    int normal = 60;
    int smooth = 5;

    private bool isZoomed = false;

    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceCible = 10;

    private Vector3 anciennePosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.mouseScrollDelta.y > 0)
         {
             isZoomed = !isZoomed;
         }


         if(isZoomed)
         {
             cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom, Time.deltaTime * smooth);
         }

         else
         {
             cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normal, Time.deltaTime * smooth);
         }
         
        if (Input.GetMouseButtonDown(0))
        {
            anciennePosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = anciennePosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            cam.transform.position = target.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

            cam.transform.Translate(new Vector3(0, 0, -distanceCible));

            anciennePosition = newPosition;
        }

    }
}
