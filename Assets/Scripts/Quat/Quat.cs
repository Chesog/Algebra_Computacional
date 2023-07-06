using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UIElements;

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

        /// <summary>
        /// Constructor For A Quaternion
        /// </summary>
        /// <param name="xq"></param>
        /// <param name="yq"></param>
        /// <param name="zq"></param>
        /// <param name="wq"></param>
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

        /// <summary>
        /// Select a Number Between 1 to 4
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return xq;
                        break;
                    case 2:
                        return yq;
                        break;
                    case 3:
                        return zq;
                        break;
                    case 4:
                        return wq;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Index out of Range!");
                }
            }
            set
            {
                switch (index)
                {
                    case 1:
                        xq = value;
                        break;
                    case 2:
                        yq = value;
                        break;
                    case 3:
                        zq = value;
                        break;
                    case 4:
                        wq = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Index out of Range!");
                }
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

        /// <summary>
        /// Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order).
        /// </summary>
        /// <param name="xq"></param>
        /// <param name="yq"></param>
        /// <param name="zq"></param>
        /// <returns></returns>
        public static Quat Euler(float xq, float yq, float zq)
        {
            /* https://docs.unity3d.com/es/530/ScriptReference/Quaternion.Euler.html */
            float sin;
            float cos;
            Quat qX, qY, qZ;
            Quat ret = identity;

            sin = Mathf.Sin(Mathf.Deg2Rad * xq * 0.5f); //For the imaginary part, we use Sin
            cos = Mathf.Cos(Mathf.Deg2Rad * xq * 0.5f); //For the real part, we use Cos
            qX = new Quat(sin, 0, 0, cos);

            sin = Mathf.Sin(Mathf.Deg2Rad * yq * 0.5f);
            cos = Mathf.Cos(Mathf.Deg2Rad * yq * 0.5f);
            qY = new Quat(0, sin, 0, cos);

            sin = Mathf.Sin(Mathf.Deg2Rad * zq * 0.5f);
            cos = Mathf.Cos(Mathf.Deg2Rad * zq * 0.5f);
            qZ = new Quat(0, 0, sin, cos);

            ret = qY * qX * qZ;

            return ret;
        }

        /// <summary>
        /// Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order) whit an Angle.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Quat Euler(Vec3 angle)
        {
            return Euler(angle.x, angle.y, angle.z);
        }
        /// <summary>
        /// Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Quat EulerAngles(float x, float y, float z)
        {
            return Euler(x, y, z);
        }
        /// <summary>
        /// Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order).
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Quat EulerAngles(Vec3 angle)
        {
            return Euler(angle.x, angle.y, angle.z);
        }
        /// <summary>
        /// Given a quaternion of the form Q=a+bi+cj+dk, the normalized quaternion is defined as Q/√a2+b2+c2+d2.
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Quat Normalize(Quat q)
        {
            float sqrtDot = Mathf.Sqrt(Dot(q, q));

            if (sqrtDot < Mathf.Epsilon)
            {
                return identity;
            }

            return new Quat(q.xq / sqrtDot, q.yq / sqrtDot, q.zq / sqrtDot, q.wq / sqrtDot);
        }

        /// <summary>
        /// Given a quaternion of the form Q=a+bi+cj+dk, the normalized quaternion is defined as Q/√a2+b2+c2+d2.
        /// </summary>
        public void Normalize()
        {
            this = Normalize(this);
        }
        /// <summary>
        /// Returns the angle in degrees between two rotations a and b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Angle(Quat a, Quat b)
        {
            /* https://docs.unity3d.com/ScriptReference/Quaternion.Angle.html */
            float dot = Dot(a, b);

            if (dot > 0.999999f)
                return 0f;
            else
                return (Mathf.Acos(Mathf.Min(Mathf.Abs(dot), 1f)) * 2f * Mathf.Rad2Deg);
        }
        /// <summary>
        /// Returns the rotation of the axis vector usign "Rad"
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static Quat AngleAxis(float angle, Vec3 axis)
        {
            axis.Normalize();
            axis *= Mathf.Sin(angle * Mathf.Deg2Rad * 0.5f);
            return new Quat(axis.x, axis.y, axis.z, Mathf.Cos(angle * Mathf.Deg2Rad * 0.5f));
        }
        /// <summary>
        /// Returns the rotation of the axis vector usign "Deg"
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Quat AxisAngle(Vec3 axis, float angle)
        {
            Quat ret = identity;
            axis.Normalize();
            axis *= (float)Math.Sin((angle / 2) * Mathf.Deg2Rad);
            ret.xq = axis.x;
            ret.yq = axis.y;
            ret.zq = axis.z;
            ret.wq = (float)Math.Cos((angle / 2) * Mathf.Deg2Rad);
            return Normalize(ret);
        }

        /// <summary>
        /// Return a float value equal to the magnitudes of the two quaternions multiplied together
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Dot(Quat a, Quat b)
        {
            return a.xq * b.xq + a.yq * b.yq + a.zq * b.zq + a.wq * b.wq;
        }

        /// <summary>
        /// Creates a rotation which rotates from fromDirection to toDirection.
        /// </summary>
        /// <param name="fromDirection"></param>
        /// <param name="toDirection"></param>
        /// <returns></returns>
        public static Quat FromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            Vec3 axis = Vec3.Cross(fromDirection, toDirection);
            float angle = Vec3.Angle(fromDirection, toDirection);
            return AngleAxis(angle, axis.normalized);
        }

        /// <summary>
        /// Returns the Inverse of rotation.
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public static Quat Inverse(Quat rotation)
        {
            Quat retQ;
            retQ.xq = -rotation.xq;
            retQ.yq = -rotation.yq;
            retQ.zq = -rotation.zq;
            retQ.wq = rotation.wq;
            return retQ;
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
            return new string("Xq Value : " + this.xq + ", Yq Value : " + this.yq + ", Zq Value : " + this.zq + ", Wq Value : " + this.wq);
        }
    }
}
