// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/BendyShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0



        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        fixed4 _Color;

        uniform half3 _CrvOrig;
        uniform fixed3 _RefDir;
        uniform half _Curvature;
        uniform fixed3 _Scale;
        uniform half _FlatMargin;
        uniform half _HorizWaveFreq;

        half4 Bend(half4 v)
        {
            half4 wpos = mul(unity_ObjectToWorld, v);
            half2 xzDist = (wpos.xz - _CrvOrig.xz) / _Scale.xz;
            half dist = length(xzDist);
            half2 direction = lerp(_RefDir.xz, xzDist, min(dist, 1));
            half theta = acos(clamp(dot(normalize(direction), _RefDir.xz), -1,1));
            dist = max(0, dist - _FlatMargin);
            wpos.y -= dist*dist*_Curvature*cos(theta*_HorizWaveFreq);
            wpos = mul(unity_WorldToObject, wpos);

            return wpos;
        }

        void vert (inout appdata_full v)
        {
            v.vertex = Bend(v.vertex);
        }

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Emission = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
