using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Blade : MonoBehaviour
{
    float escapeTime = 2;
    bool isEscaping = false;

    public Material materialSlicedSide;
    public float explosionForce;
    public float explosionRadius;
    public bool gravity, kinematic;
    public GameObject addEffect, slicingEffect;
    bool levelFinished;

    private void OnTriggerEnter(Collider other) {
        if((other.tag == "Floor" && !isEscaping)){
            transform.parent.gameObject.GetComponent<Knife>().ClosePhysicsSimulation();
            isEscaping = true;
            Invoke("FinishEscaping", escapeTime);
        }else{
            switch(other.name){
                case "PointPowerx1":
                    LevelFinish(1);
                    break;
                case "PointPowerx2":
                    LevelFinish(2);
                    break;
                case "PointPowerx6":
                    LevelFinish(6);
                    break;
                case "PointPowerx10":                 
                    LevelFinish(10);
                    break;
            }
        }
        if(other.tag == "PointObject"){
            transform.parent.gameObject.GetComponent<Knife>().SimulationModeSlicing();
            Camera.main.GetComponent<Sounds>().PlaySliceVoice();
            SlicedHull sliceObj = Slice(other.gameObject, materialSlicedSide);
            GameObject slicedObjLeft = sliceObj.CreateUpperHull(other.gameObject, materialSlicedSide);
            GameObject slicedObjRight = sliceObj.CreateLowerHull(other.gameObject, materialSlicedSide);
            Instantiate(addEffect, new Vector3(other.transform.position.x + 0.5f, other.transform.position.y + 0.5f, other.transform.position.z - 2), Quaternion.Euler(new Vector3(0, 45, 0)));
            Destroy(other.gameObject);
            AddComponent(slicedObjLeft);
            AddComponent(slicedObjRight);
            Camera.main.GetComponent<Level>().AddPoint();
        }
    }

    void LevelFinish(int powerPoint){
        if(!levelFinished){
            transform.parent.gameObject.GetComponent<Knife>().ClosePhysicsSimulation();
            transform.parent.gameObject.GetComponent<Knife>().StopMove();
            Camera.main.GetComponent<Level>().LevelUp(powerPoint);
            Camera.main.GetComponent<Canvas>().SetActiveNextLevelButton();
            Camera.main.GetComponent<Canvas>().SetActiveBlackImage();
            levelFinished = true;
        }
        
    }

    void FinishEscaping(){
        isEscaping = false;
    }

    private SlicedHull Slice(GameObject obj, Material mat){
        return obj.Slice(transform.position, transform.forward, mat);
    }

    void AddComponent(GameObject obj){
        var c = obj.AddComponent<MeshCollider>();
        c.convex = true;
        var rb = obj.AddComponent<Rigidbody>();
        rb.useGravity = gravity;
        rb.isKinematic = kinematic;
        if(obj.name == "Upper_Hull"){
            obj.transform.position += new Vector3(0, 0, 0.02f);
            rb.AddForce(Vector3.forward * explosionForce, ForceMode.Impulse);
        }else{
            obj.transform.position += new Vector3(0, 0, -0.02f);
            rb.AddForce(- Vector3.forward * explosionForce, ForceMode.Impulse);
        }
    }

}

