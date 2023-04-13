Shader "Learning/Unlit/BlendTextures_Distance"
{
    Properties
    {
        _Albedo0("Default Albedo", 2D) = "white" {}
        _Albedo1("Second Albedo", 2D) = "black" {}
        _DistanceRange("Distance Range", Range(0.1, 30)) = 100
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

            sampler2D _Albedo0, _Albedo1;
            float _DistanceRange;
            float3 _WorldSpacePlayerPos;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0; // TEXCOORD0: représente le premier set d'UV. Un modèle 3D peut en avoir plusieurs.
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
				float3 worldSpacePos : TEXCOORD1;// semantic TEXCOORD1 car TEXCOORD0 est déjà utilisée 
            };

            v2f vert (appdata v)
            {
                v2f o;

	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex).xyz;  
				// unity_ObjectToWorld => float4x4, c'est une matrice de transformation de l'espace objet à l'espace monde.
				// ici on utilise la fonction: mul(float4x4, float4) => retourne un float4.
				
                o.uv = v.uv;

                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float d = distance(i.worldSpacePos, _WorldSpacePlayerPos) / _DistanceRange;
                float t = clamp(d, 0, 1);

                return lerp(tex2D(_Albedo0, i.uv), tex2D(_Albedo1, i.uv),t);
            }
            ENDHLSL
        }
    }
}
