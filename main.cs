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
      if (lines[indexRow][i] == ' ') {
        
      } else {
        // Find all rows which aren't blank. Push them onto stack
        Stack<char> stack = new Stack<char>();
        for (int j=indexRow-1; j>=0; j--) {
          if(lines[j][i] == ' ') {
            
          } else {
            stack.Push(lines[j][i]);
          }
        }
        // Add stack to list of stacks
        stacks.Add(stack);
      }
    }

    // Identify commands to execute
    for (int i=indexRow+2; i<lines.Length; i++) {
      string commandLine = lines[i];
      string[] commands = commandLine.Split(new[] { "move ", " from ", " to " }, StringSplitOptions.None);
      

      
      int reps = Convert.ToInt32(commands[1]);
      int fromStack = Convert.ToInt32(commands[2]) - 1;
      int toStack = Convert.ToInt32(commands[3]) - 1;

      // Create stack of items to move.
      // Stack ensures order stays the same
      Stack<char> toMove = new Stack<char>();

      // Remove n from cargo stack into stack
      for (int numCmd = 0; numCmd<reps; numCmd++) {
        char popped = stacks[fromStack].Pop();
        toMove.Push(popped);
      }

      // Empty the stack onto the new cargo stack
      while(toMove.Count > 0) {
        char pop = toMove.Pop();
        stacks[toStack].Push(pop);
      }
      
    }

    
    // All shifts complete
    // Get top item from each stack
    StringBuilder sb = new StringBuilder();
    foreach(Stack<char> stack in stacks) {
      sb.Append(stack.Peek());
    }
    string output = sb.ToString();
    Console.WriteLine(output);
  }
} // LVMRWSSPZ