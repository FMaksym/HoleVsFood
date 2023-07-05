using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SphereCollider))]
public class Magnet : MonoBehaviour
{
    [SerializeField] private float _magnetForce;

    private List<Rigidbody> affectedRigidbodies = new List<Rigidbody>();
    private Transform magnet;

    private void Start()
    {
        magnet = transform;
        affectedRigidbodies.Clear();
    }

    private void FixedUpdate()
    {
        if (!Game.IsGameOver)
        {
            foreach (Rigidbody rigidbody in affectedRigidbodies)
            {
                rigidbody.AddForce((magnet.position - rigidbody.position) * _magnetForce * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Game.IsGameOver)
        {
            if (other.gameObject.GetComponent<Bomb>() || other.gameObject.GetComponent<Food>())
            {
                AddToMagnet(other.attachedRigidbody);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!Game.IsGameOver)
        {
            if (other.gameObject.GetComponent<Bomb>() || other.gameObject.GetComponent<Food>())
            {
                RemoveFromMagnet(other.attachedRigidbody);
            }
        }
    }

    private void AddToMagnet(Rigidbody rigidbody)
    {
        affectedRigidbodies.Add(rigidbody);
    }

    public void RemoveFromMagnet(Rigidbody rigidbody)
    {
        affectedRigidbodies.Remove(rigidbody);
    }
}
