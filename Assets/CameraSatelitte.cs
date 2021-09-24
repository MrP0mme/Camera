using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSatelitte : MonoBehaviour
{
    public int zoom = 40;
    public int normal = 60;
    int smooth = 5;

    private bool isZoomed = false;

    [SerializeField] private Camera m_camera;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceCible = 10;

    private Vector3 anciennePosition;
    private Vector3 debutPosition;
    private Vector3 debutRotation;

    void Awake()
    {
        debutPosition = m_camera.transform.position;
    }



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
             m_camera.fieldOfView = Mathf.Lerp(m_camera.fieldOfView, zoom, Time.deltaTime * smooth);
        } 

        else
         {
             m_camera.fieldOfView = Mathf.Lerp(m_camera.fieldOfView, normal, Time.deltaTime * smooth);
        }

        if (Input.GetMouseButtonDown(1))
        {
            anciennePosition = m_camera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(1))
        {
            Vector3 newPosition = m_camera.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = anciennePosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; 
            float rotationAroundXAxis = direction.y * 180; 

            m_camera.transform.position = target.position;

            m_camera.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            m_camera.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

            m_camera.transform.Translate(new Vector3(0, 0, -distanceCible));

            anciennePosition = newPosition;
        }

        if(Input.GetButtonDown("Jump"))
        {

            m_camera.transform.position = debutPosition;
            m_camera.transform.localRotation = Quaternion.Euler(0, 0, 0);      

        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            
            Vector3 newPosition = m_camera.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = anciennePosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180;

            m_camera.transform.position = target.position;

            m_camera.transform.Rotate(new Vector3(0, 30, 0), Space.World);

            m_camera.transform.Translate(new Vector3(0, 0, -distanceCible));

           // anciennePosition = newPosition;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            Vector3 newPosition = m_camera.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = anciennePosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180;

            m_camera.transform.position = target.position;

            m_camera.transform.Rotate(new Vector3(0, -30, 0), Space.World);

            m_camera.transform.Translate(new Vector3(0, 0, -distanceCible));

            // anciennePosition = newPosition;
        }
    }
}
