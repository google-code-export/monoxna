#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team
http://www.taoframework.com
All rights reserved.

Authors:
Olivier Dufour (Duff)

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
#endregion License

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Tests;
using System.Threading;
using Microsoft.Xna.Framework.Tests;

namespace Microsoft.Xna.Framework.Graphics.Tests
{
    [TestFixture]
    public class SpriteBatchTests
    {
        TestGame game;
        Thread gameThread;
        SpriteBatch sprite;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            this.game = new TestGame();
            this.gameThread = new Thread(new ThreadStart(game.Run));
            this.gameThread.Start();

            // I need to give the game enough time to initialise before letting the tests continue
            System.Threading.Thread.Sleep(100);
        }

        [TestFixtureTearDown]
        public void TestFixtureTeardown()
        {
            game.Exit();
            gameThread.Join(500);
        }

        [SetUp]
        public void Setup()
        {
            sprite = new SpriteBatch(game.GraphicMgr.GraphicsDevice);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException),"test")]
        public void EndTest()
        {
            sprite.End();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), "test")]
        public void DrawTest()
        {
            sprite.Draw(null, new Rectangle(), Color.White);
        }


        [Test]
        [ExpectedException(typeof(InvalidOperationException), "test")]
        public void BeginTest()
        {
            sprite.Begin();
            sprite.Begin();
        }

    }
}
