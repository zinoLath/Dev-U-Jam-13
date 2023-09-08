// Define RADIANS to work in radians
// Alternatively Define NORMALIZED to work in normalized [0,1] angles
// defaults to degrees
//CODE BY TEXEL!!!!!
#define NORMALIZED

using UnityEngine;
using System.Collections;

// Convention:
// 0 equates to +X, counter-clockwise rotation 

public struct Angle {
	const int LSIZE = 4096; // Lookup table size (number of unique angles)
	const float RSIZE = 1f/LSIZE;
	const float ANGLESTEP = TWOPI / LSIZE;
	const float TWOPI = Mathf.PI * 2f;
	
	static private Vector2[] lookupTable;
	static private Quaternion[] quaternionTable;
	static private Quaternion[] transposedTable;
	static private Quaternion[] inverseTable;

	static Angle() {
		lookupTable = new Vector2[LSIZE];
		quaternionTable = new Quaternion[LSIZE];
		transposedTable = new Quaternion[LSIZE];
		inverseTable = new Quaternion[LSIZE];

		var NinetyDegrees = Quaternion.AngleAxis(90,Vector3.forward);

		for (int i = 0; i < LSIZE; ++i) {
			var angle = i * ANGLESTEP;
			float sin = Mathf.Sin(angle), cos = Mathf.Cos(angle);
			lookupTable[i] = new Vector2(cos,sin);
			quaternionTable[i] = Quaternion.AngleAxis(angle * Mathf.Rad2Deg,Vector3.forward);
			transposedTable[i] = quaternionTable[i] * NinetyDegrees;
			inverseTable[i] = Quaternion.Inverse(quaternionTable[i]);
		}
	}
	
	internal int lookupIndex;
	
	public Angle(float a) {
		#if RADIANS
			lookupIndex = ((int)((Mathf.Repeat(a,TWOPI)/TWOPI) * LSIZE));
		#elif NORMALIZED
			lookupIndex = (int)(Mathf.Repeat(a,1f)*LSIZE);
		#else
			lookupIndex = ((int)((Mathf.Repeat(a,360f)/360f) * LSIZE));
		#endif
	}
	
	public float angle {
		get {
			#if RADIANS
				return lookupIndex * RSIZE * TWOPI;
			#elif NORMALIZED
				return lookupIndex * RSIZE;
			#else
				return lookupIndex * RSIZE * 360;
			#endif
		}
		set {
			this = new Angle(value);
		}
	}
	
	// Internal constructor for explicit creation on indexing
	internal Angle(int index) {
		lookupIndex = index;
	}

	public Quaternion quaternion {
		get { return quaternionTable[lookupIndex]; }
	}
	public Quaternion transpose {
		get { return transposedTable[lookupIndex]; }
	}
	public Quaternion inverse {
		get { return inverseTable[lookupIndex]; }
	}

	public Vector2 heading { 
		get { return lookupTable[lookupIndex]; }
	}
	
	public Vector2 perpendicular { 
		get { return lookupTable[(this.lookupIndex + THREEFOURTHS) % LSIZE]; }
	}
	
	// Arctangent/Angle between
	const float INVTWOPI = 0.159154940f;
	public static Angle between(float x, float y) { 
		// Normalized coordinate arctangent
		float atan = (float)System.Math.Atan2(y,x) * INVTWOPI;
		
		return new Angle((int)(Mathf.Repeat(atan,1f)*LSIZE));
	}
	public static Angle between(Vector2 off) { return between(off.x,off.y); }
	public static Angle between(Vector2 a, Vector2 b) { return between(b.x-a.x,b.y-a.y); }
	
	public static Angle operator -(Angle A, Angle B) {
		int index = A.lookupIndex + (A.lookupIndex - B.lookupIndex);
		// Since both angles are inherently bound within [0,LSIZE), bounds resetting is single-step
		return new Angle(
			index < 0 ? LSIZE - index : 
			index >= LSIZE ? index - LSIZE :
			index );
	}
	
	public static Angle operator +(Angle A, Angle B) {
		int index = A.lookupIndex + B.lookupIndex;
		// Since both angles are inherently bound within [0,LSIZE), bounds resetting is single-step
		return new Angle(
			index >= LSIZE ? index - LSIZE :
			index );
	}
	
	const int THREEFOURTHS = (3*LSIZE)/4;
	public static Vector2 operator *(Vector2 v, Angle A) {
		// We already have the translated X, simply by our lookup index
		// To get the Y, however, we lookup at an offset of 270 degrees (or -90)
		var xVec = lookupTable[A.lookupIndex];
		var yVec = lookupTable[(A.lookupIndex + THREEFOURTHS) % LSIZE];
		return new Vector2(
			(xVec[0] * v[0]) + (yVec[1] * v[0]),
			(xVec[1] * v[1]) + (yVec[0] * v[1]) );
	}
	public static Vector2 operator *(Angle A, Vector2 v) {
		var xVec = lookupTable[A.lookupIndex];
		var yVec = lookupTable[(A.lookupIndex + THREEFOURTHS) % LSIZE];
		return new Vector2(
			(xVec[0] * v[0]) + (yVec[1] * v[0]),
			(xVec[1] * v[1]) + (yVec[0] * v[1]) );
	}
}