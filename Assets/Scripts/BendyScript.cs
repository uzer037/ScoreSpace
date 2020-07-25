using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BendyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform curveOrigin;
    public Transform referenceDir;
    public float curvature = 0;
    public Vector3 scale = Vector3.one;
    public float margin = 0;
    public float frequency = 0;
    public bool isBendy = true;
    //------------------------//
    private int curveOriginId;
    private int referenceDirId;
    private int curvatureId;
    private int scaleId;
    private int marginId;
    private int frequencyId;

    void Start()
    {
        curveOriginId = Shader.PropertyToID("_CrvOrig");
        referenceDirId = Shader.PropertyToID("_RefDir");
        curvatureId = Shader.PropertyToID("_Curvature");
        scaleId = Shader.PropertyToID("_Scale");
        marginId = Shader.PropertyToID("_FlatMargin");
        frequencyId = Shader.PropertyToID("_HorizWaveFreq");
    }

    // Update is called once per frame
    void Update()
    {
        int canBend = 0;
        if(isBendy)
            canBend = 1;
            
        scale.y = 0;
        Shader.SetGlobalVector(curveOriginId,curveOrigin.position);
        Shader.SetGlobalVector(referenceDirId, referenceDir.forward);
        Shader.SetGlobalFloat(curvatureId, curvature*canBend);
        Shader.SetGlobalVector(scaleId,scale);
        Shader.SetGlobalFloat(marginId,margin);
        Shader.SetGlobalFloat(frequencyId,frequency);
    }
}
