#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team
http://www.taoframework.com
All rights reserved.

Authors: Alan McGovern
 * Isaac Llopis (neozack@gmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework;
using System.Globalization;


namespace Microsoft.Xna.Framework.Tests
{
    [TestFixture]
    public class Vector3Tests
    {
        #region Setup

        Vector3 a;
        Vector3 b;
        Vector3 c;

        [SetUp]
        public void Setup()
        {
            a = new Vector3(1, 2, 3);
            b = new Vector3(4.5f, 6f, 7f);
            c = new Vector3(-124, 352.234f, 123.123f);
        }

        #endregion

        #region Public Fields Test

        [Test]
        public void XComponent()
        {
            Assert.AreEqual(1, a.X, "XComponent#1");
            Assert.AreEqual(4.5f, b.X, "XComponent#2");
            Assert.AreEqual(-124, c.X, "XComponent#3");
        }

        [Test]
        public void YComponent()
        {
            Assert.AreEqual(2, a.Y, "YComponent#1");
            Assert.AreEqual(6f, b.Y, "YComponent#2");
            Assert.AreEqual(352.234f, c.Y, "YComponent#3");
        }

        [Test]
        public void ZComponent()
        {
            Assert.AreEqual(3, a.Z, "ZComponent#1");
            Assert.AreEqual(7f, b.Z, "ZComponent#2");
            Assert.AreEqual(123.123f, c.Z, "ZComponent#3");
        }

        #endregion

        #region Public Properties Tests

        [Test]
        public void StaticDirections()
        {
            // Static property Backward
            Vector3 v = Vector3.Backward;
            Assert.AreEqual(0, v.X, "Backward#X");
            Assert.AreEqual(0, v.Y, "Backward#Y");
            Assert.AreEqual(1, v.Z, "Backward#Z");

            // Static property Down()
            v = Vector3.Down;
            Assert.AreEqual(0, v.X, "Down#X");
            Assert.AreEqual(-1, v.Y, "Down#Y");
            Assert.AreEqual(0, v.Z, "Down#Z");

            // Static property Forward
            v = Vector3.Forward;
            Assert.AreEqual(0, v.X, "Forward#X");
            Assert.AreEqual(0, v.Y, "Forward#Y");
            Assert.AreEqual(-1, v.Z, "Forward#Z");

            // Static property Left
            v = Vector3.Left;
            Assert.AreEqual(-1, v.X, "Left#X");
            Assert.AreEqual(0, v.Y, "Left#Y");
            Assert.AreEqual(0, v.Z, "Left#Z");

            // Static property Right
            v = Vector3.Right;
            Assert.AreEqual(1, v.X, "Right#X");
            Assert.AreEqual(0, v.Y, "Right#Y");
            Assert.AreEqual(0, v.Z, "Right#Z");

            // Static property Up
            v = Vector3.Up;
            Assert.AreEqual(0, v.X, "Up#X");
            Assert.AreEqual(1, v.Y, "Up#Y");
            Assert.AreEqual(0, v.Z, "Up#Z");
        }

        [Test]
        public void StaticUnit()
        {
            // Static property UnitX
            Vector3 v = Vector3.UnitX;
            Assert.AreEqual(1, v.X, "UnitX#X");
            Assert.AreEqual(0, v.Y, "UnitX#Y");
            Assert.AreEqual(0, v.Z, "UnitX#Z");

            // Static property UnitY
            v = Vector3.UnitY;
            Assert.AreEqual(0, v.X, "UnitY#X");
            Assert.AreEqual(1, v.Y, "UnitY#Y");
            Assert.AreEqual(0, v.Z, "UnitY#Z");

            // Static property UnitZ
            v = Vector3.UnitZ;
            Assert.AreEqual(0, v.X, "UnitZ#X");
            Assert.AreEqual(0, v.Y, "UnitZ#Y");
            Assert.AreEqual(1, v.Z, "UnitZ#Z");

            // Static property One
            v = Vector3.One;
            Assert.AreEqual(1, v.X, "One#X");
            Assert.AreEqual(1, v.Y, "One#Y");
            Assert.AreEqual(1, v.Z, "One#Z");

            // Static property Zero
            v = Vector3.Zero;
            Assert.AreEqual(0, v.X, "Zero#X");
            Assert.AreEqual(0, v.Y, "Zero#Y");
            Assert.AreEqual(0, v.Z, "Zero#Z");
        }

        #endregion

        #region Public Methods Test

        [Test]
        public void Constructors()
        {
            // Default constructor
            Vector3 v = new Vector3();
            Assert.AreEqual(0, v.X, "Constructor#1.X");
            Assert.AreEqual(0, v.Y, "Constructor#1.Y");
            Assert.AreEqual(0, v.Z, "Constructor#1.Z");

            // Overloaded constructor, argument float
            v = new Vector3(1.2f);
            Assert.AreEqual(1.2f, v.X, "Constructor#2.X");
            Assert.AreEqual(1.2f, v.Y, "Constructor#2.Y");
            Assert.AreEqual(1.2f, v.Z, "Constructor#2.Z");

            // Overloaded constructor, three coordinates float
            v = new Vector3(1.2f, 2.2f, 3.2f);
            Assert.AreEqual(1.2f, v.X, "Constructor#3.X");
            Assert.AreEqual(2.2f, v.Y, "Constructor#3.Y");
            Assert.AreEqual(3.2f, v.Z, "Constructor#3.Z");

            // Overloaded constructor, some arguments integer
            v = new Vector3(1);
            Assert.AreEqual(1, v.X, "Constructor#4.X");
            Assert.AreEqual(1, v.Y, "Constructor#4.Y");
            Assert.AreEqual(1, v.Z, "Constructor#4.Z");

            v = new Vector3(1f, 2, 3f);
            Assert.AreEqual(1f, v.X, "Constructor#5.X");
            Assert.AreEqual(2f, v.Y, "Constructor#5.Y");
            Assert.AreEqual(3f, v.Z, "Constructor#5.Z");

            // Overloaded constructor, a Vector2 and a float
            v = new Vector3(new Vector2(2.0f, -3.5f), 4.0f);
            Assert.AreEqual(2.0f, v.X, "Constructor#6.X");
            Assert.AreEqual(-3.5f, v.Y, "Constructor#6.Y");
            Assert.AreEqual(4.0f, v.Z, "Constructor#6.Z");
        }

        [Test]
        public void Add()
        {
            // Normal use
            Vector3 v = Vector3.Add(new Vector3(1, 1, 1), new Vector3(1, 1, 1));
            Assert.AreEqual(2, v.X, "Add#1.X");
            Assert.AreEqual(2, v.Y, "Add#1.Y");
            Assert.AreEqual(2, v.Z, "Add#1.Z");

            // Normal use, negative coordinates
            v = Vector3.Add(new Vector3(-1, -2.4f, -2), new Vector3(-1, -2.4f, -2f));
            Assert.AreEqual(-2, v.X, "Add#2.X");
            Assert.AreEqual(-4.8f, v.Y, "Add#2.Y");
            Assert.AreEqual(-4, v.Z, "Add#2.Z");

            // Tests for the overloaded method
            Vector3 v1 = new Vector3(1, 1, 1);
            Vector3 v2 = new Vector3(-1, -2.4f, -2);
            Vector3 v3 = new Vector3(-1, -2.4f, -2f);

            // Normal use
            Vector3.Add(ref v1, ref v1, out v);
            Assert.AreEqual(2, v.X, "Add#3.X");
            Assert.AreEqual(2, v.Y, "Add#3.Y");
            Assert.AreEqual(2, v.Z, "Add#3.Z");

            // Normal use, negative coordinates
            Vector3.Add(ref v2, ref v3, out v);
            Assert.AreEqual(-2, v.X, "Add#4.X");
            Assert.AreEqual(-4.8f, v.Y, "Add#4.Y");
            Assert.AreEqual(-4, v.Z, "Add#4.Z");
        }

        [Test]
        public void Barycentric()
        {
            a = Vector3.UnitX;
            b = Vector3.UnitY;
            c = Vector3.UnitZ;

            // Typical barycentric usage
            Vector3 v = Vector3.Barycentric(a, b, c, 1, 0.5f);
            Assert.AreEqual(-0.5f, v.X, "Barycentric#1.X");
            Assert.AreEqual(1, v.Y, "Barycentric#1.Y");
            Assert.AreEqual(0.5f, v.Z, "Barycentric#1.Z");

            // Overloaded barycentric usage
            Vector3.Barycentric(ref a, ref b, ref c, 1, 0.5f, out v);
            Assert.AreEqual(-0.5f, v.X, "Barycentric#2.X");
            Assert.AreEqual(1, v.Y, "Barycentric#2.Y");
            Assert.AreEqual(0.5f, v.Z, "Barycentric#2.Z");
        }

        [Test]
        public void CatmullRom()
        {
            // Tests with positive vectors

            Vector3 v1 = new Vector3(0, 0, 0);
            Vector3 v2 = new Vector3(1, 1, 1);
            Vector3 v3 = new Vector3(2, 2, 2);
            Vector3 v4 = new Vector3(3, 3, 3);

            a = Vector3.CatmullRom(v1, v2, v3, v4, 0);
            Assert.AreEqual(new Vector3(1, 1, 1), a, "CatmullRom#1");

            a = Vector3.CatmullRom(v4, v3, v2, v1, 0);
            Assert.AreEqual(new Vector3(2, 2, 2), a, "CatmullRom#2");

            a = Vector3.CatmullRom(v1, v2, v3, v4, 0.5f);
            Assert.AreEqual(new Vector3(1.5f, 1.5f, 1.5f), a, "CatmullRom#3");

            a = Vector3.CatmullRom(v4, v4, v4, v4, 0.25f);
            Assert.AreEqual(new Vector3(3, 3, 3), a, "CatmullRom#4");

            a = Vector3.CatmullRom(v3, v2, v1, v4, 0.25f);
            Assert.AreEqual(new Vector3(0.65625f, 0.65625f, 0.65625f), a, "CatmullRom#5");

            // Tests with negative vectors

            v1 = new Vector3(0, 0, 0);
            v2 = new Vector3(-1, -2, -3);
            v3 = new Vector3(-4, -4, -4);
            v4 = new Vector3(-4, -5, 6);

            a = Vector3.CatmullRom(v1, v2, v3, v4, 0);
            Assert.AreEqual(new Vector3(-1, -2, -3), a, "CatmullRom#6");

            a = Vector3.CatmullRom(v4, v3, v2, v1, 0);
            Assert.AreEqual(new Vector3(-4, -4, -4), a, "CatmullRom#7");

            a = Vector3.CatmullRom(v1, v2, v3, v4, -0.5f);
            Assert.AreEqual(new Vector3(-1.1875f, -1.1875f, -3.4375f), a, "CatmullRom#8");

            a = Vector3.CatmullRom(v4, v4, v4, v4, -0.25f);
            Assert.AreEqual(new Vector3(-4, -5, 6), a, "CatmullRom#9");

            // This check is made with ToString to avoid non-important-bits
            // If anyone knows a better way, change it
            a = Vector3.CatmullRom(v3, v2, v1, v4, 0.25f);
            Assert.AreEqual(new Vector3(-0.4921875f, -1.335938f, -2.460938f).ToString(), a.ToString(), "CatmullRom#10");
        }

        [Test]
        public void Clamp()
        {
            Vector3 min = new Vector3(-10, -10, -10);
            Vector3 max = new Vector3(10, 10, 10);
            
            // Test normal use with min vector first ant max vector last
            Assert.AreEqual(new Vector3(1, 1, 1), Vector3.Clamp(new Vector3(1, 1, 1), min, max), "Clamp#1");
            Assert.AreEqual(new Vector3(-10, -10, -10), Vector3.Clamp(new Vector3(-10, -10, -10), min, max), "Clamp#2");
            Assert.AreEqual(new Vector3(-10, -5, -10), Vector3.Clamp(new Vector3(-20, -5, -15), min, max), "Clamp#3");
            Assert.AreEqual(new Vector3(-10, 0, 10), Vector3.Clamp(new Vector3(-15, 0 ,15), min, max), "Clamp#4");
            Assert.AreEqual(new Vector3(10, 10, 10), Vector3.Clamp(new Vector3(20, 20, 20), min, max), "Clamp#5");

            // Test wicked use with max first and min last
            Assert.AreEqual(new Vector3(10, 10, 10), Vector3.Clamp(new Vector3(1, 1, 1), max, min), "Clamp#6");
            Assert.AreEqual(new Vector3(10, 10, 10), Vector3.Clamp(new Vector3(-10, -10, -10), max, min), "Clamp#7");
            Assert.AreEqual(new Vector3(10, 10, 10), Vector3.Clamp(new Vector3(-20, -5, -15), max, min), "Clamp#8");
            Assert.AreEqual(new Vector3(10, 10, 10), Vector3.Clamp(new Vector3(-15, 0, 15), max, min), "Clamp#9");
            Assert.AreEqual(new Vector3(10, 10, 10), Vector3.Clamp(new Vector3(15, 15, 15), max, min), "Clamp#10");
        }

        [Test]
        public void Cross()
        {
            Vector3 v1 = new Vector3(5, 1, 9);
            Vector3 v2 = new Vector3(-5, -1, -9);
            Vector3 v3 = new Vector3(0, 0, 0);
            Vector3 v4 = new Vector3(1, 1, 1);
            Vector3 v5 = new Vector3(-1.5f, 0.6f, 33.5f);

            Assert.AreEqual(new Vector3(), Vector3.Cross(v1, v2), "Cross#1");
            Assert.AreEqual(new Vector3(), Vector3.Cross(v1, v1), "Cross#2");
            Assert.AreEqual(new Vector3(), Vector3.Cross(v2, v1), "Cross#3");
            Assert.AreEqual(new Vector3(), Vector3.Cross(v2, v2), "Cross#4");
            Assert.AreEqual(new Vector3(), Vector3.Cross(v3, v2), "Cross#5");
            Assert.AreEqual(new Vector3(32.9f, -35, 2.1f), Vector3.Cross(v4, v5), "Cross#6");
            Assert.AreEqual(new Vector3(-32.9f, 35, -2.1f), Vector3.Cross(v5, v4), "Cross#7");
            Assert.AreEqual(new Vector3(), Vector3.Cross(v5, v5), "Cross#8");
        }

        [Test]
        public void Distance()
        {
            Vector3 origin = new Vector3(0, 0, 0);

            // Origin as source vector
            Assert.AreEqual(1, Vector3.Distance(Vector3.UnitX, origin), "Distance#1");
            Assert.AreEqual(1, Vector3.Distance(Vector3.UnitY, origin), "Distance#2");
            Assert.AreEqual(1, Vector3.Distance(Vector3.UnitZ, origin), "Distance#3");

            Assert.AreEqual(1.73205078f, Vector3.Distance(Vector3.One, origin), "Distance#4");
            Assert.AreEqual(0, Vector3.Distance(origin, origin), "Distance#5");

            // Origin as destination vector
            Assert.AreEqual(1, Vector3.Distance(origin, Vector3.UnitX), "Distance#6");
            Assert.AreEqual(1, Vector3.Distance(origin, Vector3.UnitY), "Distance#7");
            Assert.AreEqual(1, Vector3.Distance(origin, Vector3.UnitZ), "Distance#8");

            Assert.AreEqual(1.73205078f, Vector3.Distance(origin, Vector3.One), "Distance#9");
            Assert.AreEqual(0, Vector3.Distance(origin, origin), "Distance#10");
        }

        [Test]
        public void DistanceSquared()
        {
            Vector3 origin = new Vector3(0, 0, 0);
            Vector3 v1 = new Vector3(2, 2, 2);
            Vector3 v2 = new Vector3(-2, -2, -2);
            Vector3 v3 = new Vector3(4, -3, 5.5f);

            Assert.AreEqual(12, Vector3.DistanceSquared(v1, origin), "DistanceSquared#1");
            Assert.AreEqual(12, Vector3.DistanceSquared(v2, origin), "DistanceSquared#2");
            Assert.AreEqual(55.25f, Vector3.DistanceSquared(v3, origin), "DistanceSquared#3");

            Assert.AreEqual(Vector3.DistanceSquared(v1, origin),
                Vector3.DistanceSquared(v2, origin), "DistanceSquared#4");
            Assert.AreEqual(Vector3.DistanceSquared(v3, origin),
                Vector3.DistanceSquared(origin, v3), "DistanceSquared#5");

            Assert.AreEqual(12, Vector3.DistanceSquared(origin, v1), "DistanceSquared#6");
            Assert.AreEqual(12, Vector3.DistanceSquared(origin, v2), "DistanceSquared#7");
            Assert.AreEqual(55.25f, Vector3.DistanceSquared(origin, v3), "DistanceSquared#8");

            Assert.AreEqual(3, Vector3.DistanceSquared(origin, Vector3.One), "DistanceSquared#9");
            Assert.AreEqual(0, Vector3.DistanceSquared(v3, v3), "DistanceSquared#10");
        }

        [Test]
        public void DivideByScalar()
        {
            // Normal tests

            Assert.AreEqual(new Vector3(1, 1, 1), Vector3.Divide(new Vector3(2, 2, 2), 2), "DivideByScalar#1");
            Assert.AreEqual(new Vector3(0, 0, 0), Vector3.Divide(new Vector3(0, 0, 0), 2), "DivideByScalar#2");
            Assert.AreEqual(new Vector3(1.5f, 2.5f, -3.5f), Vector3.Divide(new Vector3(-3, -5, 7), -2), "DivideByScalar#3");

            // Test divide by zero

            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, float.NaN).ToString(),
                            Vector3.Divide(new Vector3(0, 0, 0), 0).ToString(),
                            "DivideByScalarZero#1");
            Assert.AreEqual(new Vector3(float.PositiveInfinity, float.NegativeInfinity, float.PositiveInfinity),
                            Vector3.Divide(new Vector3(1, -1, 500), 0),
                            "DivideByScalarZero#2");
            Assert.AreEqual(new Vector3(float.PositiveInfinity, float.NegativeInfinity, float.PositiveInfinity),
                            Vector3.Divide(new Vector3(float.PositiveInfinity,
                                                       float.NegativeInfinity,
                                                       float.PositiveInfinity), 0),
                            "DivideByScalarZero#3");
            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, float.NaN).ToString(),
                            Vector3.Divide(new Vector3(float.NaN, float.NaN, 0), 0).ToString(),
                            "DivideByScalarZero#4");

            // Test divide by NaN

            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, float.NaN).ToString(),
                            Vector3.Divide(new Vector3(), float.NaN).ToString(),
                            "DivideByScalarNan#1");
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, float.NaN).ToString(),
                            Vector3.Divide(new Vector3(1, 2, -3), float.NaN).ToString(),
                            "DivideByScalarNan#2");

            // Test divide by NegativeInfinity

            Assert.AreEqual(new Vector3(),
                            Vector3.Divide(new Vector3(), float.NegativeInfinity),
                            "DivideByScalarNegativeInfinity#1");
            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, 0).ToString(),
                            Vector3.Divide(new Vector3(float.NegativeInfinity, float.PositiveInfinity, 0),
                                           float.NegativeInfinity).ToString(),
                            "DivideByScalarNegativeInfinity#2");

            // Test divide by PositiveInfinity

            Assert.AreEqual(new Vector3(),
                            Vector3.Divide(new Vector3(), float.PositiveInfinity),
                            "DivideByScalarPositiveInfinity#1");
            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, 0).ToString(),
                            Vector3.Divide(new Vector3(float.NegativeInfinity, float.PositiveInfinity, 0),
                                           float.PositiveInfinity).ToString(),
                            "DivideByScalarPositiveInfinity#2");
        }

        [Test]
        public void DivideByVector()
        {
            Assert.AreEqual(new Vector3(1, 2, -0.5f),
                            Vector3.Divide(new Vector3(2, 2, 2),
                                           new Vector3(2, 1, -4)),
                            "DivideByVector#1");

            Assert.AreEqual(new Vector3(0, 0, 0),
                            Vector3.Divide(new Vector3(0, 0, 0),
                                           new Vector3(1, 20, -30)),
                            "DivideByVector#2");

            Assert.AreEqual(new Vector3(1.5f, 2.5f, -3.5f),
                            Vector3.Divide(new Vector3(-9, 10, 7),
                                           new Vector3(-6, 4, -2)),
                            "DivideByVector#3");

            // Test divide by zero

            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, float.NaN).ToString(),
                            Vector3.Divide(new Vector3(0, 0, 0),
                                           new Vector3(0, 0, 0)).ToString(),
                            "DivideByVectorZero#1");
            Assert.AreEqual(new Vector3(float.PositiveInfinity, float.NegativeInfinity, float.PositiveInfinity),
                            Vector3.Divide(new Vector3(1, -1, 500),
                                           new Vector3(0, 0, 0)),
                            "DivideByVectorZero#2");
            Assert.AreEqual(new Vector3(float.PositiveInfinity, float.NegativeInfinity, float.PositiveInfinity),
                            Vector3.Divide(new Vector3(float.PositiveInfinity,
                                                       float.NegativeInfinity,
                                                       float.PositiveInfinity),
                                           new Vector3(0, 0, 0)),
                            "DivideByVectorZero#3");
            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, float.NaN).ToString(),
                            Vector3.Divide(new Vector3(float.NaN, float.NaN, 0),
                                           new Vector3(0, 0, 0)).ToString(),
                            "DivideByVectorZero#4");

            // Test divide by NaN

            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, float.NaN).ToString(),
                            Vector3.Divide(new Vector3(),
                                           new Vector3(float.NaN, float.NaN, float.NaN)).ToString(),
                            "DivideByVectorNan#1");
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, float.NaN).ToString(),
                            Vector3.Divide(new Vector3(1, 2, -3),
                                           new Vector3(float.NaN, float.NaN, float.NaN)).ToString(),
                            "DivideByVectorNan#2");

            // Test divide by NegativeInfinity

            Assert.AreEqual(new Vector3(),
                            Vector3.Divide(new Vector3(),
                                           new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity)),
                            "DivideByVectorNegativeInfinity#1");
            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, 0).ToString(),
                            Vector3.Divide(new Vector3(float.NegativeInfinity,
                                                       float.PositiveInfinity,
                                                       0),
                                           new Vector3(float.NegativeInfinity,
                                                       float.NegativeInfinity,
                                                       float.NegativeInfinity)).ToString(),
                            "DivideByVectorNegativeInfinity#2");

            // Test divide by PositiveInfinity

            Assert.AreEqual(new Vector3(),
                            Vector3.Divide(new Vector3(),
                                           new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity)),
                            "DivideByVectorPositiveInfinity#1");
            // This test is checked with the ToString Method so that non-important bits are unchecked
            Assert.AreEqual(new Vector3(float.NaN, float.NaN, 0).ToString(),
                            Vector3.Divide(new Vector3(float.NegativeInfinity,
                                                       float.PositiveInfinity,
                                                       0),
                                           new Vector3(float.PositiveInfinity,
                                                       float.PositiveInfinity,
                                                       float.PositiveInfinity)).ToString(),
                            "DivideByVectorPositiveInfinity#2");
        }

        [Test]
        public void ToStringTest()
        {

            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-IE");
            Assert.AreEqual("{X:-124 Y:352.234 Z:123.123}", c.ToString(), "#1");

            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Assert.AreEqual("{X:-124 Y:352,234 Z:123,123}", c.ToString(), "#2");

            Vector3 v = new Vector3(1324.2353252353223f, 1324.2353252353223f, 1324.2353252353223f);
            Assert.AreEqual("{X:1324,235 Y:1324,235 Z:1324,235}", v.ToString(), "#3");
        }

        #endregion
    }
}
