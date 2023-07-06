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
        
        /// <summary>
        /// Select a index between 0 and 15
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
                    case 0:
                        return col1.x;
                        break;
                    case 1:
                        return col1.y;
                        break;
                    case 2:
                        return col1.z;
                        break;
                    case 3:
                        return col1.w;
                        break;
                    case 4:
                        return col2.x;
                        break;
                    case 5:
                        return col2.y;
                        break;
                    case 6:
                        return col2.z;
                        break;
                    case 7:
                        return col2.w;
                        break;
                    case 8:
                        return col3.x;
                        break;
                    case 9:
                        return col3.y;
                        break;
                    case 10:
                        return col3.z;
                        break;
                    case 11:
                        return col3.w;
                        break;
                    case 12:
                        return col4.x;
                        break;
                    case 13:
                        return col4.y;
                        break;
                    case 14:
                        return col4.z;
                        break;
                    case 15:
                        return col4.w;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                         col1.x = value;
                        break;
                    case 1:
                        col1.y = value;
                        break;
                    case 2:
                        col1.z = value;
                        break;
                    case 3:
                        col1.w = value;
                        break;
                    case 4:
                        col2.x = value;
                        break;
                    case 5:
                        col2.y = value;
                        break;
                    case 6:
                        col2.z = value;
                        break;
                    case 7:
                        col2.w = value;
                        break;
                    case 8:
                        col3.x = value;
                        break;
                    case 9:
                        col3.y = value;
                        break;
                    case 10:
                        col3.z = value;
                        break;
                    case 11:
                        col3.w = value;
                        break;
                    case 12:
                        col4.x = value;
                        break;
                    case 13:
                        col4.y = value;
                        break;
                    case 14:
                        col4.z = value;
                        break;
                    case 15:
                        col4.w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
        }

        public float this[int row, int column]
        {
            get
            {
                return this[row + column * 4];
            }
            set
            {
                this[row + column * 4] = value;
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

        public Quat rotation() => GetRotation();

        private static Quat GetRotation()
        {
            return new Quat(0f, 0f, 0f, 0f);
        }

        public static Matrix Rotate(Quat q)
        {
            return Zero;
        }

        public Vec3 lossyScale() => GetLosszScale();

        private static Vec3 GetLosszScale() { return new Vec3(0f, 0f, 0f); }

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
                    return new Vector4(col1.x, col2.x, col3.x, col4.x);
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