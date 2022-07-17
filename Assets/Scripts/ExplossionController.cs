using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExplossionController : MonoBehaviour
{
    public TriggerExplossion BlastFurnace;
    public GameObject ObjectPrefab,MainCamera;
    public Transform ObjectHolder;
    public Button DamageButton;
    public Button Reset,RotateLeft,RotateRight,ZoomInOut;
    public float Speed=20f;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main.gameObject;
        BlastFurnace = GameObject.FindWithTag("Destroy").GetComponent<TriggerExplossion>();
        DamageButton.onClick.AddListener(delegate { ChangeSliderValue(0); });
        Reset.onClick.AddListener(ResetScene);
    }
    public void ChangeSliderValue(float value)
    {
        if (value == 0)
        {
            BlastFurnace.explode = true;
            DamageButton.interactable = false;
            Reset.gameObject.SetActive(true);
        }

    }

    public void ResetScene()
    {
        Reset.gameObject.SetActive(false);
        DamageButton.interactable = true;
        Destroy(BlastFurnace.gameObject);
        GameObject NewObject = GameObject.Instantiate(ObjectPrefab, ObjectHolder);
        BlastFurnace = NewObject.GetComponent<TriggerExplossion>();
    }

    public void OnMoveCamera(string direction)
    {
        if (direction == "Left")
        {
            MainCamera.transform.Translate(Vector3.left * 1f * Time.deltaTime);
        }
        else
        {
            MainCamera.transform.Translate(Vector3.right *1f * Time.deltaTime);
        }
    }


    private void Update()
    {
        if (ZoomInOut.GetComponent<ClickEnabled>().Clicked)
        {
            if (MainCamera.GetComponent<Camera>().fieldOfView > 20)
            {
                MainCamera.GetComponent<Camera>().fieldOfView -= Speed*4f * Time.deltaTime;
            }
        }
        else { MainCamera.GetComponent<Camera>().fieldOfView = 65f; }
        if (RotateLeft.GetComponent<ClickEnabled>().Clicked)
        {
            OnMoveCamera("Left");
        }
        if (RotateRight.GetComponent<ClickEnabled>().Clicked)
        {
            OnMoveCamera("Right");
        }
        if (Input.GetMouseButton(0))
        {
            MainCamera.transform.eulerAngles+= Speed *new Vector3(x: -Input.GetAxis("Mouse Y"),y: Input.GetAxis("Mouse X"),z: 0);
        }
    }
}
