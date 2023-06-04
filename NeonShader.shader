Shader "Unlit/NeonShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _EmissionColor ("Emission Color", Color) = (0, 0, 0, 0)
        _EmissionStrength ("Emission Strength", Range(0, 1)) = 0.5
        _Frequency ("Frequency", Range(0, 10)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            float4 _Color;
            float4 _EmissionColor;
            float _EmissionStrength;
            float _Frequency;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = _Color;
                // Calculate the emission strength based on time and frequency
                float t = _Time.y * _Frequency;
                float pulse = sin(t * 6.28318530718) * 0.5 + 1.5;
                float emissionStrength = _EmissionStrength * pulse;

                // Add the emission color to the final color
                col.rgb += _EmissionColor.rgb * emissionStrength;

                
                return col;
            }
            ENDCG
        }
    }
}
