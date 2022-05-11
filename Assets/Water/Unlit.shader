Shader "Unlit/Unlit"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _WhiteCapHeight ("Whitecap Height", Float) = 0.4
        _Speed ("Speed", Range(0.0, 10.0)) = 1
        _WaveAmount ("Wave Amount", Range(0.0, 10.0)) = 1
        _WaveAmplitude ("Wave Amplitude", Range(0.0, 5.0)) = 0.2
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

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 worldPosition : POSITION1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            Float _WhiteCapHeight;
            Float _Speed;
            Float _WaveAmount;
            Float _WaveAmplitude;

            v2f vert (appdata v)
            {
                v2f o;
                v.vertex.y += sin(_Time.z * _Speed + ((v.vertex.x + v.vertex.z) * _WaveAmount)) * _WaveAmplitude;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPosition = v.vertex;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                fixed4 color = _Color;
                if (i.worldPosition.y > _WhiteCapHeight)
                {
                    color.x = 1;
                    color.y = 1;
                }

                return color;
            }
            ENDCG
        }
    }
}
