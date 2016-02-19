using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour
{

    private Animator Anim;
    int lightRun1 = Animator.StringToHash("Light_Run1");
    int normalRun1 = Animator.StringToHash("Normal_Run1");
    int heavyRun1 = Animator.StringToHash("Heavy_Run1");
    int heavyRun2 = Animator.StringToHash("Heavy_Run2");
    [SerializeField] private GameObject _stack;
   private stack _stackScript;

    [SerializeField] private int _blockCarryCount;

	// Use this for initialization
	void Start ()
    {
        _stackScript = _stack.GetComponent<stack>();
        Anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
    {
        _blockCarryCount = _stackScript.StackSize;
        AnimatorStateInfo stateInfo = Anim.GetCurrentAnimatorStateInfo(0);
        if (_blockCarryCount <= 1)
        {
            gameObject.transform.Translate(new Vector3(1.9f,0,0) * Time.deltaTime * 1f);
            Anim.SetTrigger("Light_Run1");
            Anim.ResetTrigger("Normal_Run1");
            Anim.ResetTrigger("Heavy_Run1");

        }
        else if (_blockCarryCount >= 2 && _blockCarryCount <= 6)
        {
            gameObject.transform.Translate(new Vector3(0.8f,0,0) * Time.deltaTime * 1f);
            Anim.SetTrigger("Normal_Run1");
            Anim.ResetTrigger("Light_Run1");
            Anim.ResetTrigger("Heavy_Run1");
        } else if (_blockCarryCount >= 7)
        {
            gameObject.transform.Translate(new Vector3(0.75f,0,0) * Time.deltaTime * 1f);
            Anim.SetTrigger("Heavy_Run1");
            Anim.ResetTrigger("Light_Run1");
            Anim.ResetTrigger("Normal_Run1");
        }
	}
}
