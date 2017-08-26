using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Blade : MonoBehaviour {

    private bool isCutting;
    private Rigidbody2D rb;
    private GameObject currentBladeTrail;
    private CircleCollider2D circleCollider;
    private Vector2 previousPos;


    public GameObject bladeTrailPrefab;
    public float minCuttingVelocity = 0.001f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        circleCollider = this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }


        if(isCutting)
        {
            UpdateCut();
        }

	}

    private void UpdateCut()
    {
        Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;

        float velocity = (newPos - previousPos).magnitude / Time.deltaTime;
        if(velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPos = newPos;
    }

    private void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, this.gameObject.transform) as GameObject;
        previousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    private void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }


}
