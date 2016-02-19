using UnityEngine;
using System.Collections;

public class LetterAnimation : MonoBehaviour {
    private Vector3 _startPos = new Vector3(0,0,2f);
    private Vector3 _endPos = new Vector3(0,0,0f);
    private float _timeTaken;
    private bool _isLerping;
    private float _timeStartedLerp;
    private float _timeTakenDuringLerp = 1f;


    public void StartLerp ()
    {
        _isLerping = true;
        _timeStartedLerp = Time.time;
        print(_timeStartedLerp);

    }

    void FixedUpdate()
    {
        if(_isLerping)
        {
            float timeSinceStarted = Time.time - _timeStartedLerp;
            float percentageComplete = timeSinceStarted / _timeTakenDuringLerp;
            print(percentageComplete);

            gameObject.transform.localPosition = Vector3.Lerp (_startPos, _endPos, percentageComplete);

            if(percentageComplete >= 1.0f)
            {
                _isLerping = false;
            }
        }
    }
}

