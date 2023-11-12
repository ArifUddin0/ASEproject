using System;
using System.Drawing;
using ASEproject;
namespace aseTest
{
    [TestClass]
    public class aseTest
    {

        [TestMethod]
        public void Rectangle_Test()
        {
            Pen pen = new Pen(Color.Black, 2);
            MyCanvass canvas = new MyCanvass(500, 500);

            string command = "circle 30";

            MyCommandParser parser = new MyCommandParser(command, pen, canvas);

            List<string> executedCommands = canvas.GetExecutedCommands();

            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }

            Assert.IsTrue(executedCommands.Any(command => command.Contains("MyCircle")));
        }
    }
    
}