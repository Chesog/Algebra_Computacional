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
        /// <summary>
        /// Checks if the Quat lhs is equal to rhs
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Quat lhs, Quat rhs) 
        {
            return (lhs.xq == rhs.xq && lhs.yq == rhs.yq && lhs.zq == rhs.zq && lhs.wq == rhs.wq);
        }

        /// <summary>
        /// Check if Quat lhs is unequal to rhs
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Quat lhs, Quat rhs) 
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Multiply Quaternion x Quaternion
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Quat operator *(Quat lhs, Quat rhs)
        {
            float new_xq = lhs.wq * rhs.xq + lhs.xq * rhs.wq + lhs.yq * rhs.zq - lhs.zq * rhs.yq;
            float new_yq = lhs.wq * rhs.yq + lhs.yq * rhs.wq + lhs.zq * rhs.xq - lhs.xq * rhs.zq;
            float new_zq = lhs.wq * rhs.zq + lhs.zq * rhs.wq + lhs.xq * rhs.yq - lhs.yq * rhs.xq;
            float new_wq = lhs.wq * rhs.wq - lhs.xq * rhs.xq - lhs.yq * rhs.yq - lhs.zq * rhs.zq;

            return new Quat(new_xq, new_yq, new_zq, new_wq);
        }

        /* https://es.wikipedia.org/wiki/Cuaterni%C3%B3n */

        /// <summary>
        ///Applies the rotation to the specified point
        /// </summary>
        /// <param name="rotation"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vec3 operator *(Quat rotation, Vec3 point)
        {
            float rotX = rotation.xq * 2f;
            float rotY = rotation.yq * 2f;
            float rotZ = rotation.zq * 2f;

            float rotX2 = rotation.xq * rotX;
            float rotY2 = rotation.yq * rotY;
            float rotZ2 = rotation.zq * rotZ;

            float rotXY = rotation.xq * rotY;
            float rotXZ = rotation.xq * rotZ;
            float rotYZ = rotation.yq * rotZ;

            float rotWX = rotation.wq * rotX;
            float rotWY = rotation.wq * rotY;
            float rotWZ = rotation.wq * rotZ;

            Vec3 result = Vec3.Zero;

            result.x = (1f - (rotY2 + rotZ2)) * point.x + (rotXY - rotWZ) * point.y + (rotXZ + rotWY) * point.z;
            result.y = (rotXY + rotWZ) * point.x + (1f - (rotX2 + rotZ2)) * point.y + (rotYZ - rotWX) * point.z;
            result.z = (rotXZ - rotWY) * point.x + (rotYZ + rotWX) * point.y + (1f - (rotX2 + rotY2)) * point.z;

            return result;
        }

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

        /// <summary>
        /// Represents the rotation of a quaternion with the axes of the world (The "No Rotation")
        /// </summary>
        public static Quat identity
        {
            get { return new Quat(0, 0, 0, 1); }
        }
        #endregion

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
