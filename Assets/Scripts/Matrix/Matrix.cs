using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomMath
{
    public struct Matrix
    {
        #region Variables
        public Vector4 col1;
        public Vector4 col2;
        public Vector4 col3;
        public Vector4 col4;
        #endregion
        /*Vector4 operator (Matrix4x4 lhs, Vector4 vector)
Matrix4x4 operator(Matrix4x4 lhs, Matrix4x4 rhs)*/
        #region Constructor
        public Matrix(Vector4 col1, Vector4 col2, Vector4 col3, Vector4 col4)
        {
            this.col1 = col1;
            this.col2 = col2;
            this.col3 = col3;
            this.col4 = col4;
        }
        #endregion

        #region Operators
        private static readonly Matrix Zero = new Matrix(new Vector4(0f, 0f, 0f, 0f), new Vector4(0f, 0f, 0f, 0f), new Vector4(0f, 0f, 0f, 0f), new Vector4(0f, 0f, 0f, 0f));
        private static readonly Matrix Identity = new Matrix(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
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

        public float this[int row, int column]
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }
        public static bool operator ==(Matrix lhs, Matrix rhs)
        {
            return lhs.GetColumn(0) == rhs.GetColumn(0) &&
                   lhs.GetColumn(1) == rhs.GetColumn(1) &&
                   lhs.GetColumn(2) == rhs.GetColumn(2) &&
                   lhs.GetColumn(3) == rhs.GetColumn(3);
        }

        public static bool operator !=(Matrix lhs, Matrix rhs) => !(lhs == rhs);
        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
           return Zero;
        }

        public static Vector4 operator *(Matrix lhs, Vector4 vector)
        {
            return new Vector4(0f, 0f, 0f, 0f);
        }
        #endregion

        public Quat rotation() => Rotation();

        private Quat Rotation()
        {
            return new Quat(0f, 0f, 0f, 0f);
        }

        public static Matrix Rotate(Quat q)
        {
            return Zero;
        }

        public Vec3 LossyScale()
        {
            return new Vec3(0f, 0f, 0f);
        }

        private static bool isIdentity()
        {
            return false;
        }

        public float determinant => Determinant(this);
        private static float Determinant(Matrix m)
        {
            return 0f;
        }


        public Matrix transpose => Transpose(this);
        private static Matrix Transpose(Matrix m)
        {
            return m;
        }

        public Matrix inverse => Inverse(this);
        private static Matrix Inverse(Matrix m)
        {
            return m;
        }

        public static Matrix Scale(Vec3 vector)
        {
            return Zero;
        }

        public static Matrix Translate(Vec3 vector)
        {
            return Zero;
        }

        public static Matrix TRS(Vec3 translation, Quat rotation, Vec3 scale)
        {
            return Zero;
        }

        public static Matrix SetTRS(Vec3 pos, Quat q, Quat s)
        {
            return Zero;

        }

        public bool ValidTRS() 
        {
            return false;
        }

        /// <summary>
        /// Returns the specified column (From 1 to 4)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector4 GetColumn(int index)
        {
            switch (index)
            {
                case 1:
                    return col1;
                    break;
                case 2:
                    return col2;
                    break;
                case 3:
                    return col3;
                    break;
                case 4:
                    return col4;
                    break;
                default:
                    throw new IndexOutOfRangeException();
                    break;
            }
        }

        public void SetColumn(int index, Vector4 column) 
        {

        }


        /// <summary>
        ///  Returns the specified row (From 1 to 4)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Vector4 GetRow(int index)
        {
            switch (index)
            {
                case 1:
                    return new Vector4(col1.x,col2.x,col3.x,col4.x);
                    break;
                case 2:
                    return new Vector4(col1.y, col2.y, col3.y, col4.y);
                    break;
                case 3:
                    return new Vector4(col1.z, col2.z, col3.z, col4.z);
                    break;
                case 4:
                    return new Vector4(col1.w, col2.w, col3.w, col4.w);
                    break;
                default:
                    throw new IndexOutOfRangeException();
                    break;
            }
        }
        public void SetRow(int index, Vector4 row) 
        {

        }
        public Vec3 MultiplyPoint(Vec3 point)
        {
            return Vec3.Zero;
        }

        public Vec3 MultiplyPoint3x4(Vec3 point)
        {
            return Vec3.Zero;
        }

        public Vec3 MultiplyVector(Vec3 vector)
        {
            return Vec3.Zero;
        }

        public Vec3 GetPosition()
        {
            return Vec3.Zero;
        }
    }
}