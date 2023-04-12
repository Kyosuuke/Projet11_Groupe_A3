Shader"Learning/Unlit/GrassTexture"
{
    Properties
    {   
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _Grass("Grass", 2D) = "white" {} // textures 
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }

		Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
			
            sampler2D _Grass;

			struct vertexInput
            {
                float4 vertex : POSITION;	
                float3 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;  
                float3 uv : TEXCOORD0;
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
                return tex2D(_Grass, i.uv);
            }
            
            ENDHLSL
        }
    }
}
