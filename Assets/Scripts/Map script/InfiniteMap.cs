using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InfiniteMap : MonoBehaviour
{

    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private int floorSize;

    private GameObject _floor;
    private GameObject _player;

    private void Start()
    {
        _floor = GameObject.FindGameObjectWithTag("Floor");
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    void updateFloor()
    {
        _floor = GameObject.FindGameObjectWithTag("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast depuis le player pour connaitre le plan en dessous
        if (_floor != null && _player != null)
        {
            Vector3 playerPosition = _player.transform.position;
            Vector3 rayDirection = Vector3.down;

            if (Physics.Raycast(playerPosition, rayDirection, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("Floor"))
                {
                    generateFloor(hit.collider.gameObject);
                }
            }

            else
            {
                Debug.Log("Not above floor");
            }
        }
    }
    void generateFloor(GameObject floor)
    {
        if (Physics.OverlapSphere(floor.transform.position + Vector3.forward * floorSize, 0.1f).Length == 0)
        {
            GameObject.Instantiate(floorPrefab, floor.transform.position + Vector3.forward * floorSize, Quaternion.identity);
        }
        if (Physics.OverlapSphere(floor.transform.position + Vector3.back * floorSize, 0.1f).Length == 0) 
        {
            GameObject.Instantiate(floorPrefab, floor.transform.position + Vector3.back * floorSize, Quaternion.identity);
        }
        if (Physics.OverlapSphere(floor.transform.position + Vector3.right * floorSize, 0.1f).Length == 0)
        {
            GameObject.Instantiate(floorPrefab, floor.transform.position + Vector3.right * floorSize, Quaternion.identity);
        }
        if (Physics.OverlapSphere(floor.transform.position + Vector3.left * floorSize, 0.1f).Length == 0)
        {
            GameObject.Instantiate(floorPrefab, floor.transform.position + Vector3.left * floorSize, Quaternion.identity);
        }

        if (Physics.OverlapSphere(floor.transform.position + Vector3.forward * floorSize + Vector3.right * floorSize, 0.1f).Length == 0)
        {
            GameObject.Instantiate(floorPrefab, floor.transform.position + Vector3.forward * floorSize + Vector3.right * floorSize, Quaternion.identity);
        }
        if (Physics.OverlapSphere(floor.transform.position + Vector3.forward * floorSize + Vector3.left * floorSize, 0.1f).Length == 0)
        {
            GameObject.Instantiate(floorPrefab, floor.transform.position + Vector3.forward * floorSize + Vector3.left * floorSize, Quaternion.identity);
        }
        if (Physics.OverlapSphere(floor.transform.position + Vector3.back * floorSize + Vector3.right * floorSize, 0.1f).Length == 0)
        {
            GameObject.Instantiate(floorPrefab, floor.transform.position + Vector3.back * floorSize + Vector3.right * floorSize, Quaternion.identity);
        }
        if (Physics.OverlapSphere(floor.transform.position + Vector3.back * floorSize + Vector3.left * floorSize, 0.1f).Length == 0)
        {
            GameObject.Instantiate(floorPrefab, floor.transform.position + Vector3.back * floorSize + Vector3.left * floorSize, Quaternion.identity);
        }
    }
    
}
