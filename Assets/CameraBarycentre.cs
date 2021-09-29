using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBarycentre : MonoBehaviour
{

    [SerializeField]
    public GameObject pointA;
    [SerializeField]
    public GameObject pointB;
    [SerializeField]
    public GameObject pointC;
    [SerializeField]
    public Camera cam;

    private Vector3 PointG;

    // Start is called before the first frame update
    void Start()
    {
        Coordinatebarrycentre();
    }

    // Update is called once per frame
    void Update()
    {

        Coordinatebarrycentre();
        // cam.transform.position = new Vector3(cam.transform.position.x, 10, cam.transform.position.z);



    }

    void Coordinatebarrycentre()
    {

        float distanceAB = Vector3.Distance(pointA.transform.position, pointB.transform.position);
        float distanceBC = Vector3.Distance(pointB.transform.position, pointC.transform.position);
        float distanceCA = Vector3.Distance(pointC.transform.position, pointA.transform.position);

        float a = 1 / distanceAB + 1 / distanceCA;
        float b = 1 / distanceAB + 1 / distanceBC;
        float c = 1 / distanceBC + 1 / distanceCA;

        PointG = (a / (a + b + c)) * pointA.transform.position;
        PointG += (b / (a + b + c)) * pointB.transform.position;
        PointG += (c / (a + b + c)) * pointC.transform.position;

        float y = Mathf.Max(Mathf.Max(distanceAB, distanceBC), distanceBC);
        cam.transform.position = new Vector3(PointG.x, y, PointG.z);

    }


}