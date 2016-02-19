using UnityEngine;
using System.Collections;

public class playerInput : MonoBehaviour {

    private enum State {main, letter, sending, shooting};
    private float _force = 500f;
    [SerializeField] private GameObject stack;
    [SerializeField] private GameObject letter;
    [SerializeField] private GameObject _bullet;
    private Vector3 _bulletStartPos;
    private stack _stackScript;
    private float screenWidth;
    private float screenHeight;
    private State _state;
    private block _block;
    private bool _shooting = true;
    private bool _select = true;

	void Start ()
    {
        _bulletStartPos = _bullet.transform.position;
        _state = State.main;
        letter.SetActive(false);
        Camera cam = Camera.main;
        screenHeight = 2f * cam.orthographicSize;
        screenWidth = screenHeight * cam.aspect;
        _stackScript = stack.GetComponent<stack>();
        letter.SetActive(false);
    }

    private void Update ()
    {
        if(_state == State.main)
        {
            if (Input.GetMouseButtonDown (0) && _select){
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if ( Physics.Raycast (ray,out hit,100.0f)) {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    if(hit.transform.tag == "block")
                    {
                        _block = hit.transform.gameObject.GetComponent<block>();
                        ChangeState(State.letter);
                        _select = false;
                    }
                }
            }
        }

        if(_state == State.shooting)
        {
            if ( Input.GetMouseButtonDown (0) && _shooting)
            {
                print("shoot");
                _bullet.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                _bullet.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1f,0.5f,1f) * _force);
                ChangeState(State.main);
                _shooting = false;
            }
        }
    }

    private IEnumerator ToShooting()
    {
        _stackScript.SavePosition();
        yield return new WaitForSeconds(1);
        _stackScript.ActivatePhysics();
        _shooting = true;
    }

    private IEnumerator ToMain()
    {
        yield return new WaitForSeconds(6);
        _stackScript.DeactivatePhysics();
        _stackScript.ReturnPosition();
        _bullet.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        _bullet.transform.localPosition = _bulletStartPos;
        _bullet.transform.rotation = Quaternion.identity;
        _select = true;
    }

    private void ToSending()
    {
        letter.SetActive(false);
        _block.ActivatePhysics();
        _block.Nocolider();
        _block.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1f) * _force);
        _block.transform.parent = null;
        ChangeState(State.shooting);
    }

    private void ToLetter()
    {
        letter.SetActive(true);
    }

    private void ChangeState(State newState)
    {
        letter.SetActive(false);
        if(newState == State.letter)
        {
            ToLetter();
        }
        else if(newState == State.shooting)
        {
            StartCoroutine(ToShooting());
        }
        else if(newState == State.main)
        {
            StartCoroutine(ToMain());
            //ToMain();
        }
        else if(newState == State.sending)
        {
            ToSending();
        }

        _state = newState;
    }

    public void TriggerSending()
    {
        ChangeState(State.sending);
    }
}
