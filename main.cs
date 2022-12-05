using System;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    string[] lines = System.IO.File.ReadAllLines(@"crates.txt");
    // Where to start looking for indexes of crates
    int indexRow = 3;
    // Stack of stack
    List<Stack<char>> stacks = new List<Stack<char>>();

    // Run along index row
    for(int i=0; i<lines[indexRow].Length; i++) {
      Console.WriteLine("i: {0}",i);
      if (lines[indexRow][i] == ' ') {
        
      } else {
        Stack<char> stack = new Stack<char>();
        for (int j=indexRow-1; j>=0; j--) {
          Console.WriteLine(" j: {0}",j);
          if(lines[j][i] == ' ') {
            
          } else {
            stack.Push(lines[j][i]);
          }
        }
        stacks.Add(stack);
      }
    }
    foreach(Stack<char> stack in stacks) {
      foreach (var item in stack)
       Console.Write(item + ",");
      Console.WriteLine();
    
    }
    Console.WriteLine(stacks[0].Pop());
  }
}