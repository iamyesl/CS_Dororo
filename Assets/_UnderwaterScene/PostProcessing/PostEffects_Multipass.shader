Shader "My/PostEffects/PostEffects_MultiPass"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		//Cull Off ZWrite Off ZTest Always
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
		};

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv = v.uv;
			return o;
		}

		sampler2D _MainTex;

		fixed4 frag(v2f i) : SV_Target
		{
			fixed4 col = tex2D(_MainTex, i.uv);

			float grayness = 0.333 * col.r + 0.333 * col.g + 0.333 * col.b;

			fixed4 finalColor = lerp(col, grayness, 1);

			col.rgb = finalColor;

			return col;
		}
		ENDCG
	}

    Pass{

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
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _BlendTex;
            float _Opacity;

            fixed OverlayBlendMode(fixed basePixel, fixed blendPixel){
                if(basePixel < 0.5){
                    return (2.0 * basePixel * blendPixel);
                }
                else
                {
                    return (1.0 - 2.0 * (1.0 - basePixel) * (1.0 - blendPixel));
                }
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 blendTex = tex2D(_BlendTex, i.uv);

                fixed4 blendedImage = col;
                blendedImage.r = OverlayBlendMode(col.r, blendTex.r);
                blendedImage.g = OverlayBlendMode(col.g, blendTex.g);
                blendedImage.b = OverlayBlendMode(col.b, blendTex.b);
                col = lerp(col, blendedImage, _Opacity);
                return col;
            }
            ENDCG
    }

    Pass {

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
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _BlendTex;
            float _Opacity;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 blendTex = tex2D(_BlendTex, i.uv);

                /*
                fixed4 blendedMultiply = col * blendTex;
                col = lerp (col, blendedMultiply, _Opacity);
                */
                
                /*
                fixed4 blendedAdd = col + blendTex;
                col = lerp (col, blendedAdd, _Opacity);   
                */

                fixed4 blendedScreen = (1.0 - ((1.0 - col) * (1.0 - blendTex)));
                col = lerp (col, blendedScreen, _Opacity);   
                
                return col;
            }
            ENDCG
    }

    Pass{
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
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Brightness;
            float _Saturation;
            float _Contrast;
            
            float3 BrightnessSaturationContrast(float3 color, float brightness, float saturation, float contrast){
                float avrgR = 0.5;
                float avrgG = 0.5;
                float avrgB = 0.5;
                
                float3 LuminanceCoeff = float3(0.2125, 0.7154, 0.0721);

                // brightness
                float3 AvrgLumin = float3(avrgR, avrgG, avrgB);
                float3 brtColor = color * brightness;
                float intensityf = dot(brtColor, LuminanceCoeff);
                float3 intensity = float3(intensityf, intensityf, intensityf);

                // saturation 
                float3 satColor = lerp(intensity, brtColor, saturation);

                // contrast 
                float3 conColor = lerp(AvrgLumin, satColor, contrast);
                
                return conColor;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb = BrightnessSaturationContrast(col.rgb, _Brightness, _Saturation, _Contrast);
                return col;
            }
            ENDCG
    }

	
	}
}
