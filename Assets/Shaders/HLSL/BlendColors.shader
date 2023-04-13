Shader "Learning/Unlit/BlendColors"
{
    Properties
    {
        _Color0("First color", Color) = (0.34, 0.85, 0.92, 1)
        _Color1("Second color", Color) = (1, 0, 0, 1)
		
        _LerpAlpha("Lerp Alpha", Range(0,1)) = 0
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _Color0, _Color1;
            float _LerpAlpha;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
				
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                
                return o;
            }
			
            float4 frag(v2f i) : SV_Target
            {
                return lerp(_Color0, _Color1, _LerpAlpha);
            }
            ENDHLSL
        }
    }
}
