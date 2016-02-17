using UnityEngine;
using System.Collections;

public class playerInput : MonoBehaviour {

    private enum State {main, letter, sending};
    private float _force = 500f;
    [SerializeField] private GameObject stack;
    [SerializeField] private GameObject letter;
    private stack _stackScript;
    private float screenWidth;
    private float screenHeight;
    private State _state;

	void Start ()
    {
        _state = State.main;
        letter.SetActive(false);
        Camera cam = Camera.main;
        screenHeight = 2f * cam.orthographicSize;
        screenWidth = screenHeight * cam.aspect;
        _stackScript = stack.GetComponent<stack>();
    }

    void Update ()
    {
        if(_state == State.main)
        {
            letter.SetActive(false);
            if ( Input.GetMouseButtonDown (0)){
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if ( Physics.Raycast (ray,out hit,100.0f)) {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    block _block = hit.transform.gameObject.GetComponent<block>();
                    _block.ActivatePhysics();
                    _block.Nocolider();
                    hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1f) * _force);
                    letter.SetActive(true);
                    ChangeState(State.letter);
                }
            }

            if(_state == State.letter)
            {
                    letter.SetActive(true);
            }

            if(_state == State.sending)
            {
            }
        }
    }

    private void ChangeState(State newState)
    {
        _state = newState;
    }
}
