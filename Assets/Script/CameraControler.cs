using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float sensitivity = 3;
    [SerializeField] [Range(0, 90)] private float limit = 90;
    [SerializeField] private float zoom = 0.25f;
    [SerializeField] private float zoomMax = 10;
    [SerializeField] private float zoomMin = 3;
    private float X, Y = 90;
    private UnityCreature targetCreature;
    private Camera camera;

    void Start()
    {
        X = transform.position.x;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax));
        transform.localEulerAngles = new Vector3(Y, X, 0);
        transform.position = transform.localRotation * offset + target.transform.position;
        Debug.Log(transform.position);
        camera = Camera.main;
    }

    void Update()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
        transform.position = transform.localRotation * offset + target.transform.position;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y -= Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, 5, limit);
            transform.localEulerAngles = new Vector3(Y, X, 0);
            transform.position = transform.localRotation * offset + target.transform.position;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (targetCreature == null)
            {
                if(Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject.GetComponent<UnityCreature>()) 
                    {
                        targetCreature = hit.collider.gameObject.GetComponent<UnityCreature>();
                    }
                }
            }
            else
            {
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject.GetComponent<UnityTerrain>())
                    {
                        targetCreature.StartpositionX.value = hit.point.x;
                        targetCreature.StartpositionY.value = hit.point.z;
                        targetCreature.Height.value = hit.point.y;
                    }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (targetCreature != null)
            {
                targetCreature = null;
            }
        }
    }
}
