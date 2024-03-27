<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPosManager : MonoBehaviour
{
    [SerializeField]
    private Transform _transformCam;
    [SerializeField]
    private Transform _transformCamRig;

    private float posX;
    private float posY;
    private float posZ;
 
    // Update is called once per frame
    void Update()
    {
        posX = _transformCamRig.position.x;
        posZ = _transformCamRig.position.z;

        posY = _transformCam.position.y;

        transform.position = new Vector3(posX,posY,posZ);
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPosManager : MonoBehaviour
{
    [SerializeField]
    private Transform _transformCam;
    [SerializeField]
    private Transform _transformCamRig;

    private float posX;
    private float posY;
    private float posZ;
 
    // Update is called once per frame
    void Update()
    {
        posX = _transformCamRig.position.x;
        posZ = _transformCamRig.position.z;

        posY = _transformCam.position.y;

        transform.position = new Vector3(posX,posY,posZ);
    }
}
>>>>>>> AudioReformedYes
