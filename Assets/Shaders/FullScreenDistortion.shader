Shader "Custom/FullscreenDistortion"
{
    Properties
    {
        _MainTex ("Render Texture", 2D) = "white" {}
        _Intensity ("Distortion Intensity", Float) = 0.05
        _Frequency ("Wave Frequency", Float) = 10
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float _Intensity;
            float _Frequency;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
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
                float wave = sin(i.uv.y * _Frequency + _Time.y) * _Intensity;
                float2 distortedUV = i.uv + float2(wave, 0);
                return tex2D(_MainTex, distortedUV);
            }
            ENDCG
        }
    }
}
