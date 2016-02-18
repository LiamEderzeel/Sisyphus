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
    private block _block;

	void Start ()
    {
        _state = State.main;
        letter.SetActive(false);
        Camera cam = Camera.main;
        screenHeight = 2f * cam.orthographicSize;
        screenWidth = screenHeight * cam.aspect;
        _stackScript = stack.GetComponent<stack>();
            letter.SetActive(false);
    }

    void Update ()
    {
        if(_state == State.main)
        {
            if ( Input.GetMouseButtonDown (0)){
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if ( Physics.Raycast (ray,out hit,100.0f)) {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    _block = hit.transform.gameObject.GetComponent<block>();
                    ChangeState(State.letter);
                }
            }
        }

        if(_state == State.letter)
        {
        }

    }

    private void Sending()
    {
        ChangeState(State.letter);
        letter.SetActive(false);
        _block.ActivatePhysics();
        _block.Nocolider();
        _block.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1f) * _force);
        ChangeState(State.main);
    }

    private void ChangeState(State newState)
    {
        letter.SetActive(false);
        if(newState == State.letter)
        {
            letter.SetActive(true);
        }
        _state = newState;
    }

    public void ToSending()
    {
        Sending();
    }
}
