Shader "Learning/Unlit/SliderTexture"
{
    Properties
    {   
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _MainTex("Grass", 2D) = "white" {} // textures 
        _Bruit("Bruit", 2D) = "black" {} // textures 
        _Lerp("Lerp", Range(0,1)) = 0.5

    }

        SubShader
    {
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex, _Bruit;
            float _Lerp;

			struct vertexInput
            {
                float4 vertex : POSITION;	
                float2 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;    
                float2 uv : TEXCOORD0;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return lerp(tex2D(_MainTex, i.uv),
                            tex2D(_Bruit, i.uv),
                            _Lerp);
            }
            
            ENDHLSL
        }
    }
}
