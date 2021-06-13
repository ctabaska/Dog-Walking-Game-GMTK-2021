using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class DogLeash : MonoBehaviour
{
    public GameObject Player;

    public LineRenderer leash;

    public Color NormalColor = Color.yellow;
    public Color WarningColor = Color.red;

    public float WarningDistance = 10f;
    public float UnleashDistance = 20f;

    public bool OffLeash = false;

    public float ReLeashDistance = 5f;

    public float DogMoveSpeed = 0.2f;


    void Start()
    {
        CreateLeash();   
    }

    void ChangeLeashColor(Color next)
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = next;
        lineRenderer.endColor = next;
    }

    void CreateLeash()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.sortingLayerName = "Leash";
        ChangeLeashColor(NormalColor);
    }

    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

       

        // Set LineRenderer to dog and player
        var points = new Vector3[2];
        points[0] = Player.transform.position;
        points[1] = GetComponent<Transform>().position;

        var playerDistance = Vector3.Distance(points[0], points[1]);

        if (OffLeash && playerDistance <= ReLeashDistance) // If Player is close releash the dog
        {
            OffLeash = false;
            CreateLeash();
        }

        if (lineRenderer == null)
            return;

        // If Player is going out of range from Dog change color
        if ( playerDistance >= WarningDistance)
            ChangeLeashColor(WarningColor);
        else
            ChangeLeashColor(NormalColor);

        if ( !OffLeash && playerDistance >= UnleashDistance) // If Player is far away dog goes off leash
        {
            OffLeash = true;
            Destroy(lineRenderer);
        }

        lineRenderer.SetPositions(points);


        // if dog is far away from the character start moving slowly to the character

        if (playerDistance >= WarningDistance - 2)
        {
            GetComponent<Transform>().position = Vector2.MoveTowards(points[1], points[0], DogMoveSpeed * 0.1f);
        }

    }
}
