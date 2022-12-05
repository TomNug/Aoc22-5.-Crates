using System;
using System.Collections.Generic;
using System.Text;

class Program {
  public static void Main (string[] args) {
    string[] lines = System.IO.File.ReadAllLines(@"crates.txt");
    // Where to start looking for indexes of crates
    int indexRow = 8;
    // Stack of stack
    List<Stack<char>> stacks = new List<Stack<char>>();

    // Run along index row
    for(int i=0; i<lines[indexRow].Length; i++) {
      //Console.WriteLine("i: {0}",i);
      if (lines[indexRow][i] == ' ') {
        
      } else {
        Stack<char> stack = new Stack<char>();
        for (int j=indexRow-1; j>=0; j--) {
          //Console.WriteLine(" j: {0}",j);
          if(lines[j][i] == ' ') {
            
          } else {
            stack.Push(lines[j][i]);
          }
        }
        stacks.Add(stack);
      }
    }
    //foreach(Stack<char> stack in stacks) {
      //foreach (var item in stack)
       //Console.Write(item + ",");
      //Console.WriteLine();
    
    //}
    //Console.WriteLine(stacks[0].Pop());

    for (int i=indexRow+2; i<lines.Length; i++) {
      Console.WriteLine("i: {0}", i);
      string commandLine = lines[i];
      string[] commands = commandLine.Split(new[] { "move ", " from ", " to " }, StringSplitOptions.None);
      
      Console.WriteLine("-");
      foreach(string s in commands){
        Console.WriteLine(s);
      }
      Console.WriteLine("-");
      
      
      int reps = Convert.ToInt32(commands[1]);
      int fromStack = Convert.ToInt32(commands[2]) - 1;
      int toStack = Convert.ToInt32(commands[3]) - 1;
      //int reps = Char.GetNumericValue(commandLine[5]);
      //int fromStack = Char.GetNumericValue(commandLine[12]);
      //int toStack = Char.GetNumericValue(commandLine[17]);
      Console.WriteLine("Move {0} from {1} to {2}", reps, fromStack, toStack);      
      for (int numCmd = 0; numCmd<reps; numCmd++) {
        char popped = stacks[fromStack].Pop();
        stacks[toStack].Push(popped);
      }
    }

    StringBuilder sb = new StringBuilder();
    
    // All shifts complete
    foreach(Stack<char> stack in stacks) {
      sb.Append(stack.Pop());
    }
    string output = sb.ToString();
    Console.WriteLine(output);
  }
}