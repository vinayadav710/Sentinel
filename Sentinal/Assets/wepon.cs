using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class wepon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    PlayerControls controls;

    void Awake() {
        controls = new PlayerControls();
        
        controls.Player.shoot.performed += ctx => Shoot();
    }

    void OnEnable() {
        controls.Player.Enable();
    }

    void OnDisable() {
        controls.Player.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Debug.Log("shot");
    }
}
