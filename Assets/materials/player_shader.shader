Shader "Unlit/test_player"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("couleur",Color) =(1,1,1)
        _NLines("n_lines",Int) = 1
        //_IsHeal("heal",bool)=true
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
                float4 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            int _NLines=1;
            fixed4 _Color;
            fixed4 _ColorHit;
            fixed4 _ColorHeal;
            int _IsHit;
            int _IsHeal;

            v2f vert (appdata v)
            {
                v2f o;
                bool test=true;
                for (int j=0;j<_NLines;j++){
                    if (v.vertex.y+0.5>(2*j+1)*1.0/(2*_NLines+1) && v.vertex.y+0.5<(2*(j+1))*1.0/(2*_NLines+1)){ //v.vertex.y+0.01>(2*j+1)*0.02/(2*_NLines+1) && v.vertex.y+0.01<(2*(j+1))*0.02/(2*_NLines+1)
                        test=false;
                    }
                }
                if (test == true){
                    o.vertex = UnityObjectToClipPos(v.vertex-v.normal*0.1);
                }
                else {
                    o.vertex = UnityObjectToClipPos(v.vertex);
                }
                
                
                //o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;
                // sample the texture
                if (_IsHit==1){
                    col = tex2D(_MainTex, i.uv)*_ColorHit;
                }
                else if (_IsHeal==1){
                    col = tex2D(_MainTex, i.uv)*_ColorHeal;
                }
                else {
                    col = tex2D(_MainTex, i.uv)*_Color;
                }
                
                
                return col;
            }
            ENDCG
        }
    }
}
