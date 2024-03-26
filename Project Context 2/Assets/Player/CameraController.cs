using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [SerializeField]
    private Transform _cameraTranform;
    [SerializeField]
    private float _normalSpeed;
    [SerializeField]
    private float _fastSpeed;
    [SerializeField]
    private float _movementTime;
    [SerializeField]
    private float _rotationAmount;
    [SerializeField]
    private Vector3 _zoomAmount;
    [SerializeField]
    private float _minZoom;
    [SerializeField]
    private float _maxZoom;
   
    

    private float _movementSpeed;

    private Vector3 _newPosition;
    public Vector3 _newZoom { get; private set; }
    private Vector3 _dragStartPosition;
    private Vector3 _dragCurrentPosition;

    private Quaternion _newRotation;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        _newPosition = transform.position;
        _newRotation = transform.rotation;
        _newZoom = _cameraTranform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInput();
        HandleInput();   
    }
    private void LateUpdate()
    {
        HandleMovement();
    }

    private void HandleMouseInput()
    {
        //checking left click
        if (Input.GetMouseButtonDown(0))
        {
            //raycast
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry))
            {
                _dragStartPosition = ray.GetPoint(entry);
            }
        }
        //checking if mouse is held down
        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                _dragCurrentPosition = ray.GetPoint(entry);
                _newPosition = transform.position + _dragStartPosition - _dragCurrentPosition;
            }
        }
    }
    private void HandleInput()
    {
        //fast camera movement check
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _movementSpeed = _fastSpeed;
        }
        else
        {
            _movementSpeed = _normalSpeed;
        }
        //checking for movement input
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _newPosition += (transform.forward * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _newPosition += (transform.forward * -_movementSpeed);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
        {
            _newPosition += (transform.right * _movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
        {
            _newPosition += (transform.right * -_movementSpeed);
        }
        //checking for rotation input
        if (Input.GetKey(KeyCode.Q))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * _rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * -_rotationAmount);
        }
        //checking for zoom input
        if (Input.GetKey(KeyCode.R))
        {
          _newZoom += _zoomAmount;
           
        }
        if (Input.GetKey(KeyCode.F))
        {
            _newZoom -= _zoomAmount;
        }
        //clamping zoom
        _newZoom = new Vector3(0, Mathf.Clamp(_newZoom.y, _minZoom, _maxZoom), Mathf.Clamp(_newZoom.z, -_maxZoom, -_minZoom));

    }
    private void HandleMovement()
    {
        //lerping to position of input
        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * _movementTime);
        //lerping to Rotation of input
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * _movementTime);
        //lerping to zoom of input
        _cameraTranform.localPosition = Vector3.Lerp(_cameraTranform.localPosition, _newZoom, Time.deltaTime * _movementTime);
    }

}
