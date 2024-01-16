using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment1
{

    public class CommandParser
    {

        int line = 0;


        public void CmdParse(String readparse, String readMultiparse, Drawer myCanvas)
        {
            //Remove previous excuted program if myCanvas get error, provide new execution area 
            if (myCanvas.error)
            {
                myCanvas.Reset();
                myCanvas.error = false;
            }

            //calls method for single line textfield 
            if (readMultiparse.Length.Equals(0))
            {

                SingleLineParse(readparse, myCanvas);   //call Singleparse method
            }

            //calls method for multi-line textfield 
            else if (readparse.Equals("run"))
            {
                MultiLineParse(readMultiparse, myCanvas);  //call Multiparse method
            }
            else
            {
                MultiLineParse(readMultiparse, myCanvas);    //call Multiparse method
            }
        }

        public void SingleLineParse(String readparse, Drawer myCanvas)
        {
            String[] readCmd = readparse.Split(' ');
            ParameterSeperator(readCmd, myCanvas, -1);    //call ParameterSeperator method
        }


        public void MultiLineParse(String readparse, Drawer myCanvas) //MULTI LINE TEXT FIELD METHOD
        {
            String[] value = readparse.Split('\n');  //separating the multi-line input on the basis of /n  | STORES THE BREAKDOWN OF MULTIPLE-LINE CODES
            int num = 0;
            int x = 0;
            try
            {

                while (num < value.Length)
                {
                    String[] readCmd = value[num].Split(' '); //separates code of each line on the basis of space/STORES BREAKDOWN OF SINGLE CODE
                    //if user enter value and while get equal then value will be added in list data
                    if (readCmd[0].Equals("while")) //my code: switch (parse.ToLower())'s one of the cases in Parser.csCHECKS FIRST WORD OF CODE, IF IT IS EQUAL TO WHILE
                    {
                        List<String> listData = new List<String>();
                        do
                        {
                            x++;
                            listData.Add(value[num]); //STORES ENTIRE CODE OF ONE LINE IN listData 
                            num++;   //THEN num GETS INCREMENTED
                            readCmd = value[num].Split(' ');  //SPLITS THAT ONE LINE OF CODE ON THE BASIS OF SPACE AND STORES IN readCmd
                        }
                        while (!readCmd[0].Equals("endwhile"));
                        CmdLoopWhile(listData, myCanvas, num, x);
                    }
                    //when user enter value and if get equal then value will be added in list data
                    else if (readCmd[0].Equals("if"))
                    {
                        List<String> listData = new List<String>();
                        do
                        {
                            x++;
                            listData.Add(value[num]);
                            num++;
                            readCmd = value[num].Split(' ');
                        }
                        while (!readCmd[0].Equals("endif"));
                        CmdConditionIf(listData, myCanvas, num, x);
                    }
                    //if user enter value and loop get equal then value will be added in list data
                    else if (readCmd[0].Equals("loop"))
                    {
                        List<String> listData = new List<String>();
                        do
                        {
                            x++;
                            listData.Add(value[num]);
                            num++;
                            readCmd = value[num].Split(' ');
                        }
                        while (!readCmd[0].Equals("endfor"));
                        CmdLoopFor(listData, myCanvas, num, x);
                    }
                    //if user enter value and method get equal then value will be added in list data
                    else if (readCmd[0].Equals("method"))
                    {
                        List<String> listData = new List<String>();
                        do
                        {
                            x++;
                            listData.Add(value[num]);
                            num++;
                            readCmd = value[num].Split(' ');
                        }
                        while (!readCmd[0].Equals("endmethod"));
                        CmdMethodSelect(listData, myCanvas, num, x);
                    }
                    else
                    {
                        ParameterSeperator(readCmd, myCanvas, num);    //call ParameterSeperator method
                    }
                    num++;
                }
            }
            catch
            {

            }
        }


        public void CmdLoopWhile(List<String> listData, Drawer myCanvas, int num, int z)
        {
            string newData = string.Join("\n", listData);  //concatinates all the individual lines of codes inside of listData by \n and stores in newData
            String[] value = newData.Split('\n');  //splits the newData's data by \n , which will result in individual lines being stored in particular index
            String[] readCmd = value[0].Split(' '); //splitting a single line code on the basis of  space and storing in an array called readCmd 
            int x = 0;
            bool isValueExists = false;
            List<String> stringLists = new List<string>();
            int allValue = 1;
            while (allValue < value.Length)
            {
                stringLists.Add(value[allValue]);  //adds all the words of single parses in stringLists
                allValue++;
            }

            try
            {
                if (readCmd[1].Split('<').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('<');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCanvas.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCanvas.checkSyntax.ParameterCheck(false, tempVal[1], num, myCanvas, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCanvas.checkSyntax.ParameterCheck(false, tempVal[0], num, myCanvas, line);
                            line = line + 20;
                        }
                        else
                        {
                            while (myCanvas.storeVariable.GetVar(tempVal[0]) < x)
                            {
                                newData = string.Join("\n", stringLists);
                                MultiLineParse(newData, myCanvas);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split('>').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('>');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCanvas.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCanvas.checkSyntax.ParameterCheck(false, tempVal[1], num, myCanvas, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCanvas.checkSyntax.ParameterCheck(false, tempVal[0], num, myCanvas, line);
                            line = line + 20;
                        }
                        else
                        {
                            while (myCanvas.storeVariable.GetVar(tempVal[0]) > x)
                            {
                                newData = string.Join("\n", stringLists);
                                MultiLineParse(newData, myCanvas);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split("==".ToCharArray()).Length > 1)
                {
                    String[] tempVal = readCmd[1].Split("==".ToCharArray());
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCanvas.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCanvas.checkSyntax.ParameterCheck(false, tempVal[1], num, myCanvas, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCanvas.checkSyntax.ParameterCheck(false, tempVal[0], num, myCanvas, line);
                            line = line + 20;
                        }
                        else
                        {
                            while (myCanvas.storeVariable.GetVar(tempVal[0]) == x)
                            {
                                newData = string.Join("\n", stringLists);
                                MultiLineParse(newData, myCanvas);
                            }
                        }
                    }
                }
                else
                {
                    myCanvas.checkSyntax.ParameterCheck(false, "", num - z, myCanvas, line);
                    line = line + 20;
                }
            }
            catch
            {
                myCanvas.checkSyntax.ParameterCheck(false, "", num - z, myCanvas, line);
                line = line + 20;
            }

        }

        /// <summary>
        /// This method execute if condition when user enter if with statement in them.
        /// </summary>
        /// <param name="listData">value provided by user in program window</param>
        /// <param name="myCanvas">Hold Draw to draw on</param>
        /// <param name="num">line from where parse get executed</param>
        /// <param name="z">gives error on line number</param>
        public void CmdConditionIf(List<String> listData, Drawer myCanvas, int num, int z)
        {
            string newData = string.Join("\n", listData);
            String[] value = newData.Split('\n');
            String[] readCmd = value[0].Split(' ');
            int x = 0;
            bool isValueExists = false;
            List<String> stringList = new List<string>();
            int allValue = 1;
            while (allValue < value.Length)
            {
                stringList.Add(value[allValue]);
                allValue++;
            }
            try
            {
                if (readCmd[1].Split('<').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('<');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCanvas.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCanvas.checkSyntax.ParameterCheck(false, tempVal[1], num, myCanvas, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCanvas.checkSyntax.ParameterCheck(false, tempVal[1], num, myCanvas, line);
                            line = line + 20;
                        }
                        else
                        {
                            if (myCanvas.storeVariable.GetVar(tempVal[0]) < x)
                            {
                                newData = string.Join("\n", stringList);
                                MultiLineParse(newData, myCanvas);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split('>').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('>');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCanvas.checkSyntax.ParameterCheck(false, tempVal[0], num, myCanvas, line);
                            line = line + 20;
                        }
                        else
                        {
                            if (myCanvas.storeVariable.GetVar(tempVal[0]) < x)
                            {
                                newData = string.Join("\n", stringList);
                                MultiLineParse(newData, myCanvas);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split('>').Length > 1)
                {
                    String[] tempVal = readCmd[1].Split('>');
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCanvas.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCanvas.checkSyntax.ParameterCheck(false, tempVal[1], num, myCanvas, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCanvas.checkSyntax.ParameterCheck(false, tempVal[0], num, myCanvas, line);
                            line = line + 20;
                        }
                        else
                        {
                            if (myCanvas.storeVariable.GetVar(tempVal[0]) > x)
                            {
                                newData = string.Join("\n", stringList);
                                MultiLineParse(newData, myCanvas);
                            }
                        }
                    }
                }
                else if (readCmd[1].Split("==".ToCharArray()).Length > 1)
                {
                    String[] tempVal = readCmd[1].Split("==".ToCharArray());
                    if (!int.TryParse(tempVal[1], out x))
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[1]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCanvas.storeVariable.GetVar(tempVal[1]);
                        }
                    }
                    if (isValueExists)
                    {
                        myCanvas.checkSyntax.ParameterCheck(false, tempVal[1], num, myCanvas, line);
                        line = line + 20;
                    }
                    else
                    {
                        if (!myCanvas.storeVariable.VarExists(tempVal[0]))
                        {
                            isValueExists = true;
                        }
                        if (isValueExists)
                        {
                            myCanvas.checkSyntax.ParameterCheck(false, tempVal[0], num, myCanvas, line);
                            line = line + 20;
                        }
                        else
                        {
                            if (myCanvas.storeVariable.GetVar(tempVal[0]) > x)
                            {
                                newData = string.Join("\n", stringList);
                                MultiLineParse(newData, myCanvas);
                            }
                        }
                    }
                }
                else
                {
                    myCanvas.checkSyntax.ParameterCheck(false, "", num - z, myCanvas, line);
                    line = line + 20;
                }
            }
            catch
            {
                myCanvas.checkSyntax.ParameterCheck(false, "", num - z, myCanvas, line);
                line = line + 20;
            }
        }

        /// <summary>
        /// This method execute for loop operation when user enter for with statement in them.
        /// </summary>
        /// <param name="listData">value provided by user in program window</param>
        /// <param name="myCanvas">Hold Draw to draw on</param>
        /// <param name="num">line from where parse get executed</param>
        /// <param name="z">gives error on line number</param>
        public void CmdLoopFor(List<String> listData, Drawer myCanvas, int num, int z)//LoopFor
        {
            string newData = string.Join("\n", listData);
            String[] value = newData.Split('\n');
            String[] readCmd = value[0].Split(' ');
            int x = 0;
            bool isValueExists = false;
            List<String> stringLists = new List<string>();
            int allValue = 1;
            while (allValue < value.Length)
            {
                stringLists.Add(value[allValue]);
                allValue++;
            }
            try
            {
                if (readCmd[1].Equals("for"))
                {
                    if (!int.TryParse(readCmd[2], out x))
                    {
                        if (!myCanvas.storeVariable.VarExists(readCmd[2]))
                        {
                            isValueExists = true;
                        }
                        else
                        {
                            x = myCanvas.storeVariable.GetVar(readCmd[2]);
                        }
                    }
                }
                if (isValueExists)
                {
                    myCanvas.checkSyntax.ParameterCheck(false, readCmd[2], num, myCanvas, line);
                    line = line + 20;
                }
                else
                {
                    for (int b = 0; b < x; b++)
                    {
                        newData = string.Join("\n", stringLists);
                        MultiLineParse(newData, myCanvas);
                    }
                }
            }
            catch
            {
                myCanvas.checkSyntax.ParameterCheck(false, "", num - z, myCanvas, line);
                line = line + 20;
            }
        }

        /// <summary>
        /// This method execute method operation when user enter while with statement in them.
        /// </summary>
        /// <param name="listData">value provided by user in program window</param>
        /// <param name="myCanvas">Hold Draw to draw on</param>
        /// <param name="num">line from where parse get executed</param>
        /// <param name="z">gives error on line number</param>
        public void CmdMethodSelect(List<String> listData, Drawer myCanvas, int num, int z)
        {
            string newData = string.Join("\n", listData);
            String[] value = newData.Split('\n');
            String[] readCmd = value[0].Split(' ');
            String x = null;
            bool isValueExists = false;
            String[] method = readCmd[1].Split('(', ')');
            String[] methodValue = null;

            myCanvas.storeMethod.StoreVar(method[0], method[1]);
            List<String> stringLists = new List<string>();
            int allValue = 1;
            while (allValue < value.Length)
            {
                stringLists.Add(value[allValue]);
                allValue++;
            }
            try
            {
                if (myCanvas.storeMethod.VarExists(method[0]))
                {
                    x = myCanvas.storeMethod.GetVar(method[0]);
                    methodValue = x.Split(',');
                }
                else
                {
                    isValueExists = true;
                }
                if (isValueExists)
                {
                    myCanvas.checkSyntax.ParameterCheck(false, readCmd[1], num, myCanvas, line);
                    line = line + 20;
                }
                else
                {
                    newData = string.Join("\n", stringLists);
                    String methodCmd = method[0] + "parse";
                    myCanvas.storeMethod.StoreVar(methodCmd, newData);
                }

            }
            catch
            {
                myCanvas.checkSyntax.ParameterCheck(false, "", num - z, myCanvas, line);
                line = line + 20;
            }

        }

        /// <summary>
        /// This method interact with different Shape and drawing component use for drawing Shape
        /// </summary>
        /// <param name="readCmd">value provided by user</param>
        /// <param name="myCanvas">Hold Draw to draw on</param>
        /// <param name="num">line from where parse get executed</param>
        public void ParameterSeperator(String[] readCmd, Drawer myCanvas, int num)
        {
            try
            {
                String[] method = readCmd[0].Split('(', ')');
                // if parse provided by user is drawto, this block get executed to draw Line
                if (readCmd[0].Equals("drawto"))
                {
                    //split parameters when comma occurs between parameter and store value in string array 
                    String[] data = readCmd[1].Split(','); ;
                    int x = 0;
                    int y = 0;
                    bool isVarExists = false;
                    //try block run for valid parameter otherwise throw exception by catch block
                    try
                    {
                        //Convert string into integer
                        if (!int.TryParse(data[0], out x))
                        {
                            //check, if value is already in store variable then return boolean true otherwise it get value in else block
                            if (!myCanvas.storeVariable.VarExists(data[0]))
                            {
                                isVarExists = true;
                            }
                            else
                            {
                                x = myCanvas.storeVariable.GetVar(data[0]);
                            }
                            //if value get true then value go for check valid parameter
                            if (isVarExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, data[0], num, myCanvas, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!myCanvas.storeVariable.VarExists(data[1]))
                            {
                                isVarExists = true;
                            }
                            else
                            {
                                y = myCanvas.storeVariable.GetVar(data[1]);
                            }
                            if (isVarExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, data[1], num, myCanvas, line);
                                num = num + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                        line = line + 20;
                    }
                    //when myCanvas doesnot get any error,this block get executed
                    if (!myCanvas.error)
                    {
                        myCanvas.DrawLine(x, y);
                    }
                }

                // When parse provided by user is moveto, this block get executed to move pen position
                else if (readCmd[0].Equals("moveto"))
                {
                    //split parameters when comma occurs between parameter and store value in string array
                    String[] data = readCmd[1].Split(','); ;
                    int x = 0;
                    int y = 0;
                    bool isValueExists = false;
                    //try block run for valid parameter otherwise throw exception by catch block
                    try
                    {
                        if (!int.TryParse(data[0], out x))
                        {
                            if (!myCanvas.storeVariable.VarExists(data[0]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCanvas.storeVariable.GetVar(data[0]);
                            }
                            if (isValueExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, data[0], num, myCanvas, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!myCanvas.storeVariable.VarExists(data[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                y = myCanvas.storeVariable.GetVar(data[1]);
                            }
                            if (isValueExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, data[1], num, myCanvas, line);
                                num = num + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                        line = line + 20;
                    }
                    //when myCanvas doesnot get any error,this block get executed
                    if (!myCanvas.error)
                    {
                        myCanvas.MoveTo(x, y);
                    }
                }

                // When parse provided by user is rectangle, this block get executed to draw Rectangle Shape
                else if (readCmd[0].Equals("rectangle"))
                {
                    //split parameters when comma occurs between parameter and store value in string array
                    String[] data = readCmd[1].Split(','); ;
                    int x = 0;
                    int y = 0;
                    bool isValueExists = false;
                    //try block run for valid parameter otherwise throw exception by catch block
                    try
                    {
                        if (!int.TryParse(data[0], out x))
                        {
                            if (!myCanvas.storeVariable.VarExists(data[0]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCanvas.storeVariable.GetVar(data[0]);
                            }
                            if (isValueExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, data[0], num, myCanvas, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!myCanvas.storeVariable.VarExists(data[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                y = myCanvas.storeVariable.GetVar(data[1]);
                            }
                            if (isValueExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, data[1], num, myCanvas, line);
                                line = line + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                        line = line + 20;
                    }
                    //when myCanvas doesnot get any error,this block get executed
                    if (!myCanvas.error)
                    {
                        Shape drawRectangle = new Rectangle(x, y);
                        drawRectangle.Drawer(myCanvas);
                    }
                }
                // When parse provided by user is square, this block get executed to draw Square Shape
                else if (readCmd[0].Equals("square"))
                {
                    int x = 0;
                    bool isValueExists = false;
                    //try block run for valid parameter otherwise throw exception by catch block
                    try
                    {
                        if (!int.TryParse(readCmd[1], out x))
                        {
                            if (!myCanvas.storeVariable.VarExists(readCmd[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCanvas.storeVariable.GetVar(readCmd[1]);
                            }
                            if (isValueExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, readCmd[1], num, myCanvas, line);
                                line = line + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                        line = line + 20;
                    }
                    //when myCanvas doesnot get any error,this block get executed
                    if (!myCanvas.error)
                    {
                        Shape Rectangle = new Rectangle(x, x);
                        Rectangle.Drawer(myCanvas);
                    }
                }

                // When parse provided by user is circle, this block get executed to draw Triangle Shape
                else if (readCmd[0].Equals("triangle"))
                {
                    //split parameters when comma occurs between parameter and store value in string array
                    String[] data = readCmd[1].Split(','); ;
                    int x = 0;
                    int y = 0;
                    int z = 0;
                    bool isValueExists = false;
                    //try block run for valid parameter otherwise throw exception by catch block
                    try
                    {
                        if (!int.TryParse(data[0], out x))
                        {
                            if (!myCanvas.storeVariable.VarExists(data[0]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCanvas.storeVariable.GetVar(data[0]);
                            }
                            if (isValueExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, data[0], num, myCanvas, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!myCanvas.storeVariable.VarExists(data[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                y = myCanvas.storeVariable.GetVar(data[1]);
                            }
                            if (isValueExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, data[1], num, myCanvas, line);
                                line = line + 20;
                            }
                        }
                        if (!int.TryParse(data[2], out z))
                        {
                            if (!myCanvas.storeVariable.VarExists(data[2]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                z = myCanvas.storeVariable.GetVar(data[2]);
                            }
                            if (isValueExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, data[2], num, myCanvas, line);
                                line = line + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                        line = line + 20;
                    }
                    //when myCanvas doesnot get any error,this block get executed to draw triangle
                    if (!myCanvas.error)
                    {
                        Shape Triangle = new Triangle(x, y, z);
                        Triangle.Drawer(myCanvas);
                    }
                }
                // When parse provided by user is circle, this block get executed to draw Circle Shape
                else if (readCmd[0].Equals("circle"))
                {
                    int x = 0;
                    bool isValueExists = false;
                    //try block run for valid parameter otherwise throw exception by catch block
                    try
                    {
                        if (!int.TryParse(readCmd[1], out x))
                        {
                            if (!myCanvas.storeVariable.VarExists(readCmd[1]))
                            {
                                isValueExists = true;
                            }
                            else
                            {
                                x = myCanvas.storeVariable.GetVar(readCmd[1]);
                            }
                            if (isValueExists)
                            {
                                myCanvas.checkSyntax.ParameterCheck(false, readCmd[1], num, myCanvas, line);
                                line = line + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                        line = line + 20;
                    }
                    //when myCanvas doesnot get any error,this block get executed
                    if (!myCanvas.error)
                    {
                        Shape Circle = new Circle(x);
                        Circle.Drawer(myCanvas);
                    }
                }
                // When parse provided by user is pen, this block get executed
                else if (readCmd[0].Equals("polygon"))
                {
                    String[] data = readCmd[1].Split(',');
                    List<int> listPoints = new List<int>();
                    int i = 0;
                    int x = 0;
                    bool isValueExists = false;
                    try
                    {
                        while (data.Length > i)
                        {
                            if (!int.TryParse(data[i], out x))
                            {
                                if (!myCanvas.storeVariable.VarExists(data[i]))
                                {
                                    isValueExists = true;
                                }
                                else
                                {
                                    listPoints.Add(myCanvas.storeVariable.GetVar(data[i]));
                                }
                                if (isValueExists)
                                {
                                    myCanvas.checkSyntax.ParameterCheck(false, data[i], num, myCanvas, line);
                                    line = line + 20;
                                }
                            }
                            listPoints.Add(x);
                            i++;
                        }
                    }
                    catch (Exception e)
                    {
                        myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                        line = line + 20;
                    }
                }

                else if (readCmd[0].Equals("pen"))
                {
                    Color color = Color.FromName(readCmd[1]); //User input color 

                    if (color.IsKnownColor == false)
                    {
                        myCanvas.checkSyntax.ParameterCheck(false, readCmd[1], num, myCanvas, line);
                        line = line + 20;
                    }

                    if (!myCanvas.error)
                    {
                        myCanvas.Set_Pen_Color(color); // call and set color given by user
                    }
                }

                else if (readCmd[0].Equals("fill"))
                {
                    bool fillOn = readCmd[1].Equals("on");
                    bool fillOff = readCmd[1].Equals("off");

                    if (fillOn == false && fillOff == false)
                    {
                        myCanvas.checkSyntax.ParameterCheck(false, readCmd[1], num, myCanvas, line);
                        line = line + 20;
                    }


                    if (!myCanvas.error)
                    {
                        //When fiil get on
                        if (fillOn)
                        {
                            myCanvas.fill = true;
                        }
                        //when fill gets off
                        else if (fillOff)
                        {
                            myCanvas.fill = false;
                        }
                    }
                }

                else if (readCmd[0].Equals("clear"))
                {
                    //when myCanvas doesnot get any error,this block get executed
                    if (!myCanvas.error)
                    {
                        myCanvas.Clear();
                    }
                }

                else if (readCmd[0].Equals("reset"))
                {
                    //when myCanvas doesnot get any error,this block get executed to reset
                    if (!myCanvas.error)
                    {
                        myCanvas.Reset();
                    }
                }

                else if (readCmd[0].Equals("exit"))
                {
                    //when myCanvas doesnot get any error,this block get executed
                    if (!myCanvas.error)
                    {
                        Application.Exit();
                    }
                }

                else if (myCanvas.storeMethod.VarExists(method[0]))
                {
                    String[] methodValue = (myCanvas.storeMethod.GetVar(method[0])).Split(',');
                    String methodCmd = method[0] + "parse";
                    String methodparse = myCanvas.storeMethod.GetVar(methodCmd);
                    //split parameters when comma occurs between parameter and store value in string array
                    String[] userValue = method[1].Split(',');
                    int x = 0;
                    while (methodValue.Length > x)
                    {
                        String[] valueStore = (methodValue[x] + " = " + userValue[x]).Split(' ');
                        ParameterSeperator(valueStore, myCanvas, num);
                        x++;
                    }
                    MultiLineParse(methodparse, myCanvas);

                }

                else if (readCmd[1].Equals("="))
                {
                    //try block run for valid parameter otherwise throw exception by catch block
                    try
                    {
                        //For adition operation
                        if (readCmd[3].Equals("+"))
                        {
                            int varValue;
                            int x = 0;
                            int y = 0;
                            bool isValueExists = false;
                            try
                            {
                                if (!int.TryParse(readCmd[2], out x))
                                {
                                    if (!myCanvas.storeVariable.VarExists(readCmd[2]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        x = myCanvas.storeVariable.GetVar(readCmd[2]);
                                    }
                                }

                                if (!int.TryParse(readCmd[4], out y))
                                {
                                    if (!myCanvas.storeVariable.VarExists(readCmd[4]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        y = myCanvas.storeVariable.GetVar(readCmd[4]);
                                    }
                                }
                                if (isValueExists)
                                {
                                    myCanvas.checkSyntax.ParameterCheck(false, readCmd[2], num, myCanvas, line);
                                    line = line + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                                line = line + 20;
                            }
                            varValue = x + y;
                            myCanvas.storeVariable.EditVar(readCmd[0], varValue);
                        }
                        //For Substract operation
                        if (readCmd[3].Equals("-"))
                        {
                            int varValue;
                            int x = 0;
                            int y = 0;
                            bool isValueExists = false;
                            try
                            {
                                if (!int.TryParse(readCmd[2], out x))
                                {
                                    if (!myCanvas.storeVariable.VarExists(readCmd[2]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        x = myCanvas.storeVariable.GetVar(readCmd[2]);
                                    }
                                }

                                if (!int.TryParse(readCmd[4], out y))
                                {
                                    if (!myCanvas.storeVariable.VarExists(readCmd[4]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        y = myCanvas.storeVariable.GetVar(readCmd[4]);
                                    }
                                }
                                if (isValueExists)
                                {
                                    myCanvas.checkSyntax.ParameterCheck(false, readCmd[2], num, myCanvas, line);
                                    line = line + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                                line = line + 20;
                            }
                            varValue = x - y;
                            myCanvas.storeVariable.EditVar(readCmd[0], varValue);
                        }
                        //For Divide operation
                        if (readCmd[3].Equals("/"))
                        {
                            int varValue;
                            int x = 0;
                            int y = 0;
                            bool isValueExists = false;
                            try
                            {
                                if (!int.TryParse(readCmd[2], out x))
                                {
                                    if (!myCanvas.storeVariable.VarExists(readCmd[2]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        x = myCanvas.storeVariable.GetVar(readCmd[2]);
                                    }
                                }

                                if (!int.TryParse(readCmd[4], out y))
                                {
                                    if (!myCanvas.storeVariable.VarExists(readCmd[4]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        y = myCanvas.storeVariable.GetVar(readCmd[4]);
                                    }
                                }
                                if (isValueExists)
                                {
                                    myCanvas.checkSyntax.ParameterCheck(false, readCmd[2], num, myCanvas, line);
                                    line = line + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                                line = line + 20;
                            }
                            varValue = x / y;
                            myCanvas.storeVariable.EditVar(readCmd[0], varValue);
                        }
                        //For Multiply operation
                        if (readCmd[3].Equals("*"))
                        {
                            int varValue;
                            int x = 0;
                            int y = 0;
                            bool isValueExists = false;
                            try
                            {
                                if (!int.TryParse(readCmd[2], out x))
                                {
                                    if (!myCanvas.storeVariable.VarExists(readCmd[2]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        x = myCanvas.storeVariable.GetVar(readCmd[2]);
                                    }
                                }

                                if (!int.TryParse(readCmd[4], out y))
                                {
                                    if (!myCanvas.storeVariable.VarExists(readCmd[4]))
                                    {
                                        isValueExists = true;
                                    }
                                    else
                                    {
                                        y = myCanvas.storeVariable.GetVar(readCmd[4]);
                                    }
                                }
                                if (isValueExists)
                                {
                                    myCanvas.checkSyntax.ParameterCheck(false, readCmd[2], num, myCanvas, line);
                                    line = line + 20;
                                }
                            }
                            catch (Exception e)
                            {
                                myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                                line = line + 20;
                            }
                            varValue = x * y;
                            myCanvas.storeVariable.EditVar(readCmd[0], varValue);
                        }
                    }
                    catch
                    {
                        int x = 0;
                        //try block run for valid parameter otherwise throw exception by catch block
                        try
                        {
                            bool isValueExists = false;
                            if (!int.TryParse(readCmd[2], out x))
                            {
                                if (!myCanvas.storeVariable.VarExists(readCmd[2]))
                                {
                                    isValueExists = true;
                                }
                                else
                                {
                                    x = myCanvas.storeVariable.GetVar(readCmd[2]);
                                }
                                if (isValueExists)
                                {
                                    myCanvas.checkSyntax.ParameterCheck(false, readCmd[2], num, myCanvas, line);
                                    line = line + 20;
                                }
                            }
                        }
                        //catch error exception thrown by try
                        catch (Exception e)
                        {
                            myCanvas.checkSyntax.ParameterCheck(e, num, myCanvas, line);
                            line = line + 20;
                        }
                        //if MyCanvas doesnot get any error then this block get execute
                        if (!myCanvas.error)
                        {
                            if (!myCanvas.storeVariable.VarExists(readCmd[0]))
                            {
                                myCanvas.storeVariable.StoreVar(readCmd[0], x);
                            }
                            else
                            {
                                myCanvas.storeVariable.EditVar(readCmd[0], x);
                            }
                        }
                    }
                }
                //check parse for valid
                else
                {
                    myCanvas.checkSyntax.parseCheck(myCanvas, num, line);
                    line = line + 20;
                }
            }
            //catch error exception thrown by try for parse check
            catch
            {
                myCanvas.checkSyntax.parseCheck(myCanvas, num, line);
                line = line + 20;
            }

        }
    }
}