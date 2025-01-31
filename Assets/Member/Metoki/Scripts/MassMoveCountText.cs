using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassMoveCountText : MonoBehaviour
{
    public static MassMoveCountText Instance;
    [SerializeField]
    private Text _stepText;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateText(int remainingSteps)
    {
        _stepText.text = remainingSteps.ToString();
    }
}
