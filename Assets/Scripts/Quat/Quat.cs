using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace CustomMath
{
    [Serializable]
    public struct Quat
    {
        #region Variables
        public const float kEpsilon = 1E-06F;
        public float xq, yq, zq, wq;
        #endregion

        #region Constructor
        public Quat(float xq, float yq, float zq, float wq)
        {
            this.xq = xq;
            this.yq = yq;
            this.zq = zq;
            this.wq = wq;
        }
        #endregion

        #region Operators
        public static bool operator ==(Quat lhs, Quat rhs) 
        {
            return (lhs.xq == rhs.xq && lhs.yq == rhs.yq && lhs.zq == rhs.zq && lhs.wq == rhs.wq);
        } 

        public static bool operator !=(Quat lhs, Quat rhs) 
        {
            return !(lhs == rhs);
        }

        public static Quat operator *(Quat lhs, Quat rhs)
        {
            return new Quat(0f,0f,0f,0f);
        }

        public static Vec3 operator *(Quat rot, Vec3 point) // Le aplica la rotación a un punto
        {
            return new Vec3();
        }
        #endregion

        public float this[int index]
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }

        public static Quat identity
        {
            get { return new Quat(0, 0, 0, 0f); }
        }
        public static Quat Euler(float xq, float yq, float zq)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat Euler(Vec3 angle)
        {
            return new Quat(0, 0, 0, 0f);
        }
        public static Quat EulerAngles(float x, float y, float z)
        {
            return new Quat(0, 0, 0, 0f);
        }
        public static Quat EulerAngles(Vec3 angle)
        {
            return new Quat(0, 0, 0, 0f);
        }
        public static Quat Normalize(Quat q)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public void Normalize()
        {
            this = Normalize(this);
        }

        public static float Angle(Quat a, Quat b)
        {
            return 0f;
        }

        public static Quat AngleAxis(float angle, Vec3 axis)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat AxisAngle(Vec3 axis, float angle) 
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static float Dot(Quat a, Quat b)
        {
            return 0f;
        }

        public static Quat FromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat Inverse(Quat rotation)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat Lerp(Quat a, Quat b, float t)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat LerpUnclamped(Quat a, Quat b, float t)
        {
            return new Quat(0, 0, 0, 0f);
        }


        public static Quat SetLookRotation(Vec3 view)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat SetLookRotation(Vec3 view, Vec3 upwards)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat RotateTowards(Quat from, Quat to, float maxDegreesDelta)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat Slerp(Quat a, Quat b, float t) 
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat SlerpUnclamped(Quat a, Quat b, float t)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public void Set(float new_xq, float new_yq, float new_zq, float new_wq)
        {
            xq = new_xq;
            yq = new_yq;
            zq = new_zq;
            wq = new_wq;
        }

        public static Quat SetFromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public static Quat LookRotation(Vec3 forward, Vec3 upwards)
        {
            return new Quat(0, 0, 0, 0f);
        }

        public void ToAngleAxis(out float angle, out Vec3 axis)
        {
            angle = 0.0f;
            axis = new Vec3();
        }

        public string ToString() 
        {
           return new string ("Xq Value : " + this.xq + ", Yq Value : " + this.yq + ", Zq Value : " + this.zq + ", Wq Value : " + this.wq);
        }
    }
}
