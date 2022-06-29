using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float rotateSpeed = 1f, moveSpeed = 1f, SliceForce = 5f;
    Rigidbody r;
    float coefficientOfForceX = 1f, coefficientOfForceY = 2.5f, moveTime = 0.25f, distanceCamAndKnife = 0.75f, torqueTime = 2f;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0) && canMove){
            Camera.main.GetComponent<Sounds>().PlayTurnVoice();
            ClosePhysicsSimulation();
            OpenPhysicsSimulation();
            r.AddTorque(Vector3.forward * - rotateSpeed * Time.timeScale, ForceMode.Impulse);
            r.AddForce(new Vector3(coefficientOfForceX, coefficientOfForceY, 0) * moveSpeed * Time.timeScale, ForceMode.Impulse);
        }
    }

    void FixedUpdate(){
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Plane"){
            Camera.main.GetComponent<Level>().GameOver();
            StopMove();
        }
    }

    void LateUpdate() {
        Camera.main.transform.position = new Vector3(PosX(), PosY() + 0.5f, -6);
    }

    float PosX(){
        if(transform.position.x - 3 < Camera.main.transform.position.x){
            return Camera.main.transform.position.x;
        }else{
            return transform.position.x - 3;
        }
    }

    float PosY(){
        if(transform.position.y - Camera.main.transform.position.y > distanceCamAndKnife){
            return transform.position.y - distanceCamAndKnife;
        }else if( Camera.main.transform.position.y - transform.position.y > distanceCamAndKnife){
            return transform.position.y + distanceCamAndKnife;
        }else{
            return Camera.main.transform.position.y;
        }
    }

    public void OpenPhysicsSimulation(){
        SimulationModeFree();
    }

    public void ClosePhysicsSimulation(){
        r.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void SimulationModeFree(){
        r.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

    public void SimulationModeSlicing(){
        r.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void StopMove(){
        canMove = false;
    }
}
