using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value == Data)
        {
            return;
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else if (!Left.Contains(value))
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else if (!Right.Contains(value))
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
           if (value == Data) return true;
            else if (value < Data) return Left != null && Left.Contains(value);
            else return Right != null && Right.Contains(value);
   
    }

    public int GetHeight()
    {
        if (this is null)
            return 0;
        else
        {
            int leftHeight = Left == null ? 0 : Left.GetHeight();
            int rightHeight = Right == null ? 0 : Right.GetHeight();
            return 1 + Math.Max(leftHeight, rightHeight);

        };
    
    }
}