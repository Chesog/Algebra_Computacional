using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* https://referencesource.microsoft.com/#System.Numerics/System/Numerics/Matrix4x4.cs */

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

        /// <summary>
        /// Multiply two M4x4 Row by Column (Component to Component)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            Matrix returnM = Zero;

            returnM.col1.x = lhs.col1.x * rhs.col1.x + lhs.col1.y * rhs.col2.x + lhs.col1.z * rhs.col3.x + lhs.col1.w * rhs.col4.x;
            returnM.col1.y = lhs.col1.x * rhs.col1.y + lhs.col1.y * rhs.col2.y + lhs.col1.z * rhs.col3.y + lhs.col1.w * rhs.col4.y;
            returnM.col1.z = lhs.col1.x * rhs.col1.z + lhs.col1.y * rhs.col2.z + lhs.col1.z * rhs.col3.z + lhs.col1.w * rhs.col4.z;
            returnM.col1.w = lhs.col1.x * rhs.col1.w + lhs.col1.y * rhs.col2.w + lhs.col1.z * rhs.col3.w + lhs.col1.w * rhs.col4.w;
            returnM.col2.x = lhs.col2.x * rhs.col1.x + lhs.col2.y * rhs.col2.x + lhs.col2.z * rhs.col3.x + lhs.col2.w * rhs.col4.x;
            returnM.col2.y = lhs.col2.x * rhs.col1.y + lhs.col2.y * rhs.col2.y + lhs.col2.z * rhs.col3.y + lhs.col2.w * rhs.col4.y;
            returnM.col2.z = lhs.col2.x * rhs.col1.z + lhs.col2.y * rhs.col2.z + lhs.col2.z * rhs.col3.z + lhs.col2.w * rhs.col4.z;
            returnM.col2.w = lhs.col2.x * rhs.col1.w + lhs.col2.y * rhs.col2.w + lhs.col2.z * rhs.col3.w + lhs.col2.w * rhs.col4.w;
            returnM.col3.x = lhs.col3.x * rhs.col1.x + lhs.col3.y * rhs.col2.x + lhs.col3.z * rhs.col3.x + lhs.col3.w * rhs.col4.x;
            returnM.col3.y = lhs.col3.x * rhs.col1.y + lhs.col3.y * rhs.col2.y + lhs.col3.z * rhs.col3.y + lhs.col3.w * rhs.col4.y;
            returnM.col3.z = lhs.col3.x * rhs.col1.z + lhs.col3.y * rhs.col2.z + lhs.col3.z * rhs.col3.z + lhs.col3.w * rhs.col4.z;
            returnM.col3.w = lhs.col3.x * rhs.col1.w + lhs.col3.y * rhs.col2.w + lhs.col3.z * rhs.col3.w + lhs.col3.w * rhs.col4.w;
            returnM.col4.x = lhs.col4.x * rhs.col1.x + lhs.col4.y * rhs.col2.x + lhs.col4.z * rhs.col3.x + lhs.col4.w * rhs.col4.x;
            returnM.col4.y = lhs.col4.x * rhs.col1.y + lhs.col4.y * rhs.col2.y + lhs.col4.z * rhs.col3.y + lhs.col4.w * rhs.col4.y;
            returnM.col4.z = lhs.col4.x * rhs.col1.z + lhs.col4.y * rhs.col2.z + lhs.col4.z * rhs.col3.z + lhs.col4.w * rhs.col4.z;
            returnM.col4.w = lhs.col4.x * rhs.col1.w + lhs.col4.y * rhs.col2.w + lhs.col4.z * rhs.col3.w + lhs.col4.w * rhs.col4.w;

            return returnM;
        }

        /// <summary>
        /// multiply an M4x4 by an M1x4
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector4 operator *(Matrix lhs, Vector4 vector)
        {
            Vector4 returnV = Vector4.zero;

            returnV.x = lhs.col1.x * vector.x + lhs.col2.x * vector.y + lhs.col3.x * vector.z + lhs.col4.x * vector.w;
            returnV.y = lhs.col1.y * vector.x + lhs.col2.y * vector.y + lhs.col3.y * vector.z + lhs.col4.y * vector.w;
            returnV.z = lhs.col1.z * vector.x + lhs.col2.z * vector.y + lhs.col3.z * vector.z + lhs.col4.z * vector.w;
            returnV.w = lhs.col1.w * vector.x + lhs.col2.w * vector.y + lhs.col3.w * vector.z + lhs.col4.w * vector.w;

            return returnV;
        }
        #endregion

        public Quat rotation() => GetRotation();

        /// <summary>
        /// Get The matrix rotation o
        /// </summary>
        /// <returns></returns>
        private Quat GetRotation()
        {
            Matrix matr = this;
            Quat returnQ = new Quat();

            returnQ.wq = Mathf.Sqrt(Mathf.Max(0, 1 + matr[0, 0] + matr[1, 1] + matr[2, 2])) / 2;
            returnQ.xq = Mathf.Sqrt(Mathf.Max(0, 1 + matr[0, 0] - matr[1, 1] - matr[2, 2])) / 2;
            returnQ.yq = Mathf.Sqrt(Mathf.Max(0, 1 - matr[0, 0] + matr[1, 1] - matr[2, 2])) / 2;
            returnQ.zq = Mathf.Sqrt(Mathf.Max(0, 1 - matr[0, 0] - matr[1, 1] + matr[2, 2])) / 2;
            returnQ.xq *= Mathf.Sign(returnQ.xq * (matr[2, 1] - matr[1, 2]));
            returnQ.yq *= Mathf.Sign(returnQ.yq * (matr[0, 2] - matr[2, 0]));
            returnQ.zq *= Mathf.Sign(returnQ.zq * (matr[1, 0] - matr[0, 1]));

            return returnQ;
        }

        public static Matrix Rotate(Quat q)
        {
            float x = q.xq * 2f;
            float y = q.yq * 2f;
            float z = q.zq * 2f;
            float x2 = q.xq * x;
            float y2 = q.yq * y;
            float z2 = q.zq * z;
            float xy = q.xq * y;
            float xz = q.xq * z;
            float yz = q.yq * z;
            float wx = q.wq * x;
            float wy = q.wq * y;
            float wz = q.wq * z;

            Matrix resultM = Zero;

            resultM.col1.x = 1f - (y2 + z2);
            resultM.col1.y = xy + wz;
            resultM.col1.z = xz - wy;
            resultM.col1.w = 0f;
            resultM.col2.x = xy - wz;
            resultM.col2.y = 1f - (x2 + z2);
            resultM.col2.z = yz + wx;
            resultM.col2.w = 0f;
            resultM.col3.x = xz + wy;
            resultM.col3.y = yz - wx;
            resultM.col3.z = 1f - (x2 + y2);
            resultM.col3.w = 0f;
            resultM.col4.x = 0f;
            resultM.col4.y = 0f;
            resultM.col4.z = 0f;
            resultM.col4.w = 1f;

            return resultM;
        }

        /// <summary>
        /// Attempts to get a scale value from the matrix. (Read Only)
        /// Scale can only be represented correctly by a 3x3 matrix instead of a 3 component vector, if the given matrix has been skewed for example. lossyScale 
        /// is a convenience property which attempts to match the scale from the matrix as much as possible. If the given matrix is orthogonal, the value will be correct.
        /// </summary>
        /// <returns></returns>
        public Vec3 lossyScale() => GetLosszScale();

        /// <summary>
        /// Attempts to get a scale value from the matrix. (Read Only)
        /// Scale can only be represented correctly by a 3x3 matrix instead of a 3 component vector, if the given matrix has been skewed for example. lossyScale 
        /// is a convenience property which attempts to match the scale from the matrix as much as possible. If the given matrix is orthogonal, the value will be correct.
        /// </summary>
        /// <returns></returns>
        private Vec3 GetLosszScale()
        {
            return new Vec3(GetColumn(1).magnitude, GetColumn(2).magnitude, GetColumn(3).magnitude);
        }

        /// <summary>
        /// Returns whether the matrix is the identity matrix.
        /// </summary>
        private bool isIdentity()
        {
            return col1.x == 1f && col2.y == 1f && col3.z == 1f && col4.w == 1f
                && col1.y == 0f && col2.x == 0f && col3.y == 0f && col4.y == 0f
                && col1.z == 0f && col2.z == 0f && col3.x == 0f && col4.z == 0f
                && col1.w == 0f && col2.w == 0f && col3.w == 0f && col4.x == 0f;
        }

        /// <summary>
        ///  the determinant is a scalar value that is a function of the entries of a square matrix.
        /// </summary>
        public float determinant => Determinant(this);
        /// <summary>
        ///  the determinant is a scalar value that is a function of the entries of a square matrix.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static float Determinant(Matrix m)
        {
            return
                m[0, 3] * m[1, 2] * m[2, 1] * m[3, 0] - m[0, 2] * m[1, 3] * m[2, 1] * m[3, 0] -
                m[0, 3] * m[1, 1] * m[2, 2] * m[3, 0] + m[0, 1] * m[1, 3] * m[2, 2] * m[3, 0] +
                m[0, 2] * m[1, 1] * m[2, 3] * m[3, 0] - m[0, 1] * m[1, 2] * m[2, 3] * m[3, 0] -
                m[0, 3] * m[1, 2] * m[2, 0] * m[3, 1] + m[0, 2] * m[1, 3] * m[2, 0] * m[3, 1] +
                m[0, 3] * m[1, 0] * m[2, 2] * m[3, 1] - m[0, 0] * m[1, 3] * m[2, 2] * m[3, 1] -
                m[0, 2] * m[1, 0] * m[2, 3] * m[3, 1] + m[0, 0] * m[1, 2] * m[2, 3] * m[3, 1] +
                m[0, 3] * m[1, 1] * m[2, 0] * m[3, 2] - m[0, 1] * m[1, 3] * m[2, 0] * m[3, 2] -
                m[0, 3] * m[1, 0] * m[2, 1] * m[3, 2] + m[0, 0] * m[1, 3] * m[2, 1] * m[3, 2] +
                m[0, 1] * m[1, 0] * m[2, 3] * m[3, 2] - m[0, 0] * m[1, 1] * m[2, 3] * m[3, 2] -
                m[0, 2] * m[1, 1] * m[2, 0] * m[3, 3] + m[0, 1] * m[1, 2] * m[2, 0] * m[3, 3] +
                m[0, 2] * m[1, 0] * m[2, 1] * m[3, 3] - m[0, 0] * m[1, 2] * m[2, 1] * m[3, 3] -
                m[0, 1] * m[1, 0] * m[2, 2] * m[3, 3] + m[0, 0] * m[1, 1] * m[2, 2] * m[3, 3];
        }


        /// <summary>
        /// Returns the transpose of this matrix (Read Only).
        /// The transposed matrix is the one that has the Matrix4x4's columns exchanged with its rows.
        /// </summary>
        /// <returns></returns>
        public Matrix transpose => Transpose(this);

        /// <summary>
        /// Returns the transpose of this matrix (Read Only).
        /// The transposed matrix is the one that has the Matrix4x4's columns exchanged with its rows.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private Matrix Transpose(Matrix m)
        {
            float aux;

            aux = m.col2.x;
            m.col2.x = m.col1.y;
            m.col1.y = aux;

            aux = m.col3.x;
            m.col3.x = m.col1.z;
            m.col1.z = aux;

            aux = m.col4.x;
            m.col4.x = m.col1.w;
            m.col1.w = aux;

            aux = m.col3.y;
            m.col3.y = m.col2.z;
            m.col2.z = aux;

            aux = m.col4.y;
            m.col4.y = m.col1.w;
            m.col1.w = aux;

            aux = m.col4.z;
            m.col4.z = m.col3.z;
            m.col3.z = aux;

            return m;
        }

        public Matrix inverse => Inverse(this);
        /// <summary>
        /// The inverse of this matrix. (Read Only)
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private Matrix Inverse(Matrix m)
        {
            return m;
        }

        /// <summary>
        /// Creates a scaling matrix.
        /// Returned matrix is such that scales along coordinate axes by a vector v.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Matrix Scale(Vec3 vector)
        {
            Matrix retMat;

            retMat.col1.x = vector.x;
            retMat.col1.y = 0.0f;
            retMat.col1.z = 0.0f;
            retMat.col1.w = 0.0f;
            retMat.col2.x = 0.0f;
            retMat.col2.y = vector.y;
            retMat.col2.z = 0.0f;
            retMat.col2.w = 0.0f;
            retMat.col3.x = 0.0f;
            retMat.col3.y = 0.0f;
            retMat.col3.z = vector.z;
            retMat.col3.w = 0.0f;
            retMat.col4.x = 0.0f;
            retMat.col4.y = 0.0f;
            retMat.col4.z = 0.0f;
            retMat.col4.w = 1f;

            return retMat;
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Matrix Translate(Vec3 vector)
        {
            Matrix result = Zero;

            result.col1.x = 1f;
            result.col1.y = 0f;
            result.col1.z = 0f;
            result.col1.w = vector.x;
            result.col2.x = 0f;
            result.col2.y = 1f;
            result.col2.z = 0f;
            result.col2.w = vector.y;
            result.col3.x = 0f;
            result.col3.y = 0f;
            result.col3.z = 1f;
            result.col3.w = vector.z;
            result.col4.x = 0f;
            result.col4.y = 0f;
            result.col4.z = 0f;
            result.col4.w = 1f;

            return result;
        }

        /// <summary>
        /// Creates a translation, rotation and scaling matrix.
        /// The returned matrix is such that it places objects at position pos, oriented in rotation q and scaled by s.
        /// </summary>
        /// <param name="translation"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Matrix TRS(Vec3 translation, Quat rotation, Vec3 scale)
        {
            Matrix t = Translate(translation);
            Matrix r = Rotate(rotation);
            Matrix s = Scale(scale);

            return t * r * s;
        }

        /// <summary>
        /// Set the TRS Matrix
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="q"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public void SetTRS(Vec3 pos, Quat q, Vec3 s)
        {
            this = TRS(pos, q, s);
        }

        public bool ValidTRS()
        {
            return false;
        }

        /// <summary>
        /// Returns the specified column (From 0 to 3)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector4 GetColumn(int index)
        {
            switch (index)
            {
                case 0:
                    return col1;
                case 1:
                    return col2;
                case 2:
                    return col3;
                case 3:
                    return col4;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public void SetColumn(int index, Vector4 column)
        {
            this[0, index] = column.x;
            this[1, index] = column.y;
            this[2, index] = column.z;
            this[3, index] = column.w;
        }


        /// <summary>
        ///  Returns the specified row (From 0 to 3)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Vector4 GetRow(int index)
        {
            switch (index)
            {
                case 0:
                    return new Vector4(col1.x, col2.x, col3.x, col4.x);
                case 1:
                    return new Vector4(col1.y, col2.y, col3.y, col4.y);
                case 2:
                    return new Vector4(col1.z, col2.z, col3.z, col4.z);
                case 3:
                    return new Vector4(col1.w, col2.w, col3.w, col4.w);
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        public void SetRow(int index, Vector4 row)
        {
            this[index, 0] = row.x;
            this[index, 1] = row.y;
            this[index, 2] = row.z;
            this[index, 3] = row.w;
        }

        /// <summary>
        /// Transforms a position by this matrix (generic).
        /// Returns a position v transformed by the current fully arbitrary matrix. If the matrix is a regular 3D transformation matrix, it is much faster to use 
        /// MultiplyPoint3x4 instead. MultiplyPoint is slower, but can handle projective transformations as well.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vec3 MultiplyPoint(Vec3 point)
        {
            Vec3 retVec;

            retVec.x = (float)((double)col1.x * (double)point.x + (double)col2.x * (double)point.y + (double)col3.x * (double)point.z) + col4.x;
            retVec.y = (float)((double)col1.y * (double)point.x + (double)col2.y * (double)point.y + (double)col3.y * (double)point.z) + col4.y;
            retVec.z = (float)((double)col1.z * (double)point.x + (double)col2.z * (double)point.y + (double)col3.z * (double)point.z) + col4.z;

            float num = 1f / ((float)((double)col1.w * (double)point.x + (double)col2.w * (double)point.y + (double)col3.w * (double)point.z) + col4.w);
            retVec.x *= num;
            retVec.y *= num;
            retVec.z *= num;

            return retVec;
        }
        /// <summary>
        /// Transforms a position by this matrix (fast).
        /// Returns a position v transformed by the current transformation matrix. This function is a faster version of MultiplyPoint; but it can only handle regular 3D
        /// transformations. MultiplyPoint is slower, but can handle projective transformations as well.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vec3 MultiplyPoint3x4(Vec3 point)
        {
            Vec3 retVec;

            retVec.x = (float)((double)col1.x * (double)point.x + (double)col2.x * (double)point.y + (double)col3.x * (double)point.z) + col4.x;
            retVec.y = (float)((double)col1.y * (double)point.x + (double)col2.y * (double)point.y + (double)col3.y * (double)point.z) + col4.y;
            retVec.z = (float)((double)col1.z * (double)point.x + (double)col2.z * (double)point.y + (double)col3.z * (double)point.z) + col4.z;

            return retVec;
        }
        /// <summary>
        /// Transforms a direction by this matrix.
        /// This function is similar to MultiplyPoint; but it transforms directions and not positions. When transforming a direction, only the rotation part of the matrix 
        /// is taken into account.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Vec3 MultiplyVector(Vec3 vector)
        {
            Vec3 retVec;

            retVec.x = (float)((double)col1.x * (double)vector.x + (double)col2.x * (double)vector.y + (double)col3.x * (double)vector.z);
            retVec.z = (float)((double)col1.z * (double)vector.x + (double)col2.z * (double)vector.y + (double)col3.z * (double)vector.z);
            retVec.y = (float)((double)col1.y * (double)vector.x + (double)col2.y * (double)vector.y + (double)col3.y * (double)vector.z);

            return retVec;
        }
        public Vec3 GetPosition()
        {
            return Vec3.Zero;
        }
    }
}